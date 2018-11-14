using Newtonsoft.Json;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Communication
{
    public class CalculoQueueManager
    {
        private const string FILA_A_PROCESSAR = "CalculosAProcessar";
        private const string FILA_PROCESSADOS = "CalculosProcessados";

        private readonly ConnectionFactory _connectionFactory;
        private readonly ICalculoService _service;
        private readonly IPeriodoPericulosidadeService _periculosidadeService;

        public CalculoQueueManager(
            ICalculoService service,
            IPeriodoPericulosidadeService periculosidadeService)
        {
            _service = service;
            _periculosidadeService = periculosidadeService;

            _connectionFactory = new ConnectionFactory()
            {
                //Uri = new Uri("amqp://qaawhjrg:ToYjFh11DYBCJId-_1axNQ1xjm4yt0j7@toad.rmq.cloudamqp.com/qaawhjrg"),
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var conn = _connectionFactory.CreateConnection();
            var channel = conn.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ev) =>
            {
                var message = Encoding.UTF8.GetString(ev.Body);
                var command = JsonConvert.DeserializeObject<CalcularSalarioCommand>(message);

                Console.WriteLine($"{DateTime.Now} [Worker - Cálculos] Nova mensagem recebida: {message}");

                var horasPericulosidade = _periculosidadeService.Obter(command.NumeroCartao);
                command.HorasComPericulosidade = horasPericulosidade.Sum(h => h.HorasComPericulosidade);

                horasPericulosidade.ForEach(h =>
                {
                    h.MarcarComoCalculado();
                    _periculosidadeService.Salvar(h);
                });

                var calculo = _service.RealizarCalculo(command);
                Publicar(calculo);
            };

            channel.BasicConsume(FILA_A_PROCESSAR, true, consumer);
        }

   
        public void Publicar(Calculo message)
        {
            using (var conn = _connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.QueueDeclare(FILA_PROCESSADOS, true, false, false, null);
                channel.BasicPublish("", FILA_PROCESSADOS, null, data);
                
                channel.Close();
                conn.Close();
            }
        }
    }
}

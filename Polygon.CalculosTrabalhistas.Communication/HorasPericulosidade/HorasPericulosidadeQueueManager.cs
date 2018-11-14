using Newtonsoft.Json;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Communication.HorasPericulosidade
{
    public class HorasPericulosidadeQueueManager
    {
        private const string FILA_HORAS_PERICULOSIDADE = "HorasPericulosidade";
        
        private readonly ConnectionFactory _connectionFactory;

        public HorasPericulosidadeQueueManager(IPeriodoPericulosidadeService service)
        {
            _connectionFactory = new ConnectionFactory()
            {
                //Uri = new Uri("amqp://qaawhjrg:ToYjFh11DYBCJId-_1axNQ1xjm4yt0j7@toad.rmq.cloudamqp.com/qaawhjrg"),
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var conn =_connectionFactory.CreateConnection();
            var channel = conn.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var message = Encoding.UTF8.GetString(args.Body);
                Console.WriteLine($"{DateTime.Now} [Worker - Periculosidade] Nova mensagem recebida: {message}");

                var command = JsonConvert.DeserializeObject<AdicionarPeriodoPericulosidadeCommand>(message);

                service.Adicionar(command);
            };

            channel.BasicConsume(FILA_HORAS_PERICULOSIDADE, true, consumer);
        }
    }
}

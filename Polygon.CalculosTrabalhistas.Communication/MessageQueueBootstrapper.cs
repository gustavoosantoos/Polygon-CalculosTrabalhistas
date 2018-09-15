using Newtonsoft.Json;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Domain.Entities;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Communication
{
    public class MessageQueueManager
    {
        private const string FILA_A_PROCESSAR = "CalculosAProcessar";
        private const string FILA_PROCESSADOS = "CalculosProcessados";

        private readonly ConnectionFactory _connectionFactory;

        public MessageQueueManager()
        {
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://vcudyxng:F9ybJT1_1Pd6NEr9t77I5efYjXVb6ZUQ@chimpanzee.rmq.cloudamqp.com/vcudyxng"),
                UserName = "vcudyxng",
                Password = "F9ybJT1_1Pd6NEr9t77I5efYjXVb6ZUQ"
            };
        }

        public CalcularSalarioCommand Consumir()
        {
            using (var conn = _connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(FILA_A_PROCESSAR, true, false, false, null);

                var data = channel.BasicGet(FILA_A_PROCESSAR, false);
                if (data == null)
                    return null;

                var message = Encoding.UTF8.GetString(data.Body);
                channel.BasicAck(data.DeliveryTag, false);

                return JsonConvert.DeserializeObject<CalcularSalarioCommand>(message);
            }
        } 

        public void Publicar(Calculo message)
        {
            using (var conn = _connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.QueueDeclare(FILA_PROCESSADOS, true, false, false, null);
                channel.BasicPublish("", FILA_PROCESSADOS, null, data);
            }
        }
    }
}

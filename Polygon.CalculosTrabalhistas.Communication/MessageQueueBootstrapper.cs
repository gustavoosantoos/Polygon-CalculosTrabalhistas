using Newtonsoft.Json;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
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

        public string Consumir()
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

                return message;
            }
        } 

        public void Publicar(string message)
        {
            using (var conn = _connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var data = Encoding.UTF8.GetBytes(message);
                channel.QueueDeclare(FILA_PROCESSADOS, true, false, false, null);
                channel.BasicPublish("", FILA_PROCESSADOS, null, data);
            }
        }
    }
}

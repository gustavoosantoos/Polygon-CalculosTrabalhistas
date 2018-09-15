using Microsoft.Extensions.Hosting;
using Polygon.CalculosTrabalhistas.Application.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polygon.CalculosTrabalhistas.Communication.Workers
{
    public class CalculoWorker : IHostedService
    {
        private Timer _timer;
        private ICalculoService _service;
        private MessageQueueManager _messageQueueManager;

        public CalculoWorker(ICalculoService service, MessageQueueManager messageQueueManager)
        {
            _service = service;
            _messageQueueManager = messageQueueManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var command = _messageQueueManager.Consumir();

            if (command == null)
                return; 

            var calculo = _service.RealizarCalculo(command);
            _messageQueueManager.Publicar(calculo);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

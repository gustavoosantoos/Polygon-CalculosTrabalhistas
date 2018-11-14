using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Communication.HorasPericulosidade;

namespace Polygon.CalculosTrabalhistas.Communication.Workers
{
    public class HorasPericulosidadeWorker : IHostedService
    {
        private Timer _timer;
        private HorasPericulosidadeQueueManager _messageQueueManager;

        public HorasPericulosidadeWorker(
            HorasPericulosidadeQueueManager messageQueueManager)
        {
            _messageQueueManager = messageQueueManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

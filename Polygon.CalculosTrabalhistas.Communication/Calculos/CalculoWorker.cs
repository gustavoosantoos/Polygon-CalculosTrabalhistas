using Microsoft.Extensions.Hosting;
using Polygon.CalculosTrabalhistas.Application.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Polygon.CalculosTrabalhistas.Communication.Workers
{
    public class CalculoWorker : IHostedService
    {
        private Timer _timer;
        private ICalculoService _service;
        private readonly IPeriodoPericulosidadeService _periculosidadeService;
        private CalculoQueueManager _messageQueueManager;

        public CalculoWorker(
            ICalculoService service, 
            IPeriodoPericulosidadeService periculosidadeService,
            CalculoQueueManager messageQueueManager)
        {
            _service = service;
            _periculosidadeService = periculosidadeService;
            _messageQueueManager = messageQueueManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_timer = new Timer(DoWork,
            //    null,
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(2));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var command = _messageQueueManager.Consumir();

            if (command == null)
                return;

            var horasPericulosidade = _periculosidadeService.Obter(command.NumeroCartao);
            command.HorasComPericulosidade = horasPericulosidade.Sum(h => h.HorasComPericulosidade);

            horasPericulosidade.ForEach(h =>
            {
                h.MarcarComoCalculado();
                _periculosidadeService.Salvar(h);
            });

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

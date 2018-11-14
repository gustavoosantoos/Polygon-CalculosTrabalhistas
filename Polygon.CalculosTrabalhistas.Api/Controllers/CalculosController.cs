using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Communication;
using Polygon.CalculosTrabalhistas.Communication.HorasPericulosidade;
using Swashbuckle;

namespace Polygon.CalculosTrabalhistas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculoService _calculoService;
        private readonly IPeriodoPericulosidadeService _periculosidadeService;

        public CalculosController(
            ICalculoService calculoService,
            IPeriodoPericulosidadeService periculosidadeService)
        {
            _calculoService = calculoService;
            _periculosidadeService = periculosidadeService;
        }

        [HttpPost]
        public IActionResult Calcular(CalcularSalarioCommand command)
        {
            if (ModelState.IsValid)
            {
                //var messageManager = new CalculoQueueManager();
                //messageManager.SolicitarCalculo(command);

                return Ok();
            }

            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }

        [HttpPost]
        [Route("periculosidade")]
        public IActionResult PostHoraPericulosidade(AdicionarPeriodoPericulosidadeCommand command)
        {
            if (ModelState.IsValid)
            {
                _periculosidadeService.Adicionar(command);
                return Ok();
            }

            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}
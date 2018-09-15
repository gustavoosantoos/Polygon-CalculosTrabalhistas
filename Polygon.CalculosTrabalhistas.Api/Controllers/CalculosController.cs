using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Swashbuckle;

namespace Polygon.CalculosTrabalhistas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculoService _service;

        public CalculosController(ICalculoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Calcular(CalcularSalarioCommand command)
        {
            if (ModelState.IsValid)
            {
                return Ok(_service.RealizarCalculo(command));
            }

            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}
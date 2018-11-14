using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Application.CommandObjects
{
    public class AdicionarPeriodoPericulosidadeCommand
    {
        public string NumeroCartao { get; set; }
        public double HorasComPericulosidade { get; set; }
    }
}

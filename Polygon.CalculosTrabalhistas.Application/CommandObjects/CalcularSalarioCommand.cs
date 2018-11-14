using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Application.CommandObjects
{
    public class CalcularSalarioCommand
    {
        public int MatriculaFuncionario { get; set; }
        public double ValorHora { get; set; }
        public double HorasTrabalhadas { get; set; }
        public double HorasComPericulosidade { get; set; }
        public string NumeroCartao { get; set; }
    }
}

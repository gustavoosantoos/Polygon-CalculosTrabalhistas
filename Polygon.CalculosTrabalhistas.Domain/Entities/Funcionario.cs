using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Domain.Entities
{
    public class Funcionario
    {
        protected Funcionario()
        {

        }

        public Funcionario(int matricula, double valorHora)
        {
            Matricula = matricula;
            ValorHora = valorHora;
        }

        public int Matricula { get; private set; }
        public double ValorHora { get; private set; }
    }
}

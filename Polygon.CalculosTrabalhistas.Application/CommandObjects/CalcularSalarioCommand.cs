using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Application.CommandObjects
{
    public class CalcularSalarioCommand
    {
        public CalcularSalarioCommand(int matriculaFuncionario, double valorHora, double horasTrabalhadas)
        {
            MatriculaFuncionario = matriculaFuncionario;
            ValorHora = valorHora;
            HorasTrabalhadas = horasTrabalhadas;
        }

        public int MatriculaFuncionario { get; private set; }
        public double ValorHora { get; private set; }
        public double HorasTrabalhadas { get; private set; }
    }
}

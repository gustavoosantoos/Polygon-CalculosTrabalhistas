using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Domain.Entities
{
    public class Calculo
    {
        public Calculo(Funcionario funcionario, double horasTrabalhadas)
        {
            Funcionario = funcionario;
            HorasTrabalhadas = horasTrabalhadas;
            RealizaCalculos();
        }

        public Funcionario Funcionario { get; private set; }
        public double HorasTrabalhadas { get; private set; }
        public double SalarioBruto { get; private set; }
        public double SalarioLiquido { get; private set; }
        public double Inss { get; private set; }
        public double ImpostoRenda { get; private set; }
        
        private void RealizaCalculos()
        {
            throw new NotImplementedException();
        }
    }
}

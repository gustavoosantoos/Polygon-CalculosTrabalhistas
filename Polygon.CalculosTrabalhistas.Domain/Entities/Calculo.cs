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
        }

        public Funcionario Funcionario { get; private set; }
        public double HorasTrabalhadas { get; private set; }

        public double SalarioBruto => Funcionario.ValorHora * HorasTrabalhadas;
        public double Inss { get; private set; }
        public double ImpostoRenda { get; private set; }
        public double SalarioLiquido => SalarioBruto - Inss - ImpostoRenda;


        private double CalcularInss()
        {
            const double DescontoMaximoInss = 621.04;

            double CalculaDesconto(int porcentagem)
            {
                return (SalarioBruto / 100.0) * porcentagem;
            }

            switch (SalarioBruto)
            {
                case double salario when salario < 1693.72:
                    return CalculaDesconto(8);
                case double salario when salario < 2822.90:
                    return CalculaDesconto(9);
                case double salario when salario < 5645.80:
                    return CalculaDesconto(11);
                default:
                    return DescontoMaximoInss;
            }
        }
    }
}

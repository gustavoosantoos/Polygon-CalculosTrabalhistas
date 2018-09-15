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

        public string Id { get; set; }

        public Funcionario Funcionario { get; private set; }
        public double HorasTrabalhadas { get; private set; }

        public double SalarioBruto => Funcionario.ValorHora * HorasTrabalhadas;
        public double Inss => CalcularInss();
        public double Irrf => CalcularIrrf();
        public double SalarioLiquido => SalarioBruto - Inss - Irrf;


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

        private double CalcularIrrf()
        {
            double baseDeCalculo = SalarioBruto - Inss;
            (double percentual, double valorFixo) = calcularFaixaDePercentual(baseDeCalculo);

            return ((baseDeCalculo / 100.0) * percentual) - valorFixo;
        }

        private (double percentual, double valorFixo) calcularFaixaDePercentual(double baseDeCalculo)
        {
            switch (baseDeCalculo)
            {
                case double valor when valor < 1903.99:
                    return (0, 0);
                case double valor when valor <= 2826.65:
                    return (7.5, 142.80);
                case double valor when valor <= 3751.05:
                    return (15, 354.80);
                case double valor when valor <= 4664.68:
                    return (22.5, 636.13);
                default:
                    return (27.5, 869.36);
            }
        }
    }
}

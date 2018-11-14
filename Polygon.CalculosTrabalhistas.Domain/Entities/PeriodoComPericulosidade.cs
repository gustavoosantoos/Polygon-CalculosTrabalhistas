using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Domain.Entities
{
    public class PeriodoComPericulosidade
    {
        protected PeriodoComPericulosidade()
        {

        }

        public PeriodoComPericulosidade(string numeroCartao, double horasComPericulosidade, bool calculado)
        {
            NumeroCartao = numeroCartao;
            HorasComPericulosidade = horasComPericulosidade;
            Calculado = calculado;
        }

        public string Id { get; private set; }
        public string NumeroCartao { get; private set; }
        public double HorasComPericulosidade { get; private set; }
        public bool Calculado { get; private set; }

        public void MarcarComoCalculado() => Calculado = true;
    }
}

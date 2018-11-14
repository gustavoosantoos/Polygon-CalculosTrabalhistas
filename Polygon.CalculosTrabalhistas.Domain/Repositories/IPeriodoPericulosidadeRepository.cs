using Polygon.CalculosTrabalhistas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Domain.Repositories
{
    public interface IPeriodoPericulosidadeRepository
    {
        void Salvar(PeriodoComPericulosidade periodo);
        List<PeriodoComPericulosidade> Obter(string numeroCartao);
    }
}

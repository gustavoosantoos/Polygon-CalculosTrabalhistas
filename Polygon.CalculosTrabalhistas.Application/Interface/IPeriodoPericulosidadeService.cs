using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Domain.Entities;
using System.Collections.Generic;

namespace Polygon.CalculosTrabalhistas.Application.Interface
{
    public interface IPeriodoPericulosidadeService
    {
        void Adicionar(AdicionarPeriodoPericulosidadeCommand command);
        List<PeriodoComPericulosidade> Obter(string numeroCartao);
        void Salvar(PeriodoComPericulosidade periodo);
    }
}

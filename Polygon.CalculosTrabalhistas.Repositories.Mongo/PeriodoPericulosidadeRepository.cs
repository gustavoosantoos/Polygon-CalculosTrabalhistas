using Polygon.CalculosTrabalhistas.Domain.Entities;
using Polygon.CalculosTrabalhistas.Domain.Repositories;
using Polygon.CalculosTrabalhistas.Repositories.Raven.Context;
using Raven.Client.Documents.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Polygon.CalculosTrabalhistas.Repositories.Raven
{
    public class PeriodoPericulosidadeRepository : IPeriodoPericulosidadeRepository
    {
        public List<PeriodoComPericulosidade> Obter(string numeroCartao)
        {
            using (var session = PolygonContext.Instance.OpenSession())
            {
                return session
                    .Query<PeriodoComPericulosidade>()
                    .Where(p => p.NumeroCartao == numeroCartao)
                    .ToList();
            }
        }

        public void Salvar(PeriodoComPericulosidade periodo)
        {
            using (var session = PolygonContext.Instance.OpenSession())
            {
                session.Store(periodo);
                session.SaveChanges();
            }
        }
    }
}

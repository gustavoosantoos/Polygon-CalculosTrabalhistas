using Polygon.CalculosTrabalhistas.Domain.Entities;
using Polygon.CalculosTrabalhistas.Domain.Repositories;
using Polygon.CalculosTrabalhistas.Repositories.Raven.Context;
using System;

namespace Polygon.CalculosTrabalhistas.Repositories.Mongo
{
    public class CalculoRepository : ICalculoRepository
    {
        public event EventHandler OnSalvarCalculo;

        public void Salvar(Calculo calculo)
        {
            using (var session = PolygonContext.Instance.OpenSession())
            {
                session.Store(calculo);
                OnSalvarCalculo?.Invoke(this, null);
            }
        }
    }
}

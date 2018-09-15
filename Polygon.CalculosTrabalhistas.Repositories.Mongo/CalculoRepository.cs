using Polygon.CalculosTrabalhistas.Domain.Entities;
using Polygon.CalculosTrabalhistas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Repositories.Mongo
{
    public class CalculoRepository : ICalculoRepository
    {
        public event EventHandler OnSalvarCalculo;

        public void Salvar(Calculo calculo)
        {
            OnSalvarCalculo?.Invoke(this, null);
            throw new NotImplementedException();
        }
    }
}

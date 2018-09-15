using Polygon.CalculosTrabalhistas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Domain.Repositories
{
    public interface ICalculoRepository
    {
        event EventHandler OnSalvarCalculo;
        void Salvar(Calculo calculo);
    }
}

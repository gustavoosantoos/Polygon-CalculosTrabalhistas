using Polygon.CalculosTrabalhistas.Domain.Entities;
using System;

namespace Polygon.CalculosTrabalhistas.Domain.Repositories
{
    public interface ICalculoRepository
    {
        event EventHandler OnSalvarCalculo;
        void Salvar(Calculo calculo);
    }
}

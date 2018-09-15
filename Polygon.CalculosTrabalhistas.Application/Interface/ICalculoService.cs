using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Domain.Entities;

namespace Polygon.CalculosTrabalhistas.Application.Interface
{
    public interface ICalculoService
    {
        Calculo RealizarCalculo(CalcularSalarioCommand command);
    }
}

using Polygon.CalculosTrabalhistas.Application.CommandObjects;

namespace Polygon.CalculosTrabalhistas.Application.Interface
{
    public interface ICalculoService
    {
        void RealizarCalculo(CalcularSalarioCommand command);
    }
}

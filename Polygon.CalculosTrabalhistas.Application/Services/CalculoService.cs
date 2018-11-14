using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Domain.Entities;
using Polygon.CalculosTrabalhistas.Domain.Repositories;

namespace Polygon.CalculosTrabalhistas.Application.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly ICalculoRepository _calculoRepository;

        public CalculoService(ICalculoRepository calculoRepository)
        {
            _calculoRepository = calculoRepository;
        }

        public Calculo RealizarCalculo(CalcularSalarioCommand command)
        {
            Funcionario funcionario = new Funcionario(command.MatriculaFuncionario, command.ValorHora);
            Calculo calculo = new Calculo(funcionario, command.HorasTrabalhadas, command.HorasComPericulosidade);

            _calculoRepository.Salvar(calculo);
            return calculo;
        }
    }
}

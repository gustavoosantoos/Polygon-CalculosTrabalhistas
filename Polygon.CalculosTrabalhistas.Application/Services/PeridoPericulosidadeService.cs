using Polygon.CalculosTrabalhistas.Application.CommandObjects;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Domain.Entities;
using Polygon.CalculosTrabalhistas.Domain.Repositories;
using System.Collections.Generic;

namespace Polygon.CalculosTrabalhistas.Application.Services
{
    public class PeridoPericulosidadeService : IPeriodoPericulosidadeService
    {
        private readonly IPeriodoPericulosidadeRepository _repository;

        public PeridoPericulosidadeService(IPeriodoPericulosidadeRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(AdicionarPeriodoPericulosidadeCommand command)
        {
            _repository.Salvar(new PeriodoComPericulosidade(command.NumeroCartao, command.HorasComPericulosidade, false));
        }

        public List<PeriodoComPericulosidade> Obter(string numeroCartao)
        {
            return _repository.Obter(numeroCartao);
        }

        public void Salvar(PeriodoComPericulosidade periodo)
        {
            _repository.Salvar(periodo);
        }
    }
}

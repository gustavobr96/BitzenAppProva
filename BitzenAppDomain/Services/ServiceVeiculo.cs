using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Services
{
    public class ServiceVeiculo : IServiceVeiculo
    {
        private readonly IRepositoryVeiculo _repoVeiculo;

        public ServiceVeiculo(IRepositoryVeiculo repoVeiculo)
        {
            _repoVeiculo = repoVeiculo;
        }

        public int Adicionar(Veiculo veiculo)
        {
            if (veiculo == null)
                return 0;

            if (veiculo.EstaConsistente())
            {
                return _repoVeiculo.Adicionar(veiculo);
            }

            return 0;
        }

        public int Atualizar(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public Veiculo ObterPorId(int id)
        {
            if (id > 0)
                return _repoVeiculo.ObterPorId(id);

            return null;
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            if (id > 0 )
                return _repoVeiculo.Remover(id);

            return -1;
        }
        public IEnumerable<Veiculo> ObterTodosPorUsuario(string user)
        {
            return _repoVeiculo.ObterTodosPorUsuario(user);
        }
        public IEnumerable<Modelo> ObterTodosModeloxMarca(int cod)
        {
            return _repoVeiculo.ObterTodosModeloxMarca(cod);
        }
        public IEnumerable<TipoVeiculo> ObterTodosTipoVeiculo()
        {
            return _repoVeiculo.ObterTodosTipoVeiculo();
        }

        public IEnumerable<TipoCombustivel> ObterTodosTipoCombustivel()
        {
            return _repoVeiculo.ObterTodosTipoCombustivel();
        }

        public IEnumerable<Marca> ObterTodasMarca()
        {
            return _repoVeiculo.ObterTodasMarca();
        }

        public void Dispose()
        {
            _repoVeiculo.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}

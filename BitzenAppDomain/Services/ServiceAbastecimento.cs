using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Services
{
    public class ServiceAbastecimento : IServiceAbastecimento
    {
        private readonly IRepositoryAbastecimento _repoAbastecimento;

        public ServiceAbastecimento(IRepositoryAbastecimento repoAbastecimento)
        {
            _repoAbastecimento = repoAbastecimento;
        }

        public IEnumerable<Abastecimento> ObterTodosPorUsuario(string user)
        {
            return _repoAbastecimento.ObterTodosPorUsuario(user);
        }
        public IEnumerable<Posto> ObterTodosPosto()
        {
            return _repoAbastecimento.ObterTodosPosto();
        }

        public int Adicionar(Abastecimento abastecimento)
        {
            throw new NotImplementedException();
        }

        public int Atualizar(Abastecimento abastecimento)
        {
            throw new NotImplementedException();
        }

     

        public Abastecimento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Abastecimento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {

            _repoAbastecimento.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}

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
            if (abastecimento == null)
                return 0;

            if (abastecimento.EstaConsistente())
            {
                return _repoAbastecimento.Adicionar(abastecimento);
            }

            return 0;
        }

        public int Atualizar(Abastecimento abastecimento)
        {
            if (abastecimento == null)
                return 0;

            if (abastecimento.EstaConsistente())
            {
                return _repoAbastecimento.Atualizar(abastecimento);
            }

            return 0;
        }

     

        public Abastecimento ObterPorId(int id)
        {
            if (id > 0)
                return _repoAbastecimento.ObterPorId(id);

            return null;
        }

        public IEnumerable<Abastecimento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            if (id > 0)
                return _repoAbastecimento.Remover(id);

            return -1;
        }
        public void Dispose()
        {

            _repoAbastecimento.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}

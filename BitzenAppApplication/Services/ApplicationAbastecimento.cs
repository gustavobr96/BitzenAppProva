using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitzenAppApplication.Services
{
    public class ApplicationAbastecimento : IApplicationAbastecimento
    {

        private readonly IServiceAbastecimento _serviceAbastecimento;

        public ApplicationAbastecimento(IServiceAbastecimento serviceAbastecimento)
        {
            _serviceAbastecimento = serviceAbastecimento;
        }

        public IEnumerable<AbastecimentoDto> ObterTodosPorUsuario(string user)
        {
            var con = _serviceAbastecimento.ObterTodosPorUsuario(user);
            return con.Select(e => (AbastecimentoDto)e);
        }

        public IEnumerable<PostoDto> ObterTodosPosto()
        {
            var con = _serviceAbastecimento.ObterTodosPosto();
            return con.Select(e => (PostoDto)e);
        }

        public int Adicionar(AbastecimentoDto entity)
        {
            throw new NotImplementedException();
        }

        public int Atualizar(AbastecimentoDto entity)
        {
            throw new NotImplementedException();
        }

    

        public AbastecimentoDto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AbastecimentoDto> ObterTodos()
        {
            throw new NotImplementedException();
        }

     

        public int Remover(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _serviceAbastecimento.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

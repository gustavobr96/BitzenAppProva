using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using BitzenAppDomain.Entities;
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
            Abastecimento abastecimento = new Abastecimento();
            abastecimento.PrepararDadosParaInserir(entity.NKmAbastecimento, entity.NLitroAbastecimento, entity.VVlrPago, entity.DAbastecimento, entity.NCodPosto, entity.NCodUsuarioInc, entity.NCodTipoCombustivel, entity.NCodTipoVeiculo, entity.NCodVeiculo);
            return _serviceAbastecimento.Adicionar(abastecimento);
        }

        public int Atualizar(AbastecimentoDto entity)
        {
            Abastecimento abastecimento = new Abastecimento();
            abastecimento.PrepararDadosParaAtualizar(entity.NCodAbastecimento,entity.NKmAbastecimento, entity.NLitroAbastecimento, entity.VVlrPago, entity.DAbastecimento, entity.NCodPosto, entity.NCodUsuarioInc, entity.NCodTipoCombustivel, entity.NCodTipoVeiculo, entity.NCodVeiculo);
            return _serviceAbastecimento.Atualizar(abastecimento);
        }
        public int Remover(int id)
        {
            return _serviceAbastecimento.Remover(id);
        }


        public AbastecimentoDto ObterPorId(int id)
        {
            return (AbastecimentoDto)_serviceAbastecimento.ObterPorId(id);
        }

        public IEnumerable<AbastecimentoDto> ObterTodos()
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

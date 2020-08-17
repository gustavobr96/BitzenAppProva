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
    public class ApplicationVeiculo : IApplicationVeiculo
    {
        private readonly IServiceVeiculo _serviceVeiculo;

        public ApplicationVeiculo(IServiceVeiculo serviceVeiculo)
        {
            _serviceVeiculo = serviceVeiculo;
        }

        public int Adicionar(VeiculoDto entity)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.PrepararDadosParaInserir(entity.NCodMarca, entity.NCodModelo, entity.DAno, entity.CPlaca, entity.NCodTipoVeiculo, entity.NCodTipoCombustivel,entity.CQuilometragem, entity.NCodUsuarioResp);
            return _serviceVeiculo.Adicionar(veiculo);
        }

        public int Atualizar(VeiculoDto entity)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.PrepararDadosParaAtualizar(entity.NCodVeiculo,entity.NCodMarca, entity.NCodModelo, entity.DAno, entity.CPlaca, entity.NCodTipoVeiculo, entity.NCodTipoCombustivel, entity.CQuilometragem, entity.NCodUsuarioResp);
            return _serviceVeiculo.Atualizar(veiculo);
        }

        
        public VeiculoDto ObterPorId(int id)
        {
            return (VeiculoDto)_serviceVeiculo.ObterPorId(id);
        }

        public IEnumerable<VeiculoDto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            return _serviceVeiculo.Remover(id);
        }
        public IEnumerable<VeiculoDto> ObterTodosPorUsuario(string user)
        {
            var con = _serviceVeiculo.ObterTodosPorUsuario(user);
            return con.Select(e => (VeiculoDto)e);
        }

        public IEnumerable<MarcaDto> ObterTodasMarca()
        {
            var con = _serviceVeiculo.ObterTodasMarca();
            return con.Select(e => (MarcaDto)e);
        }

        public IEnumerable<TipoVeiculoDto> ObterTodosTipoVeiculo()
        {
            var con = _serviceVeiculo.ObterTodosTipoVeiculo();
            return con.Select(e => (TipoVeiculoDto)e);
        }

        public IEnumerable<TipoCombustivelDto> ObterTodosTipoCombustivel()
        {
            var con = _serviceVeiculo.ObterTodosTipoCombustivel();
            return con.Select(e => (TipoCombustivelDto)e);
        }

        public void Dispose()
        {
            _serviceVeiculo.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ModeloDto> ObterTodosModeloxMarca(int cod)
        {
            var con = _serviceVeiculo.ObterTodosModeloxMarca(cod);
            return con.Select(e => (ModeloDto)e);
        }

   
    }
}

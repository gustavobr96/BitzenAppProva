using BitzenAppApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Interfaces
{
    public interface  IApplicationVeiculo : IDisposable
    {
        IEnumerable<VeiculoDto> ObterTodosPorUsuario(string user);
        IEnumerable<MarcaDto> ObterTodasMarca();
        IEnumerable<ModeloDto> ObterTodosModeloxMarca(int cod);
        IEnumerable<TipoVeiculoDto> ObterTodosTipoVeiculo();
        IEnumerable<TipoCombustivelDto> ObterTodosTipoCombustivel();
        int Adicionar(VeiculoDto entity);
        int Atualizar(VeiculoDto entity);
        VeiculoDto ObterPorId(int id);
        IEnumerable<VeiculoDto> ObterTodos();
        int Remover(int id);
    }
}

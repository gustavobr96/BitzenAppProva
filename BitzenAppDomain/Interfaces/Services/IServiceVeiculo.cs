using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Services
{
    public interface IServiceVeiculo: IDisposable
    {
        int Adicionar(Veiculo veiculo);
        int Atualizar(Veiculo veiculo);
        int Remover(int id);
        IEnumerable<Veiculo> ObterTodos();
        Veiculo ObterPorId(int id);
        IEnumerable<Veiculo> ObterTodosPorUsuario(string user);
        IEnumerable<Modelo> ObterTodosModeloxMarca(int cod);
        IEnumerable<Marca> ObterTodasMarca();
        IEnumerable<TipoVeiculo> ObterTodosTipoVeiculo();
        IEnumerable<TipoCombustivel> ObterTodosTipoCombustivel();
    }
}

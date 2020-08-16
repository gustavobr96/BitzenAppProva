using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Repositories
{
    public interface IRepositoryVeiculo : IRepository<Veiculo>
    {
        IEnumerable<Veiculo> ObterTodosPorUsuario(string user);
        IEnumerable<Modelo> ObterTodosModeloxMarca(int cod);
        IEnumerable<Marca> ObterTodasMarca();
        IEnumerable<TipoVeiculo> ObterTodosTipoVeiculo();
        IEnumerable<TipoCombustivel> ObterTodosTipoCombustivel();
    }
}

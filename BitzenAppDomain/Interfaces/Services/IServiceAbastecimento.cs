using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Services
{
    public interface IServiceAbastecimento : IDisposable
    {
        int Adicionar(Abastecimento abastecimento);
        int Atualizar(Abastecimento abastecimento);
        int Remover(int id);
        IEnumerable<Abastecimento> ObterTodos();
        IEnumerable<Posto> ObterTodosPosto();
        Abastecimento ObterPorId(int id);
        IEnumerable<Abastecimento> ObterTodosPorUsuario(string user);
    }
}

using BitzenAppApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Interfaces
{
    public interface  IApplicationAbastecimento : IDisposable
    {
        IEnumerable<AbastecimentoDto> ObterTodosPorUsuario(string user);
        int Adicionar(AbastecimentoDto entity);
        int Atualizar(AbastecimentoDto entity);
        AbastecimentoDto ObterPorId(int id);
        IEnumerable<AbastecimentoDto> ObterTodos();
        IEnumerable<PostoDto> ObterTodosPosto();
        int Remover(int id);
    }
}

using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Services
{
    public interface IServiceUsuario : IDisposable
    {
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorId(int id);
        Usuario AutenticarUsuario(Usuario usuario);
        int Adicionar(Usuario usuario);
    }
}

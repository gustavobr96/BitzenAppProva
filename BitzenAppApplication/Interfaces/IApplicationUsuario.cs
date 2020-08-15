using BitzenAppApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Interfaces
{
    public interface IApplicationUsuario : IDisposable
    {
        UsuarioDto AutenticarUsuario(UsuarioDto usuario);
        int Adicionar(UsuarioDto usuario);
    }
}

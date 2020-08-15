using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepository<Usuario>
    {
        Usuario AutenticarUsuario(Usuario usuario);
    }
}

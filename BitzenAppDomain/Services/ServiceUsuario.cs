using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IRepositoryUsuario _repoUsuario;

        public ServiceUsuario(IRepositoryUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public Usuario AutenticarUsuario(Usuario usuario)
        {
            if (usuario == null)
                return null;

            if (usuario.EstaConsistente())
            {
                return _repoUsuario.AutenticarUsuario(usuario);
            }

            return null;
        }
        public int Adicionar(Usuario usuario)
        {
            if (usuario == null)
                return 0;

            if (usuario.EstaConsistente())
            {
                return _repoUsuario.Adicionar(usuario);
            }

            return 0;
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _repoUsuario.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}

using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Services;
using CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Services
{
    public class ApplicationUsuario : IApplicationUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;

        public ApplicationUsuario(IServiceUsuario serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

       

        public UsuarioDto AutenticarUsuario(UsuarioDto usuario)
        {
            var usuarioAuth = new Usuario();
            usuarioAuth.PrepararParaAutenticar(usuario.CEmail, usuario.CSenha);

            var res = _serviceUsuario.AutenticarUsuario(usuarioAuth);

            if (res == null)
                return null;


            var resDto = (UsuarioDto)res;


            return resDto;
        }
        public int Adicionar(UsuarioDto entity)
        {
            Usuario usuario = new Usuario();

            usuario.PrepararDadosParaInserir(entity.CNome, entity.CEmail, entity.CSenha);
            return _serviceUsuario.Adicionar(usuario);
        }


        public void Dispose()
        {
            _serviceUsuario.Dispose();
            GC.SuppressFinalize(this);
        }

     
    }
}

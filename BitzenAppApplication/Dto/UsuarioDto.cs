using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class UsuarioDto
    {
        public string NCodUsuario { get; set; }
        public string CNome { get;  set; }
        public string CSenha { get; set; }
        public string CEmail { get; set; }

        public static explicit operator UsuarioDto(Usuario e)
        {
            return new UsuarioDto
            {
                NCodUsuario = e.NCodUsuario.ToString(),
                CNome = e.CNome,
                CEmail = e.CEmail
            };
        }

    }
}

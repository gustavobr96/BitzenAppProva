using BitzenAppDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BitzenAppDomain.Entities
{
    [Table("ger_usuario")]
    public class Usuario : EntityBase
    {
        public int NCodUsuario { get; private set; }
        public string CNome { get; private set; }
        public string CSenha { get; private set; }
        public string CEmail { get; private set; }

        public Usuario()
        {
            CNome = "";
            NCodUsuario = 0;
            CSenha = "";
            CEmail = "";
        }

        public void PrepararDadosParaInserir(string cNome, string cEmail, string cSenha)
        {
            ValidarNome(cNome);
            ValidarEmail(cEmail);
            ValidarSenha(cSenha);

        }

        public void PrepararParaAutenticar(string email, string senha)
        {
            ValidarEmail(email);
            ValidarSenha(senha);
        }

        #region Validações

        private void ValidarNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                if (nome.Length > 100)
                    ListaErros.Add("Campo excede o máximo permitido!");
                else
                {
                    CNome = nome.Trim();
                }

            }
            else
            {
                ListaErros.Add("Campo obrigatório!");
            }
        }


        private void ValidarEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (email.Length > 100)
                    ListaErros.Add("Campo excede o máximo permitido!");
                else
                {
                    CEmail = email.Trim();
                }

            }
            else
            {
                ListaErros.Add("Campo obrigatório!");
            }
        }

        private void ValidarSenha(string senha)
        {
            if (!string.IsNullOrEmpty(senha))
            {
                if (senha.Length > 40)
                    ListaErros.Add("Campo excede o máximo permitido!");
                else
                {
                    CSenha = senha.Trim();
                }

            }
            else
            {
                ListaErros.Add("Campo obrigatório!");
            }
        }


        #endregion


        public override bool EstaConsistente()
        {
            return !ListaErros.Any();
        }
    }
}

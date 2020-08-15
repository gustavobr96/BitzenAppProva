using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppInfra.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitzenAppInfra.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepositoryUsuario(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public int Adicionar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public int Atualizar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario AutenticarUsuario(Usuario usuario)
        {
            using (var connection = _dbConnectionString.Connection())
            {

                connection.Open();
        
                    string sql = @"SELECT 
                                n_cod_usuario,
                                c_email,
                                c_senha,
                                c_nome
                           FROM ger_usuario
                           WHERE c_email = @CEmail 
                           AND c_senha = @CSenha";

                var usuarioRes = connection.Query<Usuario>(sql, usuario).FirstOrDefault();
      
               
                return usuarioRes;
            }
        }


        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbConnectionString.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

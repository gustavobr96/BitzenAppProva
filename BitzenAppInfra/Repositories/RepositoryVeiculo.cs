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
    public class RepositoryVeiculo : IRepositoryVeiculo
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepositoryVeiculo(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public IEnumerable<Veiculo> ObterTodosPorUsuario(string user)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
                                    gv.n_cod_veiculo,
                                    gv.n_cod_marca,
                                    gv.n_cod_modelo,
                                    gv.d_ano,
                                    gv.c_placa,
                                    gv.n_cod_tipo_veiculo,
                                    gv.n_cod_combustivel,
                                    gv.n_quilometragem,
                                    gv.n_cod_usuario,
                                    gm.c_descricao as marca,
                                    gmod.c_descricao as modelo,
                                    gtc.c_descricao as combustivel,
                                    gtv.c_descricao as tipoveiculo
                               FROM ger_veiculo gv
                               INNER JOIN ger_marca gm on gv.n_cod_marca = gm.n_cod_marca
                               INNER JOIN ger_modelo gmod on gv.n_cod_modelo = gmod.n_cod_modelo
                               INNER JOIN ger_tipo_combustivel gtc on gv.n_cod_combustivel = gtc.n_cod_combustivel
                               INNER JOIN ger_tipo_veiculo gtv on gv.n_cod_tipo_veiculo = gtv.n_cod_tipo_veiculo 
                              WHERE gv.n_cod_usuario = @usuario";

                connection.Open();
   
                var items = connection.Query<dynamic>(sql, new
                {
                    usuario = int.Parse(user)
                });
                Modelo modelo = null;
                Marca marca = null;
                TipoCombustivel combustivel = null;
                TipoVeiculo tipoveiculo = null;
                List<Veiculo> veiculos = new List<Veiculo>();
                Usuario usuario = new Usuario();
                Veiculo veiculo = null;

                foreach (var item in items)
                {
                    modelo = new Modelo();
                    marca = new Marca();
                    combustivel = new TipoCombustivel();
                    tipoveiculo = new TipoVeiculo();
                    veiculo = new Veiculo();

                    modelo.setCDescricao(item.modelo);
                    modelo.setNCodModelo(item.n_cod_modelo);
                    marca.setCDescricao(item.marca);
                    marca.setNCodMarca(item.n_cod_marca);
                    combustivel.setCDescricao(item.combustivel);
                    combustivel.setNCodCombustivel(item.n_cod_combustivel);
                    tipoveiculo.setCDescricao(item.tipoveiculo);
                    tipoveiculo.setNCodTipoVeiculo(item.n_cod_tipo_veiculo);

                    veiculo.setModelo(modelo);
                    veiculo.setMarca(marca);
                    veiculo.setTipoCombustivel(combustivel);
                    veiculo.setTipoVeiculo(tipoveiculo);

                    veiculo.setNCodVeiculo(item.n_cod_veiculo);
                    veiculo.setDAno(item.d_ano);
                    veiculo.setCPlaca(item.c_placa);
                    veiculo.setCQuilometragem(item.n_quilometragem);
                    veiculos.Add(veiculo);

                }

                return veiculos;
            }
        }

        public IEnumerable<Marca> ObterTodasMarca()
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
	                                n_cod_marca,
                                    c_descricao  
                                FROM
	                                ger_marca
                               Order by c_descricao 
                    ";


                connection.Open();
                return connection.Query<Marca>(sql);
            }
        }

        public IEnumerable<Modelo> ObterTodosModeloxMarca(int cod)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                               SELECT 
                                    DISTINCT (gm.c_descricao),
	                                gmm.n_cod_modelo,
                                    gmm.n_cod_marca
							   FROM
	                                ger_marca_x_ger_modelo gmm
                               INNER JOIN ger_modelo gm on gmm.n_cod_modelo = gm.n_cod_modelo
                               WHERE gmm.n_cod_marca = @Cod
                               Order by gm.c_descricao 
                    ";


                connection.Open();
                return connection.Query<Modelo>(sql, new { Cod = cod });
            }
        }

        public IEnumerable<TipoVeiculo> ObterTodosTipoVeiculo()
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
	                                n_cod_tipo_veiculo,
                                    c_descricao  
                                FROM
	                                ger_tipo_veiculo
                               Order by c_descricao 
                    ";


                connection.Open();
                return connection.Query<TipoVeiculo>(sql);
            }
        }

        public IEnumerable<TipoCombustivel> ObterTodosTipoCombustivel()
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
	                                n_cod_combustivel,
                                    c_descricao  
                                FROM
	                                ger_tipo_combustivel
                               Order by c_descricao 
                    ";


                connection.Open();
                return connection.Query<TipoCombustivel>(sql);
            }
        }

        public int Adicionar(Veiculo entity)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                string sql = @"INSERT INTO
                            ger_veiculo
                            (
                                n_cod_marca,
                                n_cod_modelo,
                                c_placa,
                                n_cod_tipo_veiculo,
                                n_cod_combustivel,
                                n_quilometragem,
                                n_cod_usuario,
                                d_ano
                            )
                        VALUES
                            (
                                @NCodMarca,
                                @NCodModelo,
                                @CPlaca,
                                @NCodTipoVeiculo,
                                @NCodCombustivel,
                                @NQuilometragem,
                                @NCodUsuario,
                                @DAno
                            )RETURNING n_cod_veiculo";

                return connection.ExecuteScalar<int>(sql, new {NCodMarca = entity.Marca.NCodMarca, NCodModelo = entity.Modelo.NCodModelo, CPlaca = entity.CPlaca,
                NCodTipoVeiculo = entity.TipoVeiculo.NCodTipoVeiculo, NCodCombustivel = entity.TipoCombustivel.NCodCombustivel, NQuilometragem = entity.CQuilometragem,
                NCodUsuario = entity.UsuarioResp.NCodUsuario, DAno = entity.DAno});
            }
        }

        public int Atualizar(Veiculo entity)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                string sql = @"UPDATE 
                                ger_veiculo
                            SET
                                n_cod_marca = @NCodMarca,
                                n_cod_modelo = @NCodModelo,
                                c_placa = @CPlaca,
                                n_cod_tipo_veiculo = @NCodTipoVeiculo,
                                n_cod_combustivel = @NCodCombustivel,
                                n_quilometragem = @NQuilometragem,
                                d_ano = @DAno
                            WHERE 
                                n_cod_veiculo = @NCodVeiculo ;";

                return connection.Execute(sql, new { NCodMarca = entity.Marca.NCodMarca, NCodModelo = entity.Modelo.NCodModelo, CPlaca = entity.CPlaca,
                    NCodTipoVeiculo = entity.TipoVeiculo.NCodTipoVeiculo, NQuilometragem = entity.CQuilometragem, DAno = entity.DAno,
                    NCodCombustivel = entity.TipoCombustivel.NCodCombustivel, NCodVeiculo = entity.NCodVeiculo });

            }
        }

     
        public Veiculo ObterPorId(int id)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();
                Veiculo v = null;
                var sql = @"SELECT 
	                           *
                        FROM 
                            ger_veiculo 
                        WHERE 
                            n_cod_veiculo = @id";

                var items = connection.Query<dynamic>(sql, new { id = id }).FirstOrDefault();
                if (items != null)
                {
                    v = new Veiculo();
                    Modelo modelo = new Modelo();
                    Marca marca = new Marca();
                    TipoCombustivel combustivel = new TipoCombustivel();
                    TipoVeiculo tipoveiculo = new TipoVeiculo();

                    modelo.setNCodModelo(items.n_cod_modelo);
                    marca.setNCodMarca(items.n_cod_marca);
                    combustivel.setNCodCombustivel(items.n_cod_combustivel);
                    tipoveiculo.setNCodTipoVeiculo(items.n_cod_tipo_veiculo);
                    v.setNCodVeiculo(items.n_cod_veiculo);
                    v.setCPlaca(items.c_placa);
                    v.setCQuilometragem(items.n_quilometragem);
                    v.setDAno(items.d_ano);
                    v.setModelo(modelo);
                    v.setMarca(marca);
                    v.setTipoCombustivel(combustivel);
                    v.setTipoVeiculo(tipoveiculo);
                }
                return v;

              
            }
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            throw new NotImplementedException();
        }

       

        public int Remover(int id)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();

                string sql = @"DELETE 
                                    FROM
                                ger_veiculo
                            WHERE 
                                n_cod_veiculo = @id;";

                return connection.Execute(sql, new { id = id });

            }
        }

        public void Dispose()
        {
            _dbConnectionString.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

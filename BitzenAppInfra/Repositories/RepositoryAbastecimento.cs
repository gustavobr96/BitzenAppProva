using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppInfra.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppInfra.Repositories
{
    public class RepositoryAbastecimento : IRepositoryAbastecimento
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepositoryAbastecimento(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public int Adicionar(Veiculo entity)
        {
            throw new NotImplementedException();
        }

        public int Atualizar(Veiculo entity)
        {
            throw new NotImplementedException();
        }

  
        public Veiculo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Posto> ObterTodosPosto()
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
	                                n_cod_posto,
                                    c_descricao  
                                FROM
	                                ger_posto
                               Order by c_descricao 
                    ";


                connection.Open();
                return connection.Query<Posto>(sql);
            }
        }

        public IEnumerable<Abastecimento> ObterTodosPorUsuario(string user)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                string sql = @"
                                SELECT 
                                    ga.n_cod_abastecimento,
                                    ga.n_km_abastecimento,
                                    ga.n_litro_abastecimento,
                                    ga.v_vlr_pago,
                                    ga.d_abastecimento,
                                    ga.n_cod_posto,
                                    ga.n_cod_combustivel,
                                    ga.n_cod_veiculo,
                                    gp.c_descricao as posto,
                                    gu.c_nome as usuario,
                                    gtc.c_descricao combustivel,
                                    gtv.c_descricao veiculo,
                                    ga.n_cod_veiculo,
                                    gv.c_placa
                               FROM ger_abastecimento ga
                               INNER JOIN ger_posto gp on ga.n_cod_posto = gp.n_cod_posto
                               INNER JOIN ger_usuario gu on ga.n_cod_usuario = gu.n_cod_usuario
                               INNER JOIN ger_tipo_combustivel gtc on ga.n_cod_combustivel = gtc.n_cod_combustivel
                               INNER JOIN ger_tipo_veiculo gtv on ga.n_cod_tipo_veiculo = gtv.n_cod_tipo_veiculo
                               INNER JOIN ger_veiculo gv on gv.n_cod_veiculo = ga.n_cod_veiculo
                              WHERE ga.n_cod_usuario = @usuario";

                connection.Open();

                var items = connection.Query<dynamic>(sql, new
                {
                    usuario = int.Parse(user)
                });
                Posto posto = null;
                TipoCombustivel combustivel = null;
                TipoVeiculo tipoveiculo = null;
                Veiculo veiculo = null;
                List<Abastecimento> Abastecimentos = new List<Abastecimento>();
                Abastecimento a;

                foreach (var item in items)
                {
                    posto = new Posto();
                    combustivel = new TipoCombustivel();
                    tipoveiculo = new TipoVeiculo();
                    a = new Abastecimento();
                    veiculo = new Veiculo();

                    posto.setCDescricao(item.posto);
                    posto.setNCodPosto(item.n_cod_posto);
                    combustivel.setCDescricao(item.combustivel);
                    combustivel.setNCodCombustivel(item.n_cod_combustivel);
                    tipoveiculo.setCDescricao(item.veiculo);
                    tipoveiculo.setNCodTipoVeiculo(item.n_cod_veiculo);
                    veiculo.setCPlaca(item.c_placa);
                    veiculo.setNCodVeiculo(item.n_cod_veiculo);

                    a.setVeiculo(veiculo);
                    a.setPosto(posto);
                    a.setTipoCombustivel(combustivel);
                    a.setTipoVeiculo(tipoveiculo);
                    a.setNCodAbastecimento(item.n_cod_abastecimento);
                    a.setDAbastecimento(item.d_abastecimento);
                    a.setNKmAbastecimento(item.n_km_abastecimento);
                    a.setNLitroAbastecimento(item.n_litro_abastecimento);
                    a.setVVlrPago(item.v_vlr_pago);
                    Abastecimentos.Add(a);

                }

                return Abastecimentos;
            }
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

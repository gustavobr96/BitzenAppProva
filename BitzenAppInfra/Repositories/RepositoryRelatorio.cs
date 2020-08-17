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
    public class RepositoryRelatorio : IRepositoryRelatorio
    {
        private readonly IDbConnectionString _dbConnectionString;

        public RepositoryRelatorio(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public Relatorio ObterRelatorioPorUsuarioTipos(string user, int tipo)
        {
            using (var connection = _dbConnectionString.Connection())
            {
                connection.Open();
                var sql = @"SELECT 
                             CAST( SUM(";
                if (tipo == 1)
                    sql += "n_litro_abastecimento";
                if (tipo == 2)
                    sql += "v_vlr_pago";

                sql+=@") as double precision) as litros,
                             CAST( date_part('month', d_abastecimento) as integer) as n_mes,
                             case
                                when date_part('month', d_abastecimento) = 1 
	                              then 'Janeiro'
	                            when date_part('month', d_abastecimento) = 2
	                              then 'Fevereiro'
	                            when date_part('month', d_abastecimento) = 3
	                              then 'Março'
	                            when date_part('month', d_abastecimento) = 4
	                              then 'Abril'
	                            when date_part('month', d_abastecimento) = 5
	                              then 'Maio'
	                            when date_part('month', d_abastecimento) = 6
	                              then 'Junho'
	                            when date_part('month', d_abastecimento) = 7
	                              then 'Julho'
	                            when date_part('month', d_abastecimento) = 8
	                              then 'agosto'
	                            when date_part('month', d_abastecimento) = 9
	                              then 'Setembro'
	                            when date_part('month', d_abastecimento) = 10
	                              then 'Outubro'
	                            when date_part('month', d_abastecimento) = 11
	                              then 'Novembro'
	                            when date_part('month', d_abastecimento) = 12
	                              then 'Dezembro'
                             end as c_mes
                           FROM ger_abastecimento
                           WHERE d_abastecimento > (now() - interval '1 year') and n_cod_usuario = @user
                           GROUP BY date_part('month', d_abastecimento) order by n_mes";

                var items = connection.Query<dynamic>(sql, new { user = int.Parse(user) });
                List<Mes> meses = new List<Mes>();
                Mes mes;
                Relatorio relatorio = new Relatorio();
                foreach (var item in items)
                {
                    mes = new Mes();
                    mes.setNCodMes(item.n_mes);
                    mes.setValor(item.litros);
                    mes.setCDescricao(item.c_mes);
                    meses.Add(mes);
                }
                relatorio.setMeses(meses);
                return relatorio;
            }
        }
        
        public void Dispose()
        {
            _dbConnectionString.Dispose();
            GC.SuppressFinalize(this);
        }

    

        #region Metodos não utilziaveis 
        public int Adicionar(Relatorio entity)
        {
            throw new NotImplementedException();
        }

        public int Atualizar(Relatorio entity)
        {
            throw new NotImplementedException();
        }



        public Relatorio ObterPorId(int id)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Relatorio> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int Remover(int id)
        {
            throw new NotImplementedException();
        }

       
        #endregion
    }
}

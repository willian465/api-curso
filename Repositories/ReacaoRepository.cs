using Dapper;
using Gama.Curso.Arguments;
using Gama.Curso.Models;
using Gama.Curso.Repositories.Base;
using Gama.Curso.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Gama.Curso.Repositories
{
    public class ReacaoRepository : Postgree, IReacaoRepository
    {
        public async Task DeletarReacao(int codigoReacao)
        {
            const string sql = @"UPDATE FROM REACAO REA SET REA.ATIVO = FALSE WHERE REA.COD_REACAO @CodigoReacao";

            using IDbConnection connection = GetConnection();
            await connection.ExecuteAsync(sql, new { CodigoReacao = codigoReacao });
        }

        public async Task<int> RegistrarReacao(ReacaoArgument argument)
        {
            const string sql = @"INSERT INTO REACAO 
                                  (COD_TPO_ENTIDADE, COD_EXTERNO, COD_TPO_REACAO)
                                VALUES
                                  (@CodigoTipoEntidade, @CodigoExterno, @CodigoTipoReacao)
                                RETURNING COD_REACAO";

            using IDbConnection connection = GetConnection();
            return await connection.ExecuteScalarAsync<int>(sql, argument);
        }
        public async Task<IEnumerable<ReacaoEntidadeModel>> BuscarReacoes(List<int> codigosExterno)
        {
            string sql = @"  SELECT RE.COD_EXTERNO CodigoExterno,
                                    RE.COD_TPO_ENTIDADE CodigoTipoEntidade,
                                    RE.COD_REACAO CodigoReacao,
                                    RE.COD_TPO_REACAO CodigoTipoReacao                                    
                               FROM REACAO RE 

                                        /**where**/";

            SqlBuilder sqlBuilder = new SqlBuilder();
            Template template = sqlBuilder.AddTemplate(sql);

            sqlBuilder.Where("RE.ATIVO");
            if (codigosExterno.Any())
                sqlBuilder.Where("RE.COD_EXTERNO = ANY(@CodigosExterno)", new { codigosExterno });
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    Dictionary<int, ReacaoEntidadeModel> lookup = new Dictionary<int, ReacaoEntidadeModel>();
                    IEnumerable<ReacaoEntidadeModel> reacoesEntidade = await connection.QueryAsync(template.RawSql,
                         new[] {
                                    typeof(ReacaoEntidadeModel),
                                    typeof(ReacaoModel)
                         },
                         obj =>
                         {
                             ReacaoEntidadeModel reacaoEntidade = new ReacaoEntidadeModel();
                             ReacaoEntidadeModel reacaoEntidadeTemp = obj[0] as ReacaoEntidadeModel;
                             ReacaoModel reacao = obj[1] as ReacaoModel;

                             if (!lookup.TryGetValue(reacaoEntidadeTemp.CodigoExterno, out reacaoEntidade))
                             {
                                 reacaoEntidadeTemp.Reacoes = new List<ReacaoModel>();
                                 if (reacao != null)
                                     reacaoEntidadeTemp.Reacoes.Add(reacao);
                                 lookup.Add(reacaoEntidadeTemp.CodigoExterno, reacaoEntidadeTemp);
                                 reacaoEntidade = reacaoEntidadeTemp;
                             }
                             else
                             {
                                 if (reacao != null)
                                     reacaoEntidade.Reacoes.Add(reacao);
                             }

                             return reacaoEntidade;
                         },
                         template.Parameters, null, true, splitOn: "CodigoExterno,CodigoReacao");

                    return lookup.Values;
                }
            }

            catch (Exception e)
            {
                return Enumerable.Empty<ReacaoEntidadeModel>();
            }

        }
    }
}

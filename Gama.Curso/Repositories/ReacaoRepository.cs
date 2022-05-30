using Dapper;
using Gama.Curso.Arguments;
using Gama.Curso.Repositories.Base;
using Gama.Curso.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

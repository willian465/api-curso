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
    public class AulaRepository : Postgree, IAulaRepository
    {
        public async Task<int> CriarAula(AulaArgument argument)
        {
            const string sql = @"INSERT INTO AULA
                                  (TITULO_AULA,
                                   DESCRICAO_AULA,
                                   LINK_AULA,
                                   ATIVO)
                                VALUES
                                  (@TituloAula, @DescricaoAula, @LinkAula, TRUE)
                                RETURNING COD_AULA";

            using IDbConnection connection = GetConnection();
            return await connection.ExecuteScalarAsync<int>(sql, argument);

        }
    }
}

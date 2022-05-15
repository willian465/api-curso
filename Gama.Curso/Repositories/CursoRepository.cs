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
    public class CursoRepository : Postgree, ICursoRespository
    {
        public async Task<IEnumerable<CursoAulasModel>> BuscarCursos(int codigoCurso = 0)
        {
            string sql = @"  SELECT CUR.COD_CURSO CodigoCurso,
                                    CUR.NOM_CURSO NomeCurso,
                                    CUR.NOM_PROFESSOR NomeProfessor,
                                    CUR.DESCRICAO_CURSO DescricaoCurso,
                                    CUR.CAMINHO_CAPA CaminhoCapa,
                                    CUR.DAT_CADASTRO DataCadastro,
                                    AL.COD_AULA CodigoAula,
                                    AL.TITULO_AULA TituloAula, 
                                    AL.LINK_AULA LinkAula,
                                    AL.DESCRICAO_AULA DescricaoAula,
                                    AL.ATIVO Ativo,
                                    AC.ORDEM Ordem,
                                    AL.DAT_CADASTRO DataCadastro
                               FROM CURSO CUR 
                                    LEFT JOIN AULA_CURSO AC ON AC.COD_CURSO = CUR.COD_CURSO AND AC.ATIVO
                                    LEFT JOIN AULA AL ON AL.COD_AULA = AC.COD_AULA AND AL.ATIVO

                                        /**where**/";

            SqlBuilder sqlBuilder = new SqlBuilder();
            Template template = sqlBuilder.AddTemplate(sql);

            sqlBuilder.Where("CUR.ATIVO");

            if (codigoCurso > 0)
                sqlBuilder.Where("CUR.COD_CURSO = @CodigoCurso", new { codigoCurso });
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    Dictionary<int, CursoAulasModel> lookup = new Dictionary<int, CursoAulasModel>();
                    IEnumerable<CursoAulasModel> cursosAulas = await connection.QueryAsync(template.RawSql,
                         new[] {
                                    typeof(CursoAulasModel),
                                    typeof(AulaModel)
                         },
                         obj =>
                         {
                             CursoAulasModel cursoAula = new CursoAulasModel();
                             CursoAulasModel cursoAulaTemp = obj[0] as CursoAulasModel;
                             AulaModel aula = obj[1] as AulaModel;

                             if (!lookup.TryGetValue(cursoAulaTemp.CodigoCurso, out cursoAula))
                             {
                                 cursoAulaTemp.Aulas = new List<AulaModel>();
                                 if (aula != null)
                                     cursoAulaTemp.Aulas.Add(aula);
                                 lookup.Add(cursoAulaTemp.CodigoCurso, cursoAulaTemp);
                                 cursoAula = cursoAulaTemp;
                             }
                             else
                             {
                                 if (aula != null)
                                     cursoAula.Aulas.Add(aula);
                             }

                             return cursoAula;
                         },
                         template.Parameters, null, true, splitOn: "CodigoCurso,CodigoAula");

                    return lookup.Values;
                }
            }

            catch (Exception e)
            {
                return Enumerable.Empty<CursoAulasModel>();
            }

        }


        public async Task<int> CriarCurso(CursoArgument argument)
        {
            const string sql = @"INSERT INTO CURSO
                                    (NOM_CURSO,
                                     CAMINHO_CAPA,
                                     NOM_PROFESSOR,
                                     DESCRICAO_CURSO,
                                     ATIVO)
                                VALUES
                                    (@NomeCurso, @CaminhoCapa, @NomeProfessor, @DescricaoCurso, TRUE)
                                RETURNING COD_CURSO";

            using (IDbConnection connection = GetConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, argument);
            }
        }

        public async Task DeletarAulaCurso(int codigoCurso, int codigoAula)
        {
            const string sql = @"UPDATE AULA_CURSO SET ATIVO = FALSE WHERE COD_CURSO = @CodigoCurso AND COD_AULA = @CodigoAula";

            using (IDbConnection connection = GetConnection())
            {
                await connection.ExecuteAsync(sql, new { CodigoCurso = codigoCurso, CodigoAula = codigoAula });
            }
        }
        public async Task DeletarCurso(int codigoCurso)
        {
            const string sql = @"UPDATE CURSO SET ATIVO = FALSE WHERE COD_CURSO = @CodigoCurso";

            using (IDbConnection connection = GetConnection())
            {
                await connection.ExecuteAsync(sql, new { CodigoCurso = codigoCurso });
            }
        }

        public async Task RegistrarAulaCurso(AulaCursoArgument argument)
        {
            const string sql = @"INSERT INTO AULA_CURSO (COD_CURSO, COD_AULA, ORDEM) VALUES (@CodigoCurso, @CodigoAula, @Ordem)";

            using (IDbConnection connection = GetConnection())
            {
                await connection.ExecuteAsync(sql, argument);
            }
        }
        public async Task<IEnumerable<DadosCursoModel>> BuscarDadosCursos()
        {
            const string sql = @"SELECT CUR.COD_CURSO CodigoCurso,
   	                                    CUR.NOM_CURSO NomeCurso,
   	                                    CUR.CAMINHO_CAPA CaminhoCapa,
   	                                    CUR.NOM_PROFESSOR NomeProfessor,
   	                                    CUR.DESCRICAO_CURSO DescricaoCurso,
                                        CUR.DAT_CADASTRO DataCadastro
                                    FROM CURSO CUR 
                                    WHERE ATIVO";

            using (IDbConnection connection = GetConnection())
            {
                return await connection.QueryAsync<DadosCursoModel>(sql);
            }
        }
        public async Task AlterarCurso(int codigoCurso, AlterarCursoArgument argument)
        {
            const string sql = @"UPDATE CURSO SET NOM_CURSO = @NomeCurso WHERE cod_curso = @CodigoCurso";

            using (IDbConnection connection = GetConnection())
            {
                await connection.ExecuteAsync(sql, new { CodigoCurso = codigoCurso, argument.NomeCurso });
            }
        }
    }
}

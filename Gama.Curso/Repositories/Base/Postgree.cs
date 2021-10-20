using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Repositories.Base
{
    public class Postgree
    {
        internal IDbConnection GetConnection()
        {
            IDbConnection dbConnection;

            try
            {
                dbConnection = new NpgsqlConnection(
                    "User ID = postgres; Password = Am!nA!2O2; Host = dindin.c1rfboikfug7.us-east-1.rds.amazonaws.com; Port = 5432; Database = cursosdd");
                dbConnection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dbConnection;
        }
    }
}

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
                //dbConnection = new NpgsqlConnection("User ID = postgres; Password = banco123; Host = localhost; Port = 5432; Database = curso");
                dbConnection = new NpgsqlConnection("User ID = xacesso; Password = bancositdis; Host = rds-sisdis.cli1aipb13fa.sa-east-1.rds.amazonaws.com; Port = 5432; Database = dbcurso");
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

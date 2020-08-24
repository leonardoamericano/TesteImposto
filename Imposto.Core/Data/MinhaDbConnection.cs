using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Imposto.Core.Repositories;
using System.Data.Common;
using System.Data;

namespace Imposto.Core.Data
{
    public class MinhaDbConnection : IObterConexaoBD
    {
        private IDbConnection connection = new SqlConnection();
        public MinhaDbConnection()
        {
            connection.ConnectionString = @"Data Source=local\SQLEXPRESS;Initial Catalog=Teste;Integrated Security=True";
        }

        public IDbConnection Conectar()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            return connection;
        }

        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public IDbConnection ObterConexaoDB()
        {
            return connection;
        }
    }
}

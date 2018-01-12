using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DataAccessObject.DataSource.Interfaces;

namespace DataAccessObject.DataSource
{
    public class Connection : IConnection, IDisposable
    {
        private SqlConnection _connection;

        public Connection()
        {
            _connection = new SqlConnection("Data Source=localhost;User Id=sa;Password=Strut76.01;Initial Catalog=Catalog;Integrated Security=True");
        }

        public SqlConnection Open()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public SqlConnection GetConnection()
        {
            return this.Open();
        }

        public void Close()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
        }
    }
}
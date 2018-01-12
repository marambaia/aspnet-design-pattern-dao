using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using DataAccessObject.DataSource.Interfaces;
using DataAccessObject.DataSource;
using DataAccessObject.DAO.Interfaces;
using DataAccessObject.Entities;

namespace DataAccessObject.DAO
{
    public class FilmDAO : IDataAccessObject<Film>, IDisposable
    {
        private IConnection _connection;

        public FilmDAO()
        {
            this._connection = new Connection();
        }

        public bool add(Film model)
        {
            bool saved = false;

            using(SqlCommand command = _connection.GetConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO FILMS (NAME, PRICE, YEAR) VALUES (@NAME, @PRICE, @YEAR); Select @@Identity";

                command.Parameters.Add("@NAME", SqlDbType.Text).Value = model.name;
                command.Parameters.Add("@PRICE", SqlDbType.Decimal).Value = model.price;
                command.Parameters.Add("@YEAR", SqlDbType.Text).Value = model.year;
                
                if (command.ExecuteNonQuery() > 0)
                {
                    saved = true;
                }
            }

            return saved;
        }

        public bool edit(Film model)
        {
            bool saved = false;

            using(SqlCommand command = _connection.GetConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE FILMS SET NAME=@NAME, PRICE=@PRICE, YEAR=@YEAR WHERE ID=@ID";

                command.Parameters.Add("@NAME", SqlDbType.Text).Value = model.name;
                command.Parameters.Add("@PRICE", SqlDbType.Decimal).Value = model.price;
                command.Parameters.Add("@YEAR", SqlDbType.Text).Value = model.year;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = model.id;
                
                if (command.ExecuteNonQuery() > 0)
                {
                    saved = true;
                }
            }

            return saved;
        }

        public bool delete(Film model)
        {
            bool response = false;

            using(SqlCommand command = _connection.GetConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM FILMS WHERE ID=@ID";
                command.Parameters.Add("@ID", SqlDbType.Int).Value = model.id;

                if (command.ExecuteNonQuery() > 0)
                {
                    response = true;
                }
            }

            return response;
        }

        public SqlDataReader getById(int id)
        {
            using (SqlCommand command = _connection.GetConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, NAME, PRICE, YEAR FROM FILMS WHERE ID=@ID";
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                SqlDataReader reader = command.ExecuteReader();
                
                return reader;
            }
        }

        public DataTable getAll()
        {
            using (SqlCommand command = _connection.GetConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, NAME, PRICE, YEAR FROM FILMS ORDER BY NAME";

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessObject.DAO.Interfaces
{
    public interface IDataAccessObject<T> : IDisposable 
        where T: class, new()
    {
        // método para inserir
        bool add(T model);

        // método para atualizar
        bool edit(T model);

        // método para remover
        bool delete(T model);

        // método para localizar dados pelo ID
        SqlDataReader getById(int id);

        // método para localizar todos
        DataTable getAll();
    }
}

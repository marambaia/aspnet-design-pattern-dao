using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WebPatterns.DataSource.Interfaces
{
    public interface IConnection : IDisposable
    {
        // método para abrir a conexão
        SqlConnection Open();

        // método que retorna a conexão aberta, ou abre uma nova conexão caso esteja fechada
        SqlConnection GetConnection();

        // método que fecha a conexão sem retornar nenhum valor
        void Close();
    }
}

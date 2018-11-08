using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO.DAO
{
    public class FornecedorDAO
    {
        public Fornecedor Create(Fornecedor fornecedor)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `db_vendas`.`Fornecedor` (`nomeFornecedor`, `nomeEmpresaFornecedor`, `telefoneFornecedor`) VALUES (@nome, @nomeEmpresa, @telefone);";
            command.Parameters.AddWithValue("@nome", fornecedor.Nome);
            command.Parameters.AddWithValue("nomeEmpresa", fornecedor.NomeEmpresa);
            command.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

            if (command.ExecuteNonQuery() > 0)
            {
                fornecedor.Id = (int)command.LastInsertedId;
                return fornecedor;
            }

            return null;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM db_vendas.fornecedor;",DBConnection.Instance);
            sqlData.Fill(table);
            return table;
        }
    }
}
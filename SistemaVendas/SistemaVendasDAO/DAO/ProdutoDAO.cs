using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO
{
    public class ProdutoDAO
    {
        public Produto Create(Produto produto)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `db_vendas`.`Produto` (`nomeProduto`, `valorProduto`, `Fornecedor_idFornecedor`) VALUES (@nome, @valor, @fornecedor);";
            command.Parameters.AddWithValue("@nome", produto.Nome);
            command.Parameters.AddWithValue("@valor", produto.Valor);
            command.Parameters.AddWithValue("@fornecedor", produto.IdFornecedor);
            if (command.ExecuteNonQuery() > 0)
            {
                produto.Id = (int)command.LastInsertedId;
                return produto;
            }
            return null;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM db_vendas.produto;", DBConnection.Instance);
            sqlData.Fill(table);
            return table;
        }
    }
}
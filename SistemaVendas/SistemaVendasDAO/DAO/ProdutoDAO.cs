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

        public Produto Read(int id)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM db_vendas.produto WHERE idProduto = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Produto produto = null;
            while (reader.Read())
            {
                produto = new Produto(reader["nomeProduto"].ToString(), float.Parse(reader["valorProduto"].ToString()), reader["Fornecedor_idFornecedor"] is DBNull ? 1 : Convert.ToInt32(reader["Fornecedor_idFornecedor"]))
                {
                    Id = Convert.ToInt32(reader["idProduto"])
                };
            }
            reader.Close();
            return produto;
        }

        public Produto Update(Produto produto)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "UPDATE `produto` SET `nomeProduto`= @nome,`valorProduto`= @valor,`Fornecedor_idFornecedor`= @fornecedor WHERE idProduto = @id;";
            command.Parameters.AddWithValue("@nome", produto.Nome);
            command.Parameters.AddWithValue("@valor", produto.Valor);
            command.Parameters.AddWithValue("@fornecedor", produto.IdFornecedor);
            command.Parameters.AddWithValue("@id", produto.Id);
            if (command.ExecuteNonQuery() > 0)
            {
                return produto;
            }
            return null;
        }

        public Produto Delete(Produto produto)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "DELETE FROM `produto` WHERE idProduto = @id";
            command.Parameters.AddWithValue("@id", produto.Id);
            if (command.ExecuteNonQuery() > 0)
            {
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
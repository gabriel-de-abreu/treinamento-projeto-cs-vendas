using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO
{
    public class ItensDAO
    {
        public Itens Create(Itens itens)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `itens`(`quantidadeItens`, `itensValor`, `Venda_idVenda`, `Produto_idProduto`) VALUES (@quantidade,@valorTotal,@idVenda,@idProduto)";
            command.Parameters.AddWithValue("@quantidade", itens.Quantidade);
            command.Parameters.AddWithValue("@valorTotal", itens.Valor);
            command.Parameters.AddWithValue("@idVenda", itens.IdVenda);
            command.Parameters.AddWithValue("@idProduto", itens.IdProduto);
            if (command.ExecuteNonQuery() > 0)
            {
                itens.Id = (int)command.LastInsertedId;
                return itens;
            }
            return null;
        }
        public List<Itens> GetAllVenda(int idVenda)
        {
            List<Itens> itens = new List<Itens>();

            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM db_vendas.itens WHERE Venda_idVenda = @id;";
            command.Parameters.AddWithValue("@id", idVenda);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Itens item = new Itens()
                {
                    Id = Convert.ToInt32(reader["idItens"]),
                    IdProduto = Convert.ToInt32(reader["Produto_idProduto"]),
                    IdVenda = Convert.ToInt32(reader["Venda_idVenda"]),
                    Quantidade = Convert.ToInt32(reader["quantidadeItens"]),
                    Valor = float.Parse(reader["itensValor"].ToString())
                };
                itens.Add(item);
            }
            reader.Close();
            return itens;
        }
    }
}
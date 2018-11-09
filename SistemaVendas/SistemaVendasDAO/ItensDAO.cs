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
    }
}
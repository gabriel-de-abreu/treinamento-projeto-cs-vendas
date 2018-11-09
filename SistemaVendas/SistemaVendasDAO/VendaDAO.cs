using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO
{
    public class VendaDAO
    {
        public Venda Create(Venda venda)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `venda`(`dataVenda`, `totalVenda`, `Cliente_idCliente`) VALUES (@data,@total,@idCliente)";
            command.Parameters.AddWithValue("@data", DateTime.Now);
            command.Parameters.AddWithValue("@total", venda.ValorTotal);
            command.Parameters.AddWithValue("@idCliente", venda.IdCliente);
            if (command.ExecuteNonQuery() > 0)
            {
                venda.Id = (int) command.LastInsertedId;
                return venda;
            }
            return null;
        }
    }
}
using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
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
                venda.Id = (int)command.LastInsertedId;
                return venda;
            }
            return null;
        }

        public Venda Read(int id)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM db_vendas.venda WHERE idVenda = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Venda venda = null;
            while (reader.Read())
            {
                venda = new Venda()
                {
                    Id = Convert.ToInt32(reader["idVenda"]),
                    Data = Convert.ToDateTime(reader["dataVenda"]),
                    ValorTotal = float.Parse(reader["totalVenda"].ToString()),
                    IdCliente = Convert.ToInt32(reader["Cliente_idCliente"])
                };
            }
            reader.Close();
            return venda;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM db_vendas.venda;", DBConnection.Instance);
            sqlData.Fill(table);
            return table;
        }
    }
}
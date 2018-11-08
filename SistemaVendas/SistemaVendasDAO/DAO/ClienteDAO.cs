using MySql.Data.MySqlClient;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO.DAO
{
    public class ClienteDAO
    {
        public Cliente Create(Cliente cliente)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `db_vendas`.`Cliente` (`nomeCliente`, `telefoneCliente`, `emailCliente`, `cpfCliente`) VALUES (@nome, @telefone, @email, @cpf);";
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone);
            command.Parameters.AddWithValue("@email", cliente.Email);
            command.Parameters.AddWithValue("cpf", cliente.CPF);

            if (command.ExecuteNonQuery() > 0)
            {
                cliente.Id = (int)command.LastInsertedId;
                return cliente;
            }
            return null;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM db_vendas.cliente;", DBConnection.Instance);
            sqlData.Fill(table);
            return table;
        }
    }
}
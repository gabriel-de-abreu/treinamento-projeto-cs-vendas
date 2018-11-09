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



        public Cliente Read(int id)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM db_vendas.cliente WHERE idCliente = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Cliente cliente = null;
            while (reader.Read())
            {
                cliente = new Cliente(reader["nomeCliente"].ToString(), reader["telefoneCliente"].ToString(), reader["emailCliente"].ToString(), reader["cpfCliente"].ToString())
                {
                    Id = Convert.ToInt32(reader["idCliente"])
                };

            }
            reader.Close();
            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "UPDATE `cliente` SET `nomeCliente`=@nome,`telefoneCliente`= @telefone,`emailCliente`= @email,`cpfCliente`= @cpf WHERE idCliente = @id";
            command.Parameters.AddWithValue("@id", cliente.Id);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone);
            command.Parameters.AddWithValue("@email", cliente.Email);
            command.Parameters.AddWithValue("cpf", cliente.CPF);

            if (command.ExecuteNonQuery() > 0)
            {
                return cliente;
            }
            return null;
        }

        public Cliente Delete(Cliente cliente)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "DELETE FROM `cliente` WHERE idCliente= @id";
            command.Parameters.AddWithValue("@id", cliente.Id);
            if (command.ExecuteNonQuery() > 0)
            {
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
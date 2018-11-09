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

        public Fornecedor Read(int id)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM db_vendas.fornecedor WHERE idFornecedor = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Fornecedor fornecedor = null;
            while (reader.Read())
            {
                fornecedor = new Fornecedor(Convert.ToString(reader["nomeFornecedor"]), Convert.ToString(reader["nomeEmpresaFornecedor"]), Convert.ToString(reader["telefoneFornecedor"]))
                {
                    Id = Convert.ToInt32(reader["idFornecedor"])
                };
            }
            reader.Close();
            return fornecedor;
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            MySqlCommand command = DBConnection.Instance.CreateCommand();
            command.CommandText = "UPDATE `fornecedor` SET `nomeFornecedor`= @nome,`nomeEmpresaFornecedor`=@nomeEmpresa,`telefoneFornecedor`=@telefone WHERE idFornecedor = @id;";
            command.Parameters.AddWithValue("@nome", fornecedor.Nome);
            command.Parameters.AddWithValue("nomeEmpresa", fornecedor.NomeEmpresa);
            command.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
            command.Parameters.AddWithValue("@id", fornecedor.Id);
            if (command.ExecuteNonQuery() > 0)
            {
                return fornecedor;
            }

            return null;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM db_vendas.fornecedor;", DBConnection.Instance);
            sqlData.Fill(table);
            return table;
        }
    }
}
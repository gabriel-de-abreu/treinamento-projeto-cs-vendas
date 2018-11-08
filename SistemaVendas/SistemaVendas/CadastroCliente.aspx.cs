using MySql.Data.MySqlClient;
using SistemaVendasBS;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaVendas
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridClientes.DataSource = ClienteBS.GetAll();
            gridClientes.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBS.Create(new Cliente(txtNome.Text, txtTelefone.Text, txtEmail.Text, txtCpf.Text));
                lblResult.Text = "Cliente cadastrado com sucesso!";

            }
            catch (MySqlException)
            {
                lblResult.Text = "Cliente já Cadastrado!";
            }
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblResult.Text = e.CommandArgument.ToString();
        }
    }
}
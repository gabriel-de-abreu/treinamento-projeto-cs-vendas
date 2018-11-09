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
        int editMode = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EditModeCliente"] != null)
            {
                editMode = Convert.ToInt32(Session["EditModeCliente"]);

            }
            ReloadGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (editMode == -1)
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
            else
            {
                try
                {
                    ClienteBS.Update(new Cliente(txtNome.Text, txtTelefone.Text, txtEmail.Text, txtCpf.Text)
                    {
                        Id = Convert.ToInt32(Session["EditModeCliente"])
                    });
                    lblResult.Text = "Cliente alterado com sucesso!";

                }
                catch (MySqlException)
                {
                    lblResult.Text = "CPF já Cadastrado!";
                }
            }
            SetEditMode(-1);
            ReloadGrid();
            ClearFields();
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Cliente cliente = ClienteBS.Read(Convert.ToInt32(e.CommandArgument));
            txtNome.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
            txtCpf.Text = cliente.CPF;
            SetEditMode(cliente.Id);
            ClearLabel();
        }

        private void ReloadGrid()
        {
            gridClientes.DataSource = ClienteBS.GetAll();
            gridClientes.DataBind();
        }

        private void SetEditMode(int id)
        {
            if (id == -1)
            {
                Button1.Text = "Cadastrar";
                Session["EditModeCliente"] = -1;
            }
            else
            {
                Button1.Text = "Salvar";
                Session["EditModeCliente"] = id;
            }
        }

        private void ClearFields()
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCpf.Text = "";
        }
        private void ClearLabel()
        {
            lblResult.Text = "";
        }
    }
}
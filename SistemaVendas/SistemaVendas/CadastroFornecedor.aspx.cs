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
    public partial class CadastroFornecedor : System.Web.UI.Page
    {
        int editMode = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EditModeFornecedor"] != null)
            {
                editMode = Convert.ToInt32(Session["EditModeFornecedor"]);
            }
            ReloadTable();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (editMode == -1)
            {
                try
                {
                    FornecedorBS.Create(new Fornecedor(txtNome.Text, txtNomeEmpresa.Text, txtTelefone.Text));
                    lblResultado.Text = "Fornecedor cadastrado com sucesso!";
                }
                catch (Exception)
                {
                    lblResultado.Text = "Fornecedor já cadastrado!";
                }
            }
            else
            {
                try
                {
                    FornecedorBS.Update(new Fornecedor(txtNome.Text, txtNomeEmpresa.Text, txtTelefone.Text)
                    {
                        Id = Convert.ToInt32(Session["EditModeFornecedor"])
                    });
                    lblResultado.Text = "Fornecedor alterado com sucesso!";
                }
                catch (Exception)
                {
                    lblResultado.Text = "Fornecedor já cadastrado!";
                }
            }
            SetEditMode(-1);
            ReloadTable();
        }

        protected void gridFornecedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Fornecedor fornecedor = FornecedorBS.Read(Convert.ToInt32(e.CommandArgument));
            txtNome.Text = fornecedor.Nome;
            txtNomeEmpresa.Text = fornecedor.NomeEmpresa;
            txtTelefone.Text = fornecedor.Telefone;
            SetEditMode(fornecedor.Id);
            ClearLabel();
        }

        private void SetEditMode(int id)
        {
            if (id == -1)
            {

                Session["EditModeFornecedor"] = -1;
                btnCadastrar.Text = "Cadastrar";
            }
            else
            {
                Session["EditModeFornecedor"] = id;
                btnCadastrar.Text = "Salvar";
            }
        }

        private void ReloadTable()
        {
            gridFornecedores.DataSource = FornecedorBS.GetAll();
            gridFornecedores.DataBind();
        }

        private void ClearFields()
        {
            txtNome.Text = "";
            txtNomeEmpresa.Text = "";
            txtTelefone.Text = "";
        }

        private void ClearLabel()
        {
            lblResultado.Text = "";
        }

    }
}
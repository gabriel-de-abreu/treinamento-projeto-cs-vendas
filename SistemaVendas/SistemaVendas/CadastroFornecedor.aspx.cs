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
            ReloadGrid();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (editMode == -1)
            {
                try
                {
                    FornecedorBS.Create(new Fornecedor(txtNome.Text, txtNomeEmpresa.Text, txtTelefone.Text));
                    lblResultado.Text = "<div class=\"alert alert-success\" role=\"alert\">Fornecedor cadastrado com sucesso!</div>";
                }
                catch (Exception)
                {
                    lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Fornecedor já Cadastrado!</div>";
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
                    lblResultado.Text = "<div class=\"alert alert-success\" role=\"alert\">Fornecedor alterado com sucesso!</div>";
                }
                catch (Exception)
                {
                    lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Fornecedor já Cadastrado!!</div>";
                }
            }
            SetEditMode(-1);
            ReloadGrid();
        }

        protected void gridFornecedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Fornecedor fornecedor = FornecedorBS.Read(Convert.ToInt32(e.CommandArgument));
            switch (e.CommandName)
            {
                case "EditFornecedor":
                    txtNome.Text = fornecedor.Nome;
                    txtNomeEmpresa.Text = fornecedor.NomeEmpresa;
                    txtTelefone.Text = fornecedor.Telefone;
                    SetEditMode(fornecedor.Id);
                    break;

                case "DeleteFornecedor":
                    FornecedorBS.Delete(fornecedor);
                    SetEditMode(-1);
                    ReloadGrid();
                    break;
            }
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

        private void ReloadGrid()
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
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
    public partial class CadastroProduto : System.Web.UI.Page
    {
        public int editMode = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EditModeProduto"] != null)
            {
                editMode = Convert.ToInt32(Session["EditModeProduto"]);
            }
            ReloadGrid();
            if (!IsPostBack)
            {
                list_fornecedor.DataSource = FornecedorBS.GetAll();
                list_fornecedor.DataValueField = "idFornecedor";
                list_fornecedor.DataTextField = "nomeFornecedor";
                list_fornecedor.DataBind();
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            if (editMode == -1)
            {
                try
                {
                    ProdutoBS.Create(new Produto(txtNome.Text, float.Parse(txtValor.Text), Convert.ToInt32(list_fornecedor.SelectedValue)));
                    lblResultado.Text = "Produto cadastrado com sucesso!";
                }
                catch (Exception)
                {
                    lblResultado.Text = "Produto já cadastrado!";
                }
            }
            else
            {
                try
                {
                    ProdutoBS.Update(new Produto(txtNome.Text, float.Parse(txtValor.Text), Convert.ToInt32(list_fornecedor.SelectedValue))
                    {
                        Id = editMode
                    });
                    lblResultado.Text = "Produto alterado com sucesso!";
                }
                catch (Exception)
                {
                    lblResultado.Text = "Produto já cadastrado!";
                }
            }

            SetEditMode(-1);
            ReloadGrid();
            ClearFields();
        }

        protected void gridProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Produto produto = ProdutoBS.Read(Convert.ToInt32(e.CommandArgument));

            switch (e.CommandName)
            {
                case "EditProduto":
                    txtNome.Text = produto.Nome;
                    txtValor.Text = produto.Valor.ToString();
                    list_fornecedor.SelectedValue = produto.IdFornecedor.ToString();
                    SetEditMode(produto.Id);
                    break;
                case "DeleteProduto":
                    ProdutoBS.Delete(produto);
                    ReloadGrid();
                    break;
            }
            ClearLabel();
        }

        private void SetEditMode(int id)
        {
            if (id == -1)
            {
                btnCadastro.Text = "Cadastrar";
                Session["EditModeProduto"] = -1;
            }
            else
            {
                btnCadastro.Text = "Salvar";
                Session["EditModeProduto"] = id;
            }
        }

        private void ReloadGrid()
        {
            gridProdutos.DataSource = ProdutoBS.getAll();
            gridProdutos.DataBind();
        }
        private void ClearFields()
        {
            txtNome.Text = "";
            txtValor.Text = "";
            list_fornecedor.SelectedIndex = 0;
        }
        private void ClearLabel()
        {
            lblResultado.Text = "";
        }
    }
}
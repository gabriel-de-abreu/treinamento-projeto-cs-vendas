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
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}
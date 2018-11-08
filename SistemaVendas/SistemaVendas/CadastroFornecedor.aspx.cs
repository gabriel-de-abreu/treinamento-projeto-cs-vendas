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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
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
    }
}
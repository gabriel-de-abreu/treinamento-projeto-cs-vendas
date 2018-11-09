using SistemaVendasBS;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaVendas
{
    public partial class Vendas : System.Web.UI.Page
    {
        private List<Itens> carrinho = new List<Itens>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carrinhoCompras"] != null)
            {
                carrinho = Session["carrinhoCompras"] as List<Itens>;
            }

            gridProdutos.DataSource = ProdutoBS.getAll();
            gridProdutos.DataBind();

            list_clientes.DataSource = ClienteBS.GetAll();
            list_clientes.DataTextField = "cpfCliente";
            list_clientes.DataValueField = "idCliente";
            list_clientes.DataBind();

            RenderItensTable();
            RenderFinishTransaction();
        }

        protected void gridProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Produto produto = ProdutoBS.Read(Convert.ToInt32(e.CommandArgument));
            switch (e.CommandName)
            {
                case "SelectProduto":
                    txtNomeProduto.Text = produto.Nome;
                    txtPrecoProduto.Text = produto.Valor.ToString();
                    txtIdProduto.Text = produto.Id.ToString();
                    break;
            }

        }

        private void RenderItensTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID");
            dt.Columns.Add("Produto");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Valor");

            List<Itens> carrinho = Session["carrinhoCompras"] as List<Itens>;
            if (carrinho == null)
            {
                carrinho = new List<Itens>();
            }
            foreach (var item in carrinho)
            {
                DataRow row = dt.NewRow();
                row["ID"] = item.IdProduto;
                row["Produto"] = ProdutoBS.Read(item.IdProduto).Nome;
                row["Quantidade"] = item.Quantidade;
                row["Valor"] = item.Valor;
                dt.Rows.Add(row);
            }
            gridCarrinho.DataSource = dt;
            gridCarrinho.DataBind();
            RenderFinishTransaction();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Itens itemAux = null;
            foreach (var carrinhoItem in carrinho)
            {
                if (Convert.ToInt32(txtIdProduto.Text) == carrinhoItem.IdProduto)
                {
                    itemAux = carrinhoItem;
                }
            }

            Itens item = new Itens();
            item = new Itens()
            {
                IdProduto = Convert.ToInt32(txtIdProduto.Text),
                Quantidade = Convert.ToInt32(txtQuantidade.Text),
                Valor = Convert.ToInt32(txtQuantidade.Text) * float.Parse(txtPrecoProduto.Text)
            };
            if (itemAux != null)
            {
                itemAux.Quantidade += item.Quantidade;
                itemAux.Valor = itemAux.Quantidade * float.Parse(txtPrecoProduto.Text);
            }
            else
            {
                carrinho.Add(item);
            }
            Session["carrinhoCompras"] = carrinho;
            RenderItensTable();
        }

        private void RenderFinishTransaction()
        {
            carrinho = Session["carrinhoCompras"] as List<Itens>;
            if (carrinho == null)
            {
                carrinho = new List<Itens>();
            }
            if (carrinho.Count() > 0)
            {
                placeHolderText.Visible = false;
                btn_finalizar.Visible = true;

            }
            else
            {
                placeHolderText.Visible = true;
                btn_finalizar.Visible = false;
            }
        }

        protected void gridCarrinho_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ExcluirProduto":
                    List<Itens> carrinho = Session["carrinhoCompras"] as List<Itens>;
                    Itens aux = null;
                    foreach (var item in carrinho)
                    {
                        if (Convert.ToInt32(e.CommandArgument) == item.IdProduto)
                        {
                            aux = item;
                        }
                    }
                    carrinho.Remove(aux);
                    Session["carrinhoCompras"] = carrinho;
                    RenderItensTable();
                    break;
            }
        }

        protected void btn_finalizar_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda()
            {
                IdCliente = Convert.ToInt32(list_clientes.SelectedValue),

            };

            List<Itens> carrinho = Session["carrinhoCompras"] as List<Itens>;
            if (VendaBS.Venda(venda, carrinho))
            {
                lblResultado.Text = "<div class=\"alert alert-success\" role=\"alert\">Venda realizada com sucesso!</div>";
            }
            else
            {
                lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Falha ao realizar venda!</div>";
            }
            Session["carrinhoCompras"] = null;
            carrinho = new List<Itens>();
            RenderItensTable();
            RenderFinishTransaction();
        }
    }
}
﻿using SistemaVendasBS;
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
            if (!IsPostBack)
            {
                list_clientes.DataSource = ClienteBS.GetAll();
                list_clientes.DataTextField = "cpfCliente";
                list_clientes.DataValueField = "idCliente";
                list_clientes.DataBind();
            }

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
                    txtPrecoProduto.Text = string.Format("{0:C}", produto.Valor);
                    txtIdProduto.Text = produto.Id.ToString();
                    txtQuantidade.Text = "1";
                    break;
            }

        }

        private void RenderItensTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Produto", typeof(String));
            dt.Columns.Add("Quantidade", typeof(int));
            dt.Columns.Add("Valor", typeof(float));

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
            if (!ValidateFields())
            {
                return;
            }
            Itens itemAux = null;
            foreach (var carrinhoItem in carrinho)
            {
                if (Convert.ToInt32(txtIdProduto.Text) == carrinhoItem.IdProduto)
                {
                    itemAux = carrinhoItem;
                }
            }

            Itens item = new Itens();
            float valor = float.Parse(txtPrecoProduto.Text.Replace("R$",""));
            item = new Itens()
            {
                IdProduto = Convert.ToInt32(txtIdProduto.Text),
                Quantidade = Convert.ToInt32(txtQuantidade.Text),
                Valor = Convert.ToInt32(txtQuantidade.Text) * valor
            };
            if (itemAux != null)
            {
                itemAux.Quantidade += item.Quantidade;
                itemAux.Valor = itemAux.Quantidade * valor;
            }
            else
            {
                carrinho.Add(item);
            }
            Session["carrinhoCompras"] = carrinho;
            RenderItensTable();
            ClearLabel();
            ClearFields();
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

        private bool ValidateFields()
        {
            if (txtIdProduto.Text.Equals(""))
            {
                lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Selecione um produto!</div>";
                return false;
            }
            if (txtQuantidade.Text.Equals(""))
            {
                lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Quantidade não pode ser vazio!</div>";
                return false;
            }
            try
            {
                Convert.ToInt32(txtQuantidade.Text);
            }
            catch (Exception)
            {
                lblResultado.Text = "<div class=\"alert alert-danger\" role=\"alert\">Quantidade inválida, verifique e tente novamente!</div>";
                return false;
            }
            return true;
        }
        private void ClearFields()
        {
            txtIdProduto.Text = "";
            txtNomeProduto.Text = "";
            txtPrecoProduto.Text = "";
            txtQuantidade.Text = "";
        }
        private void ClearLabel()
        {
            lblResultado.Text = "";
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            ClearFields();
            ClearLabel();
        }
    }
}
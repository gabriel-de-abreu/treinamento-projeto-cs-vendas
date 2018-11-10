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
    public partial class VendaDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VendaDetalhes"] != null)
            {
                Venda venda = VendaBS.Read(Convert.ToInt32(Session["VendaDetalhes"]));
                Cliente cliente = ClienteBS.Read(venda.IdCliente);
                table_div.InnerHtml += "<table class=\"table\">";
                table_div.InnerHtml += $"<tr> <td>ID da Venda</td ><td>{venda.Id}</td > </tr>";
                table_div.InnerHtml += $"<tr> <td>CPF do Cliente</td ><td>{cliente.CPF}</td > </tr>";
                table_div.InnerHtml += $"<tr> <td>Nome do Cliente</td ><td>{cliente.Nome}</td > </tr>";
                table_div.InnerHtml += $"<tr> <td>Data da Venda</td ><td>{venda.Data}</td > </tr>";
                table_div.InnerHtml += $"<tr> <td>Valor total</td ><td>{venda.ValorTotal}</td > </tr>";
                table_div.InnerHtml += "</table>";

                List<Itens> itens = VendaBS.GetAllItensVenda(venda.Id);
                table_itens_div.InnerHtml += "<table class=\"table view-table\">";
                table_itens_div.InnerHtml += "<tr> <th>Produto</th> <th>Quantidade</th> <th>Valor Total</th> </tr>";
                foreach (var item in itens)
                {
                    table_itens_div.InnerHtml += $"<tr> <td>{ProdutoBS.Read(item.IdProduto).Nome} </td> <td>{item.Quantidade} </td> <td>{item.Valor}</td> </tr>";
                }
                table_div.InnerHtml += "</table>";
            }
        }
    }
}
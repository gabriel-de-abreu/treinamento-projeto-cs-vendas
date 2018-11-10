using SistemaVendasBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaVendas
{
    public partial class ConsultarVendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridVendas.DataSource = VendaBS.GetAll();
            gridVendas.DataBind();
        }

        protected void gridVendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "VerDetalhes":
                    Session["VendaDetalhes"] = e.CommandArgument;
                    Response.Redirect("~/VendaDetalhes.aspx");
                    break;
            }
        }
    }
}
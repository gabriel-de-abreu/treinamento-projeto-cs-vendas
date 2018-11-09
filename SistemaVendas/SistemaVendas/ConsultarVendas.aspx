<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="ConsultarVendas.aspx.cs" Inherits="SistemaVendas.ConsultarVendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container text-center">
           <h1>Consultar Vendas</h1>
        </div>
    </div>
    <div class="row">
        <div class="container">
            <asp:GridView ID="gridVendas" runat="server" AutoGenerateColumns="False" CssClass="table view-table">
                <Columns>
                    <asp:BoundField DataField="idVenda" HeaderText="ID" />
                    <asp:BoundField DataField="dataVenda" HeaderText="Data" />
                    <asp:BoundField DataField="totalVenda" HeaderText="Valor" />
                    <asp:BoundField DataField="Cliente_idCliente" HeaderText="Cliente" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

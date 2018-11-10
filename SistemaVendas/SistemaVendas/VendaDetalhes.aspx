<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="VendaDetalhes.aspx.cs" Inherits="SistemaVendas.VendaDetalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container text-center">
            <h1>Detalhes da Venda</h1>
        </div>
    </div>
    <div class="row">
        <div id="table_div" runat="server" class="container">
        </div>
    </div>
    <div class="row">
        <div id="table_itens_div" runat="server" class="container margin-top-large margin-bottom-large box-border text-center">
            <h3>Itens comprados</h3>
        </div>
    </div>
</asp:Content>

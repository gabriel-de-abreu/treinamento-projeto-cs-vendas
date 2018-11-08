<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="SistemaVendas.CadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-group">
            <label>
                Nome
            </label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>
                Valor
            </label>
            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>
                Fornecedor
            </label>
            <asp:DropDownList ID="list_fornecedor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <asp:Button ID="btnCadastro" runat="server" Text="Cadastrar" OnClick="btnCadastro_Click" />
        <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>

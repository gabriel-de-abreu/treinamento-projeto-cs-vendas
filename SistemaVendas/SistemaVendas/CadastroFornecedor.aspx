<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="CadastroFornecedor.aspx.cs" Inherits="SistemaVendas.CadastroFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-group">
            <label>Nome</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Nome da Empresa</label>
            <asp:TextBox ID="txtNomeEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Telefone</label>
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
    </div>
</asp:Content>


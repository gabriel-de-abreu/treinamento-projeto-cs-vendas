<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="SistemaVendas.CadastroCliente" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container text-center">
            <h1>Controle de Clientes</h1>
        </div>
    </div>
    <div class="row">
        <div class="container box-border">
            <div class="form-group">
                <label>Nome</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Telefone</label>
                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>CPF</label>
                <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Cadastrar" OnClick="Button1_Click" CssClass="btn btn-dark" />
            <div class="margin-top">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="container box-border margin-top-large text-center">
            <h3>Clientes Cadastrados</h3>
            <asp:GridView ID="gridClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gridClientes_RowCommand" CssClass="table view-table margin-top">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nomeCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("telefoneCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("emailCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CPF">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("cpfCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Button2" runat="server" Text="Editar" CommandArgument='<%# Bind("idCliente") %>' CommandName="EditCustomer" CssClass="btn btn-outline-dark" />
                            <asp:LinkButton ID="Button3" runat="server" Text="Deletar" CommandArgument='<%# Bind("idCliente") %>' CommandName="DeleteCustomer" CssClass="btn btn-dark" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

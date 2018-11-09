<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="CadastroFornecedor.aspx.cs" Inherits="SistemaVendas.CadastroFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container text-center">
            <h1>Controle de Fornecedores</h1>
        </div>
    </div>
    <div class="row">
        <div class="container box-border">
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
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" CssClass="btn btn-dark" />
            <div class="margin-top">
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="container margin-top-large text-center box-border">
            <h3>Fornecedores Cadastrados
            </h3>
            <asp:GridView ID="gridFornecedores" runat="server" AutoGenerateColumns="False" OnRowCommand="gridFornecedores_RowCommand" CssClass="table view-table margin-top">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nomeFornecedor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nomeFornecedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Empresa">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nomeEmpresaFornecedor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nomeEmpresaFornecedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("telefoneFornecedor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("telefoneFornecedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Button2" runat="server" Text="Editar" CommandArgument='<%# Bind("idFornecedor") %>' CommandName="EditFornecedor" CssClass="btn btn-outline-dark" />
                            <asp:LinkButton ID="Button3" runat="server" Text="Delete" CommandArgument='<%# Bind("idFornecedor") %>' CommandName="DeleteFornecedor" CssClass="btn btn-dark" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


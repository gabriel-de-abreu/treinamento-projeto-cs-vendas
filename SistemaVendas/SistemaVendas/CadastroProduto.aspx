﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="SistemaVendas.CadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
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
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="container">
            <asp:GridView ID="gridProdutos" runat="server" AutoGenerateColumns="False" OnRowCommand="gridProdutos_RowCommand" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nomeProduto") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nomeProduto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("valorProduto") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("valorProduto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fornecedor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Fornecedor_idFornecedor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Fornecedor_idFornecedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Button2" runat="server" Text="Editar" CommandArgument='<%# Bind("idProduto") %>' CommandName="EditProduto" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Button3" runat="server" Text="Delete" CommandArgument='<%# Bind("idProduto") %>' CommandName="DeleteProduto" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

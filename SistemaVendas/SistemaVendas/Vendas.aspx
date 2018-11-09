<%@ Page Title="" Language="C#" MasterPageFile="~/ViewMaster.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="SistemaVendas.Vendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <%-- Painel de inserção --%>
            <div class="container">
                <div class="form-group">
                    <label>
                        ID
                    </label>
                    <asp:Label ID="txtIdProduto" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        Nome do Produto
                    </label>
                    <asp:Label ID="txtNomeProduto" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        Preço
                    </label>
                    <asp:Label ID="txtPrecoProduto" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        Quantidade
                    </label>
                    <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>
                        Cliente
                    </label>
                    <asp:DropDownList ID="list_clientes" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            </div>
        </div>
        <div class="col">
            <div class="container text-center">
                <p id="placeHolderText" runat="server">Sem produtos no Carrinho!</p>
                <asp:GridView ID="gridCarrinho" runat="server" AutoGenerateColumns="False" OnRowCommand="gridCarrinho_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Produto">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Produto") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Produto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantidade">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Quantidade") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Quantidade") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Valor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Valor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Button3" runat="server" Text="Excluir" CommandArgument='<%# Bind("ID") %>' CommandName="ExcluirProduto" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btn_finalizar" runat="server" Text="Finalizar Venda" OnClick="btn_finalizar_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="container">
            <%-- Grid com produtos --%>
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
                            <asp:LinkButton ID="Button2" runat="server" Text="Selecionar" CommandArgument='<%# Bind("idProduto") %>' CommandName="SelectProduto" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

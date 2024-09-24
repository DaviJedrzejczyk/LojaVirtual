<%@ Page Async="true" Title="Produto" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="LojaVirtual___PresentationLayer.Pages.produtos" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Marko+One&display=swap" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="PanelProduto" runat="server" Height="587px">
        <div class="geral">

            <div class="campos">
                <div class="campos">
                    <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                </div>

                <div class="campos">
                    <asp:Label ID="lblNome" runat="server" Text="Nome:" CssClass="labels"></asp:Label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="textBox"></asp:TextBox>
                </div>

                <div class="campos">
                    <asp:Label ID="lblPreco" runat="server" Text="Preço" CssClass="labels"></asp:Label>
                    <asp:TextBox ID="txtPreco" runat="server" CssClass="textBox"></asp:TextBox>
                </div>
                <div class="campos">
                    <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade" CssClass="labels"></asp:Label>
                    <asp:TextBox ID="txtQuantidade" runat="server" CssClass="textBox" onKeyUp="validateInput(event)"></asp:TextBox>
                </div>
                <div class="botoes">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn_inserir" OnClick="btnSalvar_Click" />
                    <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn_deletar" OnClick="btnDeletar_Click" />
                    <asp:Button ID="BtnClear" runat="server" Text="Limpar" CssClass="btn_limpar" OnClick="BtnClear_Click" />
                </div>
            </div>
            <div class="bloco-tabela">
                <asp:ListView ID="ListViewProduto" runat="server" DataKeyNames="Id" ViewStateMode="Enabled" DataSourceID="SqlDataSourceProduto" OnItemCommand="ListViewProdutos_ItemCommand">
                    <AlternatingItemTemplate>
                        <tr class="table-tr">
                            <td class="table-td">
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="PrecoLabel" runat="server" Text='<%# Eval("Preço") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' />
                            </td>
                            <td class="selecionar-td">
                                <asp:LinkButton ID="lnkSelecionar" runat="server" CommandName="Select" CommandArgument='<%# Eval("ID") %>' Text="Selecionar" CssClass="selecionar" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server">
                            <tr runat="server" class="table-tr">
                                <th runat="server" class="table-th">Id</th>
                                <th runat="server" class="table-th">Nome</th>
                                <th runat="server" class="table-th">Preço</th>
                                <th runat="server" class="table-th">Quantidade</th>
                            </tr>
                            <tr>
                                <td class="table-td" colspan="4">Nenhum dado foi encontrado...</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr class="table-tr">
                            <td class="table-td">
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="PrecoLabel" runat="server" Text='<%# Eval("Preço") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' />
                            </td>
                            <td class="selecionar-td">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CommandArgument='<%# Eval("ID") %>' Text="Selecionar" CssClass="selecionar" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                        <tr runat="server" class="table-tr">
                                            <th runat="server" class="table-th">Id</th>
                                            <th runat="server" class="table-th">Nome</th>
                                            <th runat="server" class="table-th">Preço</th>
                                            <th runat="server" class="table-th">Quantidade</th>
                                            <th runat="server" class="table-th">Ação</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: 'Marko One', sans-serif; color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSourceProduto" runat="server" ConnectionString="<%$ ConnectionStrings:LojaVirtualDbConnectionString %>" SelectCommand="SELECT [PROD_ID] as Id, 
[PROD_NOME] as Nome, 
[PROD_PRECO] as [Preço], 
[PROD_QUANTIDADE] as Quantidade 
FROM [Produtos]"></asp:SqlDataSource>
            </div>
        </div>
    </asp:Panel>
    <script type="text/javascript">
        var txtPreco = '<%= txtPreco.ClientID%>';
    </script>
    <script src="../js/formataCampoPreco.js"></script>
    <script src="../js/validaCampoQuantidade.js"></script>
</asp:Content>

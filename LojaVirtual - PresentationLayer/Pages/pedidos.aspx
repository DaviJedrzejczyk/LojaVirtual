<%@ Page Async="true" Title="Pedido" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="LojaVirtual___PresentationLayer.Pages.pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Marko+One&display=swap" rel="stylesheet">
    <meta charset="utf-8" />

    <link href="../css/pedido.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var listProdutos = document.getElementById('<%= dropProduto.ClientID %>');
            var quantidadeContainer = document.getElementById('quantidadeContainer');

            listProdutos.addEventListener('change', function () {
                quantidadeContainer.innerHTML = '';

                for (var i = 0; i < listProdutos.options.length; i++) {
                    if (listProdutos.options[i].selected) {
                        var label = document.createElement('label');
                        label.innerHTML = "Quantidade para " + listProdutos.options[i].text + ": ";
                        label.className = "labels";

                        var input = document.createElement('input');
                        input.type = 'number';
                        input.name = 'quantidade_' + listProdutos.options[i].value;
                        input.id = 'quantidade_' + listProdutos.options[i].value;
                        input.min = '1';
                        input.className = "inputQuantidadePedido";

                        quantidadeContainer.appendChild(label);
                        quantidadeContainer.appendChild(input);
                        quantidadeContainer.appendChild(document.createElement('br'));
                    }
                }
            });
        });
    </script>
    <asp:Panel ID="PanelPedidos" runat="server" Height="587px">
        <div class="geral">

            <div class="campos">
                <div class="campos">
                    <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                </div>

                <div class="campos">
                    <asp:Label ID="lblCliente" runat="server" Text="Cliente:" CssClass="labels"></asp:Label>
                    <asp:DropDownList ID="dClientes" runat="server" CssClass="dropDown"></asp:DropDownList>
                </div>
                <div class="campos">
                    <asp:Label ID="lblProduto" runat="server" Text="Produto:" CssClass="labels"></asp:Label>
                    <asp:ListBox ID="dropProduto" runat="server" CssClass="dropDown" SelectionMode="Multiple"></asp:ListBox>
                </div>
                <div id="quantidadeContainer" class="campos"></div>

                <div class="botoes">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn_inserir" OnClick="btnSalvar_Click" />
                    <asp:Button ID="BtnClear" runat="server" Text="Limpar" CssClass="btn_limpar" OnClick="BtnClear_Click" />
                </div>
            </div>

            <div class="bloco-tabela">
                <asp:ListView ID="ListViewPedidos" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSourcePedidos" OnItemDataBound="ListViewPedidos_ItemDataBound">
                    <AlternatingItemTemplate>
                        <tr>
                            <td class="table-td">
                                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ClienteLabel" runat="server" Text='<%# Eval("Cliente") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="DataLabel" runat="server" Text='<%# Eval("Data") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ValorLabel" runat="server" Text='<%# Eval("Total do Pedido", "{0:C}") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produtos") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td>
                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                                <asp:DropDownList ID="ddlAcoes" CssClass="dropAcoes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAcoes_SelectedIndexChanged">
                                    <asp:ListItem Text="Ações" Value="" />
                                    <asp:ListItem Text="Aprovar" Value="Approve" />
                                    <asp:ListItem Text="Cancelar" Value="Cancel" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr runat="server">
                                <th runat="server" class="table-th">ID</th>
                                <th runat="server" class="table-th">Cliente</th>
                                <th runat="server" class="table-th">Data</th>
                                <th runat="server" class="table-th">Total do Pedido</th>
                                <th runat="server" class="table-th">Produto</th>
                                <th runat="server" class="table-th">Quantidade</th>
                            </tr>
                            <tr>
                                <td class="table-td" colspan="6">Nenhum dado foi encontrado...</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="table-td">
                                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ClienteLabel" runat="server" Text='<%# Eval("Cliente") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="DataLabel" runat="server" Text='<%# Eval("Data") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ValorLabel" runat="server" Text='<%# Eval("Total do Pedido", "{0:C}") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produtos") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td class="acoes-dropdown">
                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                                <asp:DropDownList ID="ddlAcoes" runat="server" CssClass="dropAcoes" AutoPostBack="true" OnSelectedIndexChanged="ddlAcoes_SelectedIndexChanged">
                                    <asp:ListItem Text="Ações" Value="" />
                                    <asp:ListItem Text="Aprovar" Value="Approve" />
                                    <asp:ListItem Text="Cancelar" Value="Cancel" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="0">
                                        <tr runat="server">
                                            <th runat="server" class="table-th">ID</th>
                                            <th runat="server" class="table-th">Cliente</th>
                                            <th runat="server" class="table-th">Data</th>
                                            <th runat="server" class="table-th">Total do Pedido</th>
                                            <th runat="server" class="table-th">Produto</th>
                                            <th runat="server" class="table-th">Quantidade</th>
                                            <th runat="server" class="table-th">Status</th>
                                            <th runat="server" class="table-th"></th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #34495E; font-family: 'Marko One', sans-serif; color: white; font-size: 16px; padding:6px;">
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
                <asp:SqlDataSource ID="SqlDataSourcePedidos" runat="server" ConnectionString="<%$ ConnectionStrings:LojaVirtualDbConnectionString %>" SelectCommand="SELECT 
    P.[PED_ID] as ID,  
    C.[CLI_NOME] as Cliente, 
    P.[PED_DATA] as Data, 
    P.[PED_VALOR] as [Total do Pedido],
    STRING_AGG(PR.[PROD_NOME], ', ') AS Produtos,
    P.[PED_QUANTIDADE] as Quantidade,
    CASE 
        WHEN P.[PED_STATUS] = 0 THEN 'Cancelado'
        WHEN P.[PED_STATUS] = 1 THEN 'Aprovado'
        WHEN P.[PED_STATUS] = 2 THEN 'Em aprovação'
    END as Status
FROM 
    [Pedidos] P
JOIN 
    [Clientes] C ON P.[CLI_ID] = C.[CLI_ID]
JOIN
    [ProdutoPedidos] PP ON P.[PED_ID] = PP.[PEDIDOID]
JOIN
    [Produtos] PR ON PP.[PRODUTOID] = PR.[PROD_ID]
GROUP BY 
    P.[PED_ID], C.[CLI_NOME], P.[PED_DATA], P.[PED_VALOR], P.[PED_QUANTIDADE], P.[PED_STATUS]
"></asp:SqlDataSource>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

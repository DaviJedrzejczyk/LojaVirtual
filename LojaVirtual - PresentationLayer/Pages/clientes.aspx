<%@ Page Async="true" Title="Cliente" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="LojaVirtual___PresentationLayer.Pages.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Marko+One&display=swap" rel="stylesheet">
    <meta charset="utf-8" />

    <link href="../css/cliente.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />

    <asp:Panel ID="PanelCliente" runat="server" Height="587px">
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
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="labels"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox"></asp:TextBox>
                </div>

                <div class="campos">
                    <asp:Label ID="lblDataNasc" runat="server" Text="Data de Nascimento:" CssClass="labels"></asp:Label>
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="textBox"></asp:TextBox>
                </div>

                <div class="campos-inline">
                    <asp:Label ID="lblAtivo" runat="server" Text="Ativo:" CssClass="labels"></asp:Label>
                    <asp:CheckBox ID="ckAtivo" runat="server" CssClass="ckAtivo" Checked="True" />
                </div>
                <div class="botoes">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn_inserir" OnClick="btnSalvar_Click" />
                    <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn_deletar" OnClick="btnDeletar_Click" />
                    <asp:Button ID="BtnClear" runat="server" Text="Limpar" CssClass="btn_limpar" OnClick="BtnClear_Click" />
                </div>
            </div>
            <div class="bloco-tabela">
                <asp:ListView ID="ListViewClientes" runat="server" ViewStateMode="Enabled" DataKeyNames="ID" DataSourceID="SqlDataSourceListaClientes" OnItemCommand="ListViewClientes_ItemCommand">
                    <AlternatingItemTemplate>
                        <tr>
                            <td class="table-td">
                                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="Data_NascLabel" runat="server" Text='<%# Eval("[Data Nasc]", "{0:dd/MM/yyyy}") %>' />
                            </td>
                            <td class="table-td">
                                <asp:CheckBox ID="AtivoCheckBox" runat="server" Checked='<%# Eval("Ativo") %>' Enabled="false" />
                            </td>
                            <td class="selecionar-td">
                                <asp:LinkButton ID="lnkSelecionar" runat="server" CommandName="Select" CommandArgument='<%# Eval("ID") %>' Text="Selecionar" CssClass="selecionar" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>

                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr runat="server">
                                <th runat="server" class="table-th">ID</th>
                                <th runat="server" class="table-th">Nome</th>
                                <th runat="server" class="table-th">Email</th>
                                <th runat="server" class="table-th">Data Nasci.</th>
                                <th runat="server" class="table-th">Ativo</th>
                                <th runat="server" class="table-th">Ação</th>
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
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                            </td>
                            <td class="table-td">
                                <asp:Label ID="Data_NascLabel" runat="server" Text='<%# Eval("[Data Nasc]", "{0:dd/MM/yyyy}") %>' />
                            </td>
                            <td class="table-td">
                                <asp:CheckBox ID="AtivoCheckBox" runat="server" Checked='<%# Eval("Ativo") %>' Enabled="false" />
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
                                        <tr runat="server">
                                            <th runat="server" class="table-th">ID</th>
                                            <th runat="server" class="table-th">Nome</th>
                                            <th runat="server" class="table-th">Email</th>
                                            <th runat="server" class="table-th">Data Nasc</th>
                                            <th runat="server" class="table-th">Ativo</th>
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
                <asp:SqlDataSource ID="SqlDataSourceListaClientes" runat="server" ConnectionString="<%$ ConnectionStrings:LojaVirtualDbConnectionString %>" SelectCommand="SELECT [CLI_ID] AS Id, 
[CLI_NOME] AS Nome, 
[CLI_EMAIL] as  Email,
[CLI_DATANASCIMENTO] as [Data Nasc], 
[CLI_ATIVO] AS Ativo
FROM [CLIENTES]"></asp:SqlDataSource>
            </div>
        </div>
    </asp:Panel>
    <script type="text/javascript">
        var txtData = '<%= txtDataNascimento.ClientID %>';
    </script>
    <script src="../js/validaData.js" type="text/javascript"></script>
</asp:Content>

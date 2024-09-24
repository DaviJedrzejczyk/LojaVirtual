using Entities;
using Entities.DTOs;
using Services;
using Services.Interfaces;
using Services.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaVirtual___PresentationLayer.Pages
{
    public partial class pedidos : System.Web.UI.Page
    {
        private readonly ClienteService clientesService = new ClienteService();
        private readonly ProdutoService produtoService = new ProdutoService();
        private readonly PedidoService pedidoService = new PedidoService();
        protected async void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                VisibilidadeBotoes();
                await PreencheComboBoxs();
            }
        }

        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                long idPedido = !string.IsNullOrEmpty(this.txtID.Text) ? long.Parse(this.txtID.Text) : 0;
                List<string> produtosSelecionados = ProdutosSelecionados();
                List<int> quantiadeDosProdutos = QuantidadeDosProdutos(produtosSelecionados);

                string clienteEmail = this.dClientes.SelectedItem.Value;

                PedidoDTO pedido = new PedidoDTO(idPedido, clienteEmail, produtosSelecionados, quantiadeDosProdutos);

                Response response = await pedidoService.CriarPedido(pedido);

                if (!response.HasSuccess)
                {
                    string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);
                    return;
                }

                this.ListViewPedidos.DataBind();
                LimparCampos();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        private List<int> QuantidadeDosProdutos(List<string> produtosSelecionados)
        {
            List<int> quantidades = new List<int>();
            foreach (var produto in produtosSelecionados)
            {
                string inputName = "quantidade_" + produto;
                string quantidadeString = Request.Form[inputName];

                if (!string.IsNullOrEmpty(quantidadeString))
                {
                    quantidades.Add(int.Parse(quantidadeString));
                }
            }

            return quantidades;
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            LimparCampos();
            VisibilidadeBotoes();
        }

        private void LimparCampos()
        {
            this.txtID.Text = null;
            this.dClientes.SelectedIndex = 0;
        }

        private void VisibilidadeBotoes()
        {
            this.BtnClear.Enabled = !this.BtnClear.Enabled;
        }

        protected async void ddlAcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlAcoes = (DropDownList)sender;

            ListViewDataItem dataItem = (ListViewDataItem)ddlAcoes.NamingContainer;

            HiddenField hfID = (HiddenField)dataItem.FindControl("hfID");

            int pedidoId = Convert.ToInt32(hfID.Value);
            Response response = new Response();

            switch (ddlAcoes.SelectedValue)
            {
                case "Approve":
                    response = await pedidoService.AprovarPedido(pedidoId);
                    break;

                case "Cancel":
                    response = await pedidoService.CancelarPedido(pedidoId);
                    break;

                default:
                    response.Message = "Nenhuma ação foi executada.";
                    break;
            }

            string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);

            ddlAcoes.SelectedIndex = 0;
            this.ListViewPedidos.DataBind();
        }

        private async Task PreencheComboBoxs()
        {
            DataResponse<Cliente> response = await clientesService.BuscaTodos();

            DataResponse<Produto> responseProduto = await produtoService.BuscarTodosProdutos();

            foreach (var cliente in response.Data)
            {
                this.dClientes.Items.Add(cliente.Cli_Email);
            }

            foreach (var produto in responseProduto.Data)
            {
                this.dropProduto.Items.Add(produto.Prod_Nome);
            }
        }

        private List<string> ProdutosSelecionados()
        {
            List<String> selectedValues = new List<String>();
            foreach (ListItem item in this.dropProduto.Items)
            {
                if (item.Selected)
                    selectedValues.Add(item.Value);
            }
            return selectedValues;
        }

        protected void ListViewPedidos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var dataItem = (ListViewDataItem)e.Item;

                string status = DataBinder.Eval(dataItem.DataItem, "Status").ToString();

                DropDownList ddlAcoes = (DropDownList)e.Item.FindControl("ddlAcoes");

                if (status != "Em aprovação")
                {
                    ddlAcoes.Enabled = false;
                }
            }
        }
    }
}
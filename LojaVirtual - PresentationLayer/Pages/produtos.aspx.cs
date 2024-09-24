using Entities;
using Services;
using Services.Interfaces;
using Services.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LojaVirtual___PresentationLayer.Pages
{
    public partial class produtos : System.Web.UI.Page
    {
        private readonly ProdutoService produtoService = new ProdutoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VisibilidadeBotoes();
            }
        }

        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                long id = !string.IsNullOrWhiteSpace(this.txtID.Text) ? long.Parse(txtID.Text) : 0;

                double preco = !string.IsNullOrWhiteSpace(this.txtPreco.Text) ? RemoveFormatoMoeda(this.txtPreco.Text) : 0;

                int quantiade = !string.IsNullOrWhiteSpace(this.txtQuantidade.Text) ? int.Parse(txtQuantidade.Text) : 0;

                Produto produto = new Produto(id, this.txtNome.Text, preco, quantiade);

                Response response = await produtoService.SalvarProduto(produto);

                if (!response.HasSuccess)
                {
                    string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);
                }

                this.ListViewProduto.DataBind();
                LimparCampos();
                if (id > 0)
                {
                    VisibilidadeBotoes();
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected async void ListViewProdutos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int produtoId = Convert.ToInt32(e.CommandArgument);

                SingleResponse<Produto> response = await produtoService.BuscaProduto(produtoId);

                Produto produto = response.Item;

                if (produto != null)
                {
                    this.txtID.Text = produto.Prod_ID.ToString();
                    this.txtNome.Text = produto.Prod_Nome;
                    this.txtPreco.Text = produto.Prod_Preco.ToString("c2");
                    this.txtQuantidade.Text = produto.Prod_Quantidade.ToString();
                    VisibilidadeBotoes();
                }
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.btnDeletar.Visible = false;
        }

        protected async void btnDeletar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response response = await produtoService.DeletarProduto(int.Parse(this.txtID.Text));
                string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);
                LimparCampos();
                this.ListViewProduto.DataBind();
                VisibilidadeBotoes();
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void VisibilidadeBotoes()
        {
            this.btnDeletar.Visible = !this.btnDeletar.Visible;
        }

        private void LimparCampos()
        {
            this.txtID.Text = null;
            this.txtNome.Text = null;
            this.txtPreco.Text = null;
            this.txtQuantidade.Text = null;
        }

        private double RemoveFormatoMoeda(string valor)
        {
            return Convert.ToDouble(valor.Replace("R$", "").Trim());
        }
    }
}
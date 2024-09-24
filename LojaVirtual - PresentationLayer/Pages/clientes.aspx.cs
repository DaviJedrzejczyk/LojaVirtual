using Entities;
using Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaVirtual___PresentationLayer.Pages
{
    public partial class Clientes : System.Web.UI.Page
    {
        ClienteService clienteService = new ClienteService();

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


                long id = !string.IsNullOrWhiteSpace(txtID.Text) ? long.Parse(txtID.Text) : 0;
                DateTime? data = !string.IsNullOrWhiteSpace(this.txtDataNascimento.Text) ? DateTime.Parse(this.txtDataNascimento.Text) : (DateTime?)null;

                Cliente cliente = new Cliente(id, this.txtEmail.Text, this.txtNome.Text, data, this.ckAtivo.Checked);

                Response response = await clienteService.SalvarCliente(cliente);

                if (!response.HasSuccess)
                {
                    string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);
                }

                this.ListViewClientes.DataBind();
                LimparCampos();
                if (id > 0)
                {
                    VisibilidadeBotoes();
                }
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ListViewClientes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int clienteId = Convert.ToInt32(e.CommandArgument);

                Cliente cliente = clienteService.BuscaPorId(clienteId).Item;

                if (cliente != null)
                {
                    this.txtID.Text = cliente.Cli_Id.ToString();
                    this.txtNome.Text = cliente.Cli_Nome;
                    this.txtDataNascimento.Text = cliente.Cli_DataNascimento.Value.ToString("dd-MM-yyyy");
                    this.ckAtivo.Checked = cliente.Cli_Ativo;
                    this.txtEmail.Text = cliente.Cli_Email;
                    VisibilidadeBotoes();
                }
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            LimparCampos();
            VisibilidadeBotoes();
        }

        protected async void btnDeletar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response response = await clienteService.DeletarCliente(int.Parse(this.txtID.Text));
                string responseMessage = HttpUtility.JavaScriptStringEncode(response.Message).Replace("\r\n", "\\n");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", $"alert('{responseMessage}');", true);
                LimparCampos();
                this.ListViewClientes.DataBind();
                VisibilidadeBotoes();
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void LimparCampos()
        {
            this.txtID.Text = null;
            this.txtNome.Text = null;
            this.txtDataNascimento.Text = null;
            this.txtEmail.Text = null;
        }

        private void VisibilidadeBotoes()
        {
            this.btnDeletar.Visible = !this.btnDeletar.Visible;
            this.ckAtivo.Enabled = !this.ckAtivo.Enabled;
        }

    }
}
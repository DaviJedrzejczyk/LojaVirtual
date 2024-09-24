using BusinessLogicalLayer.Extensions;
using DataAccessLayer.Impl;
using Entities;
using Entities.DTOs;
using Entities.Enums;
using FluentValidation;
using Services.Interfaces;
using Services.Validators.Clientes;
using Services.Validators.Pedidos;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoDAL pedidoDAL = new PedidoDAL();
        private readonly ProdutoService produtoService = new ProdutoService();
        private readonly ProdutoPedidoService produtoPedidoService = new ProdutoPedidoService();
        private readonly ClienteService clienteService = new ClienteService();

        public async Task<Response> AprovarPedido(int id)
        {
            try
            {
                Response response = await pedidoDAL.AprovarPedido(id);
                return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<SingleResponse<Pedido>> BuscarPedido(int id)
        {
            try
            {
                SingleResponse<Pedido> response = await pedidoDAL.BuscarPedido(id);

                if (!response.HasSuccess)
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>(response.Message);

                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(response.Item);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>(ex);
            }
        }

        public async Task<Response> CancelarPedido(int id)
        {
            try
            {
                Response response = await pedidoDAL.CancelarPedido(id);
                return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> CriarPedido(PedidoDTO pedido)
        {
            try
            {
                if(pedido.ProdutosSelecionados.Count <= 0)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Pedido deve ser preenchido.");

                if (pedido.QuantidadeDosProdutos.Count <= 0)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("O Produto deve ter sua quantidade preenchida.");


                SingleResponse<Pedido> pedidoPreparado = await PreparaPedido(pedido);

                if (!pedidoPreparado.HasSuccess)
                    return ResponseFactory.CreateInstance().CreateFailureResponse(pedidoPreparado.Message);

                ValidarPedidoPreparado(pedidoPreparado.Item);

                Response salvarPedidoResponse = await pedidoDAL.CriarPedido(pedidoPreparado.Item);

                if (!salvarPedidoResponse.HasSuccess)
                    return ResponseFactory.CreateInstance().CreateFailureResponse(salvarPedidoResponse.Message);

                return await PreparaPedidoProduto(pedido, pedidoPreparado);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        private async Task<Response> PreparaPedidoProduto(PedidoDTO pedido, SingleResponse<Pedido> pedidoPreparado)
        {
            foreach (var produto in pedido.ProdutosSelecionados)
            {
                SingleResponse<Produto> produtoResponse = await produtoService.BuscaProdutoPorNome(produto);
                if (produtoResponse.HasSuccess)
                {
                    ProdutoPedido produtoPedido = new ProdutoPedido(produtoResponse.Item.Prod_ID, pedidoPreparado.Item.Ped_Id);

                    Response salvarProdutoPedidoResponse = await produtoPedidoService.InserirProdutoPedido(produtoPedido);

                    if (!salvarProdutoPedidoResponse.HasSuccess)
                        return ResponseFactory.CreateInstance().CreateFailureResponse(salvarProdutoPedidoResponse.Message);
                }
            }

            return ResponseFactory.CreateInstance().CreateSuccessResponse();
        }

        private async Task<SingleResponse<Pedido>> PreparaPedido(PedidoDTO pedidoDto)
        {
            Cliente cliente = await BuscaCliente(pedidoDto.Cli_Email);
            pedidoDto.Ped_Data = DateTime.Now;
            pedidoDto.Cli_Id = cliente.Cli_Id;
            pedidoDto.EStatusPedido = EStatusPedido.EM_APROVACAO;

            for (int i = 0; i < pedidoDto.ProdutosSelecionados.Count; i++)
            {
                string nome = pedidoDto.ProdutosSelecionados[i];
                int quantidade = pedidoDto.QuantidadeDosProdutos[i];

                SingleResponse<Produto> response = await produtoService.BuscaProdutoPorNome(nome);

                Produto produto = response.Item;

                if (produto == null)
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>("Produto não encontrado.");

                if (produto.Prod_Quantidade < quantidade)
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>("A quantidade do pedido não pode ser maior que a do estoque.");

                pedidoDto.Ped_Valor += quantidade * produto.Prod_Preco;
                pedidoDto.Ped_Quantidade += quantidade;
                produto.Prod_Quantidade -= quantidade;

                Response salvarProdutoResponse = await produtoService.SalvarProduto(produto);
                if (!salvarProdutoResponse.HasSuccess)
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>(salvarProdutoResponse.Message);
                }

            }

            Pedido pedido = new Pedido(pedidoDto);

            return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(pedido);
        }

        private async Task<Cliente> BuscaCliente(string cli_Email)
        {
            SingleResponse<Cliente> singleResponse = await clienteService.BuscaPorEmail(cli_Email);
            if (!singleResponse.HasSuccess)
                throw new Exception(singleResponse.Message);

            return singleResponse.Item;
        }

        private void ValidarPedidoPreparado(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "Pedido deve ser informado");

            Response response = pedido.Ped_Id == 0
                ? new PedidoInsertValidator().Validate(pedido).ConvertToResponse()
                : new PedidoEditValidator().Validate(pedido).ConvertToResponse();

            if (!response.HasSuccess)
                throw new InvalidOperationException(response.Message);
        }
    }
}

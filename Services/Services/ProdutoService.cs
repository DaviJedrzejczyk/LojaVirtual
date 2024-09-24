using BusinessLogicalLayer.Extensions;
using DataAccessLayer.Impl;
using DataAccessLayer.Interfaces;
using Entities;
using Services.Interfaces;
using Services.Validators.Produtos;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoDAL produtoDAL = new ProdutoDAL();
        public async Task<Response> SalvarProduto(Produto produto)
        {
            try
            {
                ValidarProduto(produto);
                await produtoDAL.SalvarProduto(produto);
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> DeletarProduto(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Este id é inválido");
                }

                await produtoDAL.DeletarProduto(id);
                return ResponseFactory.CreateInstance().CreateSuccessResponse("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex.Message);
            }
        }

        public async Task<SingleResponse<Produto>> BuscaProduto(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>("Produto selecionado inválido");
                }

                return await produtoDAL.BuscarProduto(id);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>(ex);
            }
        }

        private void ValidarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto deve ser informado");

            Response response = produto.Prod_ID == 0
                ? new ProdutoInsertValidator().Validate(produto).ConvertToResponse()
                : new ProdutoEditValidator().Validate(produto).ConvertToResponse();

            if (!response.HasSuccess)
            {
                throw new InvalidOperationException(response.Message);
            }
        }
        public async Task<DataResponse<Produto>> BuscarTodosProdutos()
        {
            try
            {
                DataResponse<Produto> dataResponse = await produtoDAL.BuscarTodosProdutos();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Produto>(ex);
            }
        }

        public async Task<SingleResponse<Produto>> BuscaProdutoPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>("Nome do produto inválido.");
                }

                return await produtoDAL.BuscaProdutoPorNome(nome);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>(ex);
            }
        }
    }
}

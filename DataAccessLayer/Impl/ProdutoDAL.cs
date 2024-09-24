using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class ProdutoDAL : IProdutoDAL
    {
        public async Task<Response> SalvarProduto(Produto produto)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    if (produto.Prod_ID != 0) 
                        return await EditarProduto(produto, context, true);
                    
                    SingleResponse<Produto> single = await BuscaProdutoPorNome(produto.Prod_Nome);

                    if (!single.HasSuccess)
                    {
                        context.Produtos.Add(produto);
                        await context.SaveChangesAsync();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse();
                    }

                    return await EditarProduto(single.Item, context, false);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
       
        private async Task<Response> EditarProduto(Produto produto, LojaVirtualDbContext context, bool isEditing)
        {

            try
            {
                Produto produtoAtual = await context.Produtos.FindAsync(produto.Prod_ID);

                if (produtoAtual == null)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Produto não encontrado");

                produtoAtual.Prod_ID = produto.Prod_ID;
                produtoAtual.Prod_Preco = produto.Prod_Preco;
                produtoAtual.Prod_Nome = produto.Prod_Nome;
                
                if (isEditing)
                    produtoAtual.Prod_Quantidade = produto.Prod_Quantidade;
                else
                    produtoAtual.Prod_Quantidade += produto.Prod_Quantidade;

                await context.SaveChangesAsync();

                return ResponseFactory.CreateInstance().CreateSuccessResponse("Produto editado com sucesso!");

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
                using (var context = new LojaVirtualDbContext())
                {
                    SingleResponse<Produto> response = await BuscarProduto(id);
                    if (!response.HasSuccess)
                    {
                        return ResponseFactory.CreateInstance().CreateFailureResponse(response.Message);
                    }

                    context.Produtos.Attach(response.Item);
                    context.Produtos.Remove(response.Item);
                    await context.SaveChangesAsync();

                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
        public async Task<SingleResponse<Produto>> BuscarProduto(int id)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    Produto produto = await context.Produtos.FirstOrDefaultAsync(c => c.Prod_ID == id);

                    if (produto == null)
                    {
                        return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>("Esse produto não existe!");
                    }

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(produto);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>(ex);
            }
        }

        public async Task<DataResponse<Produto>> BuscarTodosProdutos()
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    return ResponseFactory.CreateInstance().CreateSuccessDataResponse(await context.Produtos.ToListAsync());
                }
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
                using (var context = new LojaVirtualDbContext())
                {
                    Produto produto = await context.Produtos.FirstOrDefaultAsync(c => c.Prod_Nome == nome);

                    if (produto == null)
                    {
                        return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>("Esse produto não existe!");
                    }

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(produto);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Produto>(ex);
            }
        }
    }
}


using DataAccessLayer.Interfaces;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class ProdutoPedidoDAL : IProdutoPedidoDAL
    {
        public async Task<Response> InserirProdutoPedido(ProdutoPedido produtoPedido)
        {
            try
            {
                using(var context = new LojaVirtualDbContext())
                {
                    context.ProdutosPedidos.Add(produtoPedido);
                    await context.SaveChangesAsync();
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
    }
}

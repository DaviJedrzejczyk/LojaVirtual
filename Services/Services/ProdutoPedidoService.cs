using DataAccessLayer.Impl;
using Entities;
using Services.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProdutoPedidoService : IProdutoPedidoService
    {
        private readonly ProdutoPedidoDAL produtoPedidoDAL = new ProdutoPedidoDAL();

        public async Task<Response> InserirProdutoPedido(ProdutoPedido produtoPedido)
        {
            try
            {
                Response response = await produtoPedidoDAL.InserirProdutoPedido(produtoPedido);
                return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
            }
            catch (Exception ex) 
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
    }
}

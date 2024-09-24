using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enums;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class PedidoDAL : IPedidoDAL
    {
        public async Task<Response> AprovarPedido(int id)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    Pedido pedido = await context.Pedidos.FindAsync(id);

                    if (pedido == null)
                        return ResponseFactory.CreateInstance().CreateFailureResponse("Pedido não encontrado.");
                    
                    pedido.Ped_Status = EStatusPedido.APROVADO;

                    await context.SaveChangesAsync();
                    return ResponseFactory.CreateInstance().CreateSuccessResponse("Pedido Aprovado!");
                }
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
                using (var context = new LojaVirtualDbContext())
                {
                    Pedido pedido = await context.Pedidos.FirstOrDefaultAsync(c => c.Ped_Id == id);
                    
                    if (pedido == null)
                        return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Pedido>("Não foi possivel achar este pedido");

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(pedido);
                }
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
                using(var context = new LojaVirtualDbContext())
                {
                    Pedido pedido = await context.Pedidos.FindAsync(id);

                    if (pedido == null)
                        return ResponseFactory.CreateInstance().CreateFailureResponse("Pedido não encontrado.");

                    pedido.Ped_Status = EStatusPedido.CANCELADO;

                    await context.SaveChangesAsync();
                    return ResponseFactory.CreateInstance().CreateSuccessResponse("Pedido Cancelado!");
                }
            }
            catch (Exception ex) 
            { 
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> CriarPedido(Pedido pedido)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    context.Pedidos.Add(pedido);
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

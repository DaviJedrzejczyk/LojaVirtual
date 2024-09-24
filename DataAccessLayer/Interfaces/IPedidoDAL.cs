using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPedidoDAL
    {
        Task<Response> CriarPedido(Pedido pedido);
        Task<Response> CancelarPedido(int id);
        Task<SingleResponse<Pedido>> BuscarPedido(int id);
        Task<Response> AprovarPedido(int id);
    }
}

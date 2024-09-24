using Entities;
using Entities.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Response> CriarPedido(PedidoDTO pedido);
        Task<Response> CancelarPedido(int id);
        Task<SingleResponse<Pedido>> BuscarPedido(int id);
        Task<Response> AprovarPedido(int id);
    }
}

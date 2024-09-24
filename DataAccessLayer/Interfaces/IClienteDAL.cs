using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IClienteDAL
    {
        Task<Response> SalvarCliente(Cliente cliente);
        Task<Response> DeletarCliente(int id);
        SingleResponse<Cliente> BuscaPorId(int id);
        Task<DataResponse<Cliente>> BuscaTodos();
    }
}

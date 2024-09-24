using DataAccessLayer.Interfaces;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class ClienteDAL : IClienteDAL
    {
        public async Task<Response> SalvarCliente(Cliente cliente)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    if (cliente.Cli_Id == 0)
                    {
                        context.Clientes.Add(cliente);
                        await context.SaveChangesAsync();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse();
                    }
                    else
                    {
                        return await EditarCliente(cliente, context);
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        private async Task<Response> EditarCliente(Cliente cliente, LojaVirtualDbContext context)
        {
            try
            {
                Cliente clienteAtual = await context.Clientes.FindAsync(cliente.Cli_Id);

                if (clienteAtual == null)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Cliente não encontrado");

                clienteAtual.Cli_Id = cliente.Cli_Id;
                clienteAtual.Cli_DataNascimento = cliente.Cli_DataNascimento;
                clienteAtual.Cli_Ativo = cliente.Cli_Ativo;
                clienteAtual.Cli_Nome = cliente.Cli_Nome;
                clienteAtual.Cli_Email = cliente.Cli_Email;

                await context.SaveChangesAsync();

                return ResponseFactory.CreateInstance().CreateSuccessResponse("Cliente editado com sucesso!");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> DeletarCliente(int id)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    SingleResponse<Cliente> response = BuscaPorId(id);
                    if (!response.HasSuccess)
                    {
                        return ResponseFactory.CreateInstance().CreateFailureResponse(response.Message);
                    }

                    context.Clientes.Attach(response.Item);
                    context.Clientes.Remove(response.Item);
                    await context.SaveChangesAsync();

                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public SingleResponse<Cliente> BuscaPorId(int id)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    Cliente cliente = context.Clientes.FirstOrDefault(c => c.Cli_Id == id);

                    if (cliente == null)
                        return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>("Esse cliente não existe!");

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(cliente);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>(ex);
            }
        }

        public async Task<DataResponse<Cliente>> BuscaTodos()
        {
            try
            {
                using(var context = new LojaVirtualDbContext())
                {
                    return ResponseFactory.CreateInstance().CreateSuccessDataResponse(await context.Clientes.ToListAsync());
                }
            }
            catch (Exception ex) {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Cliente>(ex);
            }

        }

        public async Task<SingleResponse<Cliente>> BuscaPorEmail(string email)
        {
            try
            {
                using (var context = new LojaVirtualDbContext())
                {
                    Cliente cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Cli_Email == email);

                    if (cliente == null)
                        return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>("Esse cliente não existe!");

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(cliente);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>(ex);
            }
        }
    }
}

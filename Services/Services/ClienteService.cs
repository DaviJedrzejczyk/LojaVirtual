using BusinessLogicalLayer.Extensions;
using DataAccessLayer.Impl;
using Entities;
using Services.Interfaces;
using Services.Validators.Clientes;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteDAL clienteDAL = new ClienteDAL();
        public async Task<Response> SalvarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                await clienteDAL.SalvarCliente(cliente);
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
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
                if (id <= 0)
                {
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Este id é inválido");
                }

                await clienteDAL.DeletarCliente(id);
                return ResponseFactory.CreateInstance().CreateSuccessResponse("Cliente deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex.Message);
            }
        }

        public SingleResponse<Cliente> BuscaPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>("Cliente selecionado inválido.");
                }

                return clienteDAL.BuscaPorId(id);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>(ex);
            }
        }

        public async Task<SingleResponse<Cliente>> BuscaPorEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>("Email do cliente deve ser informado.");

                return await clienteDAL.BuscaPorEmail(email);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Cliente>(ex);
            }
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "Cliente deve ser informado");
            }

            Response response = cliente.Cli_Id == 0
                ? new ClienteInsertValidator().Validate(cliente).ConvertToResponse()
                : new ClienteEditValidator().Validate(cliente).ConvertToResponse();

            if (!response.HasSuccess)
            {
                throw new InvalidOperationException(response.Message);
            }
        }

        public async Task<DataResponse<Cliente>> BuscaTodos()
        {
            try
            {
                DataResponse<Cliente> response = await clienteDAL.BuscaTodos();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(response.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Cliente>(ex);
            }
        }
    }
}

using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseFactory
    {
        private static ResponseFactory _factory;
        public static ResponseFactory CreateInstance()
        {
            if (_factory == null)
            {
                _factory = new ResponseFactory();
            }
            return _factory;
        }

        public Response CreateSuccessResponse() => new Response()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO
        };
        public Response CreateSuccessResponse(string message) => new Response()
        {
            HasSuccess = true,
            Message = message
        };
        public Response CreateFailureResponse() => new Response()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA
        };
        public Response CreateFailureResponse(string message) => new Response()
        {
            HasSuccess = false,
            Message = message
        };
        public Response CreateFailureResponse(Exception ex) => new Response()
        {
            HasSuccess = false,
            Message = ex.Message,
            Exception = ex
        };
        public SingleResponse<T> CreateSuccessSingleResponse<T>(T item) => new SingleResponse<T>()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO,
            Item = item
        };
        public SingleResponse<T> CreateFailureSingleResponse<T>() => new SingleResponse<T>()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
        };

        public SingleResponse<T> CreateFailureSingleResponse<T>(string message) => new SingleResponse<T>()
        {
            HasSuccess = false,
            Message = message,
        };
        public SingleResponse<T> CreateFailureSingleResponse<T>(Exception ex) => new SingleResponse<T>()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
            Exception = ex
        };

        public DataResponse<T> CreateSuccessDataResponse<T>(List<T> Itens) => new DataResponse<T>()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO,
            Data = Itens,
        };
        public DataResponse<T> CreateFailureDataResponse<T>() => new DataResponse<T>()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(string message) => new DataResponse<T>()
        {
            HasSuccess = false,
            Message = message,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(Exception ex) => new DataResponse<T>()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
            Exception = ex
        };
    }
}

using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public interface IProdutoDAL
    {
        Task<Response> SalvarProduto(Produto produto);
        Task<Response> DeletarProduto(int id);
        Task<SingleResponse<Produto>> BuscarProduto(int id);
        Task<DataResponse<Produto>> BuscarTodosProdutos();
        Task<SingleResponse<Produto>> BuscaProdutoPorNome(string nome);
    }
}

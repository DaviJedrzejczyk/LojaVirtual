using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Response> SalvarProduto(Produto produto);
        Task<Response> DeletarProduto(int id);
        Task<SingleResponse<Produto>> BuscaProduto(int id);
        Task<DataResponse<Produto>> BuscarTodosProdutos();
        Task<SingleResponse<Produto>> BuscaProdutoPorNome(string nome);

    }
}

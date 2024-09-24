using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Constants
{
    internal class ProdutoConstants
    {
        public const string MENSAGEM_ERRO_PRECO_NULO = "O preço deve ser informado.";
        public const string MENSAGEM_ERRO_PRECO_MENOR_QUE_ZERO = "O preço deve ser maior que 0,01.";
        public const string MENSAGEM_ERRO_QUANTIDADE_NULO = "A quantidade deve ser informada.";
        public const string MENSAGEM_ERRO_QUANTIDADE_MENOR_QUE_ZERO = "A quantidade deve ser maior que zero.";

    }
}

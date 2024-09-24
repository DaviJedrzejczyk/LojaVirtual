using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Produtos
{
    internal class ProdutoInsertValidator : ProdutoValidator
    {
        public ProdutoInsertValidator() {
            base.ValidateNome();
            base.ValidatePreco();
            base.ValidateQuantidade();
        }
    }
}

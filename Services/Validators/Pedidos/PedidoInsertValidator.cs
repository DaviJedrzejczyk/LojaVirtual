using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Pedidos
{
    internal class PedidoInsertValidator : PedidoValidator
    {
        public PedidoInsertValidator()
        {
            base.ValidateIDCliente();
            base.ValidateData();
            base.ValidatePreco();
        }
    }
}

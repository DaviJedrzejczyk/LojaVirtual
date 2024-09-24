using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Pedidos
{
    internal class PedidoEditValidator : PedidoValidator
    {
        public PedidoEditValidator()
        {
            base.ValidateIDCliente();
            base.ValidateData();
            base.ValidatePreco();
            base.ValidateID();
        }
    }
}

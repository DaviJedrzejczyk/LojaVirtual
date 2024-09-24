using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Clientes
{
    internal class ClienteInsertValidator : ClienteValidator
    {
        public ClienteInsertValidator()
        {
            base.ValidateNome();
            base.ValidateDataNascimento();
            base.ValidateEmail();
        }
    }
}

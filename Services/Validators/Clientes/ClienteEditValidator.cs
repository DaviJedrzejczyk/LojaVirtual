using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Clientes
{
    internal class ClienteEditValidator : ClienteValidator
    {
        public ClienteEditValidator()
        {
            base.ValidateID();
            base.ValidateNome();
            base.ValidateDataNascimento();
            base.ValidateEmail();
        }
    }
}

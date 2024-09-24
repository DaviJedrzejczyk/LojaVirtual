using Entities;
using FluentValidation;
using Services.Validators.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Clientes
{
    internal class ClienteValidator : AbstractValidator<Cliente>
    {
        public void ValidateID()
        {
            RuleFor(c => c.Cli_Id).NotNull().WithMessage(GenericConstants.MENSAGEM_ERRO_ID_VAZIO);
        }

        public void ValidateNome()
        {
            RuleFor(c => c.Cli_Nome).NotEmpty().WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_VAZIO)
                               .MinimumLength(2).WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_CURTO)
                               .MaximumLength(30).WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_GRANDE);

        }

        public void ValidateDataNascimento()
        {
            RuleFor(c => c.Cli_DataNascimento)
                .NotNull().WithMessage(ClienteConstants.MENSAGEM_ERRO_DATA_NASCIMENTO_VAZIO);
        }

        public void ValidateEmail()
        {
            RuleFor(c => c.Cli_Email)
                .NotEmpty().WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_VAZIO)
                .EmailAddress().WithMessage(ClienteConstants.MENSAGEM_ERRO_EMAIL_INVALIDO);

        }
    }
}

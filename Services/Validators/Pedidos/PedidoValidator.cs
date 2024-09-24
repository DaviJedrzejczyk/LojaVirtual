using Entities;
using FluentValidation;
using Services.Validators.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Pedidos
{
    internal class PedidoValidator : AbstractValidator<Pedido>
    {
        public void ValidateID()
        {
            RuleFor(c => c.Ped_Id).NotNull().WithMessage(GenericConstants.MENSAGEM_ERRO_ID_VAZIO);
        }

        public void ValidatePreco()
        {
            RuleFor(c => c.Ped_Valor)
                .NotNull().WithMessage(ProdutoConstants.MENSAGEM_ERRO_PRECO_NULO)
                .GreaterThan(0.01).WithMessage(ProdutoConstants.MENSAGEM_ERRO_PRECO_MENOR_QUE_ZERO);
        }
        public void ValidateData()
        {
            RuleFor(c => c.Ped_Data)
                .NotNull().WithMessage(ClienteConstants.MENSAGEM_ERRO_DATA_NASCIMENTO_VAZIO);
        }

        public void ValidateIDCliente()
        {
            RuleFor(c => c.Cli_Id).NotNull().WithMessage(GenericConstants.MENSAGEM_ERRO_ID_VAZIO);
        }

    }
}

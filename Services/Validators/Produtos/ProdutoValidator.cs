using Entities;
using FluentValidation;
using Services.Validators.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Produtos
{
    internal class ProdutoValidator : AbstractValidator<Produto>
    {
        public void ValidateID()
        {
            RuleFor(c => c.Prod_ID).NotNull().WithMessage(GenericConstants.MENSAGEM_ERRO_ID_VAZIO);
        }

        public void ValidateNome()
        {
            RuleFor(c => c.Prod_Nome).NotEmpty().WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_VAZIO)
                               .MinimumLength(2).WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_CURTO)
                               .MaximumLength(30).WithMessage(GenericConstants.MENSAGEM_ERRO_NOME_GRANDE);

        }

        public void ValidatePreco()
        {
            RuleFor(c => c.Prod_Preco)
                .NotNull().WithMessage(ProdutoConstants.MENSAGEM_ERRO_PRECO_NULO)
                .GreaterThan(0.01).WithMessage(ProdutoConstants.MENSAGEM_ERRO_PRECO_MENOR_QUE_ZERO);
        }
        public void ValidateQuantidade()
        {
            RuleFor(c => c.Prod_Quantidade)
                .NotNull().WithMessage(ProdutoConstants.MENSAGEM_ERRO_QUANTIDADE_NULO)
                .GreaterThan(0).WithMessage(ProdutoConstants.MENSAGEM_ERRO_QUANTIDADE_MENOR_QUE_ZERO);
        }
    }
}

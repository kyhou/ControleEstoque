using ControleEstoqueLibrary;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary.Validators
{
    public class PessoaValidator: AbstractValidator<PessoaModelo>
    {
        public PessoaValidator()
        {
            RuleFor(pessoa => pessoa.Id).Cascade(CascadeMode.StopOnFirstFailure).NotNull();
            RuleFor(pessoa => pessoa.Nome).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(pessoa => pessoa.CPF).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
        }
    }
}

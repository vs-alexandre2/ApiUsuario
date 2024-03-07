using ApiTarefa.ApiTarefa.Domain.Enums;
using ApiTarefa.ApiTarefa.Domain.Models;
using FluentValidation;
using System.Data;

namespace ApiTarefa.ApiTarefa.Domain.Validations
{
    public class TarefaValidator : AbstractValidator<TarefaModel>
    {
        public TarefaValidator()
        {
            RuleFor(t => t.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório!")
                .MaximumLength(40)
                .WithMessage("O Nome deve conter no máximo 40 caracteres!");

            RuleFor(t => t.Descricao)
                .NotEmpty()
                .WithMessage("A Descrição é obrigatória!")
                .MaximumLength(200)
                .WithMessage("A Descrição deve conter no máximo 200 caracteres!");

            RuleFor(t => t.Responsavel)
                .NotEmpty()
                .WithMessage("O Responsável é obrigatório!")
                .MaximumLength(20)
                .WithMessage("O Responsável deve conter no máximo 20 caracteres!");

            RuleFor(t => t.Situacao)
                .IsInEnum()
                .WithMessage("Situação inválida!");
        }
    }
}

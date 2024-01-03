using ApiUsuario.ApiUsuario.Domain.Enums;
using ApiUsuario.ApiUsuario.Domain.Models;
using FluentValidation;
using System.Data;

namespace ApiUsuario.ApiUsuario.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório!")
                .MaximumLength(20)
                .WithMessage("O nome deve conter no máximo 20 caracteres!");

            RuleFor(u => u.Sobrenome)
                .NotEmpty()
                .WithMessage("O Sobrenome é obrigatório!")
                .MaximumLength(100)
                .WithMessage("O Sobrenome deve conter no máximo 100 caracteres!");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido!")
                .MaximumLength(50)
                .WithMessage("O E-mail deve conter no máximo 50 caracteres!");

            var data = DateTime.Now;
            var dataMaiorQuinze = new DateTime(year: data.Year - 15, data.Month, data.Day + 1);

            RuleFor(u => u.DataNascimento)
                .LessThan(dataMaiorQuinze)
                .WithMessage("O usuário não pode ter menos de 15 anos!");

            RuleFor(u => u.Escolaridade)
                .IsInEnum()
                .WithMessage("Escolaridade inválida!");
        }
    }
}

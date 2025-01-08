using AutoresEFrasesAplicacao.DTOs;
using FluentValidation;

namespace AutoresEFrasesAplicacao.Validadores;

public class POSTAutorDTOValidador : AbstractValidator<POSTAutorDTO>
{
    public POSTAutorDTOValidador()
    {
        RuleFor(x => x.nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório.")
            .MaximumLength(50)
            .WithMessage("Nome pode ter no máximo 50 caracteres.");

        RuleFor(x => x.sobrenome)
            .NotEmpty()
            .WithMessage("Sobrenome é obrigatório.")
            .MaximumLength(100)
            .WithMessage("Sobrenome pode ter no máximo 100 caracteres.");

        RuleFor(x => x.nascimento)
            .NotEmpty()
            .WithMessage("Data de nascimento é obrigatório.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Data de nascimento não pode ser superior a data atual.");

        RuleFor(x => x.falecimento)
            .GreaterThanOrEqualTo(x => x.nascimento)
            .When(x => x.falecimento.HasValue)
            .WithMessage("Data de falecimento não pode ser inferior a data de nascimento.");
    }
}

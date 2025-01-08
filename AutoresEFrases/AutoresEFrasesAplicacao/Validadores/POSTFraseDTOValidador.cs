using AutoresEFrasesAplicacao.DTOs;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace AutoresEFrasesAplicacao.Validadores;

public class POSTFraseDTOValidador : AbstractValidator<POSTFraseDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public POSTFraseDTOValidador(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.frase)
            .NotEmpty()
            .WithMessage("A frase é obrigatória.")
            .MaximumLength(1000)
            .WithMessage("A frase pode ter no máximo 1000 caracteres.");

        RuleFor(x => x.autorId)
            .NotEmpty()
            .WithMessage("O autor da frase é obrigatório.")
            .MustAsync(async (autorId, cancellationToken) => 
            {
                if (!autorId.HasValue) return true;

                var existencia = await unitOfWork.AutorRepositorio.VerificarAutorPorIdAsync(autorId.Value);
                return existencia;
            })
            .WithMessage("O ID não está cadastrado.");
    }
}

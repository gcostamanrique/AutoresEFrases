using AutoresEFrasesAplicacao.DTOs;
using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesAplicacao.DTOsMapeamento;

public static class MapeamentoFrase
{
    public static GETFraseDTO? ParaFraseDTO(this Frase frase)
    {
        if (frase is null) { return null; }

        return new GETFraseDTO
        {
            id = frase.id,
            autorId = frase.autorId,
            frase = frase.frase,
            registrado = frase.registrado
        };
    }

    public static GETFraseEAutorDTO? ParaFraseEAutorDTO(this Frase frase)
    {
        if (frase is null) { return null; }

        return new GETFraseEAutorDTO
        {
            id = frase.id,
            autorId = frase.autorId,
            frase = frase.frase,
            registrado = frase.registrado,
            autor = frase.autor is null ? null : new GETAutorDTO
            {
                id = frase.autor.id,
                nome = frase.autor.nome,
                sobrenome = frase.autor.sobrenome,
                status = frase.autor.status,
                nascimento = frase.autor.nascimento,
                falecimento = frase.autor.falecimento
            }
        };
    }

    public static IEnumerable<GETFraseDTO> ParaColecaoFraseDTO(this IEnumerable<Frase> frases)
    {
        if (frases is null || !frases.Any()) { return new List<GETFraseDTO>(); }

        return frases.Select(frase => new GETFraseDTO
        {
            id = frase.id,
            autorId = frase.autorId,
            frase = frase.frase,
            registrado = frase.registrado
        }).ToList();
    }

    public static IEnumerable<GETFraseEAutorDTO> ParaColecaoFraseEAutorDTO(this IEnumerable<Frase> frases)
    {
        if (frases is null || !frases.Any()) { return new List<GETFraseEAutorDTO>(); }

        return frases.Select(frase => new GETFraseEAutorDTO
        {
            id = frase.id,
            autorId = frase.autorId,
            frase = frase.frase,
            registrado = frase.registrado,
            autor = frase.autor is null ? null : new GETAutorDTO
            {
                id = frase.autor.id,
                nome = frase.autor.nome,
                sobrenome = frase.autor.sobrenome,
                status = frase.autor.status,
                nascimento = frase.autor.nascimento,
                falecimento = frase.autor.falecimento
            }
        }).ToList();
    }

    public static Frase? ParaFrase(this GETFraseDTO fraseDTO)
    {
        if (fraseDTO is null) { return null; }

        return new Frase
        {
            id = fraseDTO.id,
            autorId = fraseDTO.autorId,
            frase = fraseDTO.frase,
            registrado = fraseDTO.registrado
        };
    }

    public static Frase ParaFrase(this POSTFraseDTO fraseDTO)
    {
        return new Frase
        {
            autorId = fraseDTO.autorId,
            frase = fraseDTO.frase,
        };
    }
}

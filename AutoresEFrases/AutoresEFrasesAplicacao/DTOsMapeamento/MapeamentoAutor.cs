using AutoresEFrasesAplicacao.DTOs;
using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesAplicacao.DTOsMapeamento;

public static class MapeamentoAutor
{
    public static GETAutorDTO? ParaAutorDTO(this Autor autor)
    {
        if (autor is null) { return null; }

        return new GETAutorDTO
        {
            id = autor.id,
            nome = autor.nome,
            sobrenome = autor.sobrenome,
            status = autor.status,
            nascimento = autor.nascimento,
            falecimento = autor.falecimento
        };
    }

    public static GETAutorEFraseDTO? ParaAutorEFraseDTO(this Autor autor)
    {
        if (autor is null) { return null; }

        return new GETAutorEFraseDTO
        {
            id = autor.id,
            nome = autor.nome,
            sobrenome = autor.sobrenome,
            status = autor.status,
            nascimento = autor.nascimento,
            falecimento = autor.falecimento,
            frase = autor.frase?.Select(f => new GETFraseDTO
            {
                id = f.id,
                autorId = f.autorId,
                frase = f.frase,
                registrado = f.registrado
            }).ToList()
        };
    }

    public static IEnumerable<GETAutorDTO>? ParaColecaoAutorDTO(this IEnumerable<Autor> autores)
    {
        if (autores is null || !autores.Any()) { return new List<GETAutorDTO>(); }

        return autores.Select(autor => new GETAutorDTO
        {
            id = autor.id,
            nome = autor.nome,
            sobrenome = autor.sobrenome,
            status = autor.status,
            nascimento = autor.nascimento,
            falecimento = autor.falecimento
        }).ToList();
    }

    public static IEnumerable<GETAutorEFraseDTO>? ParaColecaoAutorEFraseDTO(this IEnumerable<Autor> autores)
    {
        if (autores is null || !autores.Any()) { return new List<GETAutorEFraseDTO>(); }

        return autores.Select(autor => new GETAutorEFraseDTO
        {
            id = autor.id,
            nome = autor.nome,
            sobrenome = autor.sobrenome,
            status = autor.status,
            nascimento = autor.nascimento,
            falecimento = autor.falecimento,
            frase = autor.frase?.Select(f => new GETFraseDTO
            {
                id = f.id,
                autorId = f.autorId,
                frase = f.frase,
                registrado = f.registrado
            }).ToList()
        }).ToList();
    }

    public static Autor? ParaAutor(this GETAutorDTO autorDTO)
    {
        if (autorDTO is null) { return null; }

        return new Autor
        {
            id = autorDTO.id,
            nome = autorDTO.nome,
            sobrenome = autorDTO.sobrenome,
            status = autorDTO.status,
            nascimento = autorDTO.nascimento,
            falecimento = autorDTO.falecimento
        };
    }

    public static Autor ParaAutor(this POSTAutorDTO autorDTO)
    {
        return new Autor
        {
            nome = autorDTO.nome,
            sobrenome = autorDTO.sobrenome,
            nascimento = autorDTO.nascimento,
            falecimento = autorDTO.falecimento
        };
    }
}

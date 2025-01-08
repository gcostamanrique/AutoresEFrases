using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using AutoresEFrasesInfraestrutura.Dados;
using Microsoft.EntityFrameworkCore;

namespace AutoresEFrasesInfraestrutura.Repositorios;

public class AutorRepositorio : Repositorio<Autor>, IAutorRepositorio
{
    public AutorRepositorio(ContextoBancoDados contexto) : base(contexto)
    { }

    public async Task<IEnumerable<Autor>> BuscarAutorAsync()
    {
        return await BuscarTodosAsync(a => a.registro == true);
    }

    public async Task<IEnumerable<Autor>> BuscarAutorEFraseAsync()
    {
        return await _contexto.Autores.Where(a => a.registro == true).Include(a => a.frase.Where(f => f.registro == true)).ToListAsync();
    }

    public async Task<Autor> BuscarAutorEFrasePorIdAsync(int autorId)
    {
        var autorPorId = await _contexto.Autores.Where(a => a.id == autorId && a.registro == true).Include(a => a.frase.Where(f => f.registro == true)).FirstOrDefaultAsync();

        return autorPorId is null ? new Autor() : autorPorId;
    }

    public async Task<Autor> BuscarAutorPorIdAsync(int autorId)
    {
        var autorPorId = await BuscarAsync(a => a.id == autorId && a.registro == true);

        return autorPorId is null ? new Autor() : autorPorId;
    }

    public async Task<bool> VerificarAutorPorIdAsync(int autorId)
    {
        return await _contexto.Autores.AnyAsync(a => a.id == autorId && a.registro == true);
    }
}

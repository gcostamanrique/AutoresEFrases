using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using AutoresEFrasesInfraestrutura.Dados;
using Microsoft.EntityFrameworkCore;

namespace AutoresEFrasesInfraestrutura.Repositorios;

public class FraseRepositorio : Repositorio<Frase>, IFraseRepositorio
{
    public FraseRepositorio(ContextoBancoDados contexto) : base(contexto)
    { }

    public async Task<IEnumerable<Frase>> BuscarFraseAsync()
    {
        return await BuscarTodosAsync(f => f.registro == true);
    }

    public async Task<IEnumerable<Frase>> BuscarFraseEAutorAsync()
    {
        return await _contexto.Frases.Include(f => f.autor).Where(f => f.registro == true).ToListAsync();
    }

    public async Task<Frase> BuscarFraseEAutorPorIdAsync(int fraseId)
    {
        var frasePorId = await _contexto.Frases.Include(f => f.autor).Where(f => f.id == fraseId && f.registro == true).FirstOrDefaultAsync();

        return frasePorId is null ? new Frase() : frasePorId;
    }

    public async Task<Frase> BuscarFrasePorIdAsync(int fraseId)
    {
        var frasePorId = await BuscarAsync(f => f.id == fraseId && f.registro == true);

        return frasePorId is null ? new Frase() : frasePorId;
    }

    public async Task<IEnumerable<Frase>> BuscarFrasePorIdAutorAsync(int autorId)
    {
        return await _contexto.Frases.Where(f => f.autorId == autorId && f.registro == true).ToListAsync();
    }

    public async Task<bool> VerificarFrasePorIdAsync(int fraseId)
    {
        return await _contexto.Frases.AnyAsync(f => f.id == fraseId && f.registro == true);
    }
}

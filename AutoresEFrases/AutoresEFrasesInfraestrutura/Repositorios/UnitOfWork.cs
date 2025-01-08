using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using AutoresEFrasesInfraestrutura.Dados;
using Microsoft.EntityFrameworkCore;

namespace AutoresEFrasesInfraestrutura.Repositorios;

public class UnitOfWork : IUnitOfWork
{
    private IAutorRepositorio? _autorRepositorio;
    private IFraseRepositorio? _fraseRepositorio;
    public ContextoBancoDados _contexto;

    public UnitOfWork(ContextoBancoDados contexto)
    {
        _contexto = contexto;
    }

    public async Task Efetivar()
    {
        await _contexto.SaveChangesAsync();
    }

    public void Liberar()
    {
        _contexto.Dispose();
    }

    public IAutorRepositorio AutorRepositorio
    {
        get
        {
            return _autorRepositorio = _autorRepositorio ?? new AutorRepositorio(_contexto);
        }
    }

    public IFraseRepositorio FraseRepositorio
    {
        get
        {
            return _fraseRepositorio = _fraseRepositorio ?? new FraseRepositorio(_contexto);
        }
    }
}

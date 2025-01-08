using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using AutoresEFrasesInfraestrutura.Dados;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoresEFrasesInfraestrutura.Repositorios;

public class Repositorio<T> : IRepositorio<T> where T : class
{
    protected readonly ContextoBancoDados _contexto;

    public Repositorio(ContextoBancoDados contexto)
    {
        _contexto = contexto;
    }

    public T Atualizar(T entidade)
    {
        _contexto.Set<T>().Update(entidade);
        return entidade;
    }

    public IEnumerable<T> AtualizarIEnumerable(IEnumerable<T> entidades)
    {
        _contexto.Set<T>().UpdateRange(entidades);
        return entidades;
    }

    public async Task<T?> BuscarAsync(Expression<Func<T, bool>> predicate)
    {
        return await _contexto.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> BuscarTodosAsync(Expression<Func<T, bool>> predicate)
    {
        return await _contexto.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> BuscarTodosAsync()
    {
        return await _contexto.Set<T>().AsNoTracking().ToListAsync();
    }

    public T Criar(T entidade)
    {
        _contexto.Set<T>().Add(entidade);
        return entidade;
    }

    public T Deletar(T entidade)
    {
        _contexto.Set<T>().Remove(entidade);
        return entidade;
    }
}

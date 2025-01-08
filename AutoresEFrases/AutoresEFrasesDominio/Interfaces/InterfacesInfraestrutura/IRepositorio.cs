using System.Linq.Expressions;

namespace AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;

public interface IRepositorio<T>
{
    T Atualizar(T entidade);

    IEnumerable<T> AtualizarIEnumerable(IEnumerable<T> entidades);

    Task<T?> BuscarAsync(Expression<Func<T, bool>> predicado);

    Task<IEnumerable<T>> BuscarTodosAsync(Expression<Func<T, bool>> predicado);

    Task<IEnumerable<T>> BuscarTodosAsync();

    T Criar(T entidade);

    T Deletar(T entidade);
}

using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;

public interface IAutorRepositorio : IRepositorio<Autor>
{
    Task<IEnumerable<Autor>> BuscarAutorAsync();

    Task<IEnumerable<Autor>> BuscarAutorEFraseAsync();

    Task<Autor> BuscarAutorEFrasePorIdAsync(int autorId);

    Task<Autor> BuscarAutorPorIdAsync(int autorId);

    Task<bool> VerificarAutorPorIdAsync(int autorId);
}

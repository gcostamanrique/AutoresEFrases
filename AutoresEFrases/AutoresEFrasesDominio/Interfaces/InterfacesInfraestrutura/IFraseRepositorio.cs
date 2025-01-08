using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;

public interface IFraseRepositorio : IRepositorio<Frase>
{
    Task<IEnumerable<Frase>> BuscarFraseAsync();

    Task<IEnumerable<Frase>> BuscarFraseEAutorAsync();

    Task<Frase> BuscarFraseEAutorPorIdAsync(int fraseId);

    Task<Frase> BuscarFrasePorIdAsync(int fraseId);

    Task<IEnumerable<Frase>> BuscarFrasePorIdAutorAsync(int autorId);

    Task<bool> VerificarFrasePorIdAsync(int fraseId);
}

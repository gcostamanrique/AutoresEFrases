namespace AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;

public interface IUnitOfWork
{
    Task Efetivar();

    void Liberar();

    IAutorRepositorio AutorRepositorio { get; }

    IFraseRepositorio FraseRepositorio { get; }
}

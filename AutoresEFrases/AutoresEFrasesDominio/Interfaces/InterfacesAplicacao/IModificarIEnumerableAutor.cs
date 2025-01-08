using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

public interface IModificarIEnumerableAutor
{
    public IEnumerable<Autor> Modificar(IEnumerable<Autor> autores);
}

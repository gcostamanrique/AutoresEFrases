using AutoresEFrasesDominio.Entidades;

namespace AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

public interface IModificarIEnumerableFrase
{
    public IEnumerable<Frase> Modificar(IEnumerable<Frase> frases);
}

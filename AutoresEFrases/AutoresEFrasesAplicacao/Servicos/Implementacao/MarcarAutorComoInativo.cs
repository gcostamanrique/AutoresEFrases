using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos.Implementacao;

public class MarcarAutorComoInativo : IModificarAutor, IModificarIEnumerableAutor
{
    public Autor Modificar(Autor autor)
    {
        autor.registro = false;

        return autor;
    }

    public IEnumerable<Autor> Modificar(IEnumerable<Autor> autores)
    {
        foreach (var a in autores)
        {
            a.registro = false;
        }

        return autores;
    }
}

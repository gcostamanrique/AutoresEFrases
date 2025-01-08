using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos.Implementacao;

public class MarcarAutorComoAtivo : IModificarAutor, IModificarIEnumerableAutor
{
    public Autor Modificar(Autor autor)
    {
        autor.registro = true;

        return autor;
    }

    public IEnumerable<Autor> Modificar(IEnumerable<Autor> autores)
    {
        foreach (var a in autores)
        {
            a.registro = true;
        }

        return autores;
    }
}

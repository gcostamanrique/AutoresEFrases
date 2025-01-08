using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos.Implementacao;

public class GerarComplementoAutor : IModificarAutor
{
    public Autor Modificar(Autor autor)
    {
        autor.registro = true;

        if (!autor.falecimento.HasValue)
        {
            autor.status = true;
        }
        else
        {
            autor.status = false;
        }

        return autor;
    }
}

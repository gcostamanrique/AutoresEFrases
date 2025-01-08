using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;
using System.Diagnostics;

namespace AutoresEFrasesAplicacao.Servicos.Implementacao;

public class MarcarFraseComoInativo : IModificarFrase, IModificarIEnumerableFrase
{
    public Frase Modificar(Frase frase)
    {
        frase.registro = false;

        return frase;
    }

    public IEnumerable<Frase> Modificar(IEnumerable<Frase> frases)
    {
        foreach (var f in frases)
        {
            f.registro = false;
        }

        return frases;
    }
}

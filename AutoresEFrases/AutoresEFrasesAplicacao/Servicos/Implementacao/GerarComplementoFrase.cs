using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos.Implementacao;

public class GerarComplementoFrase : IModificarFrase
{
    public Frase Modificar(Frase frase)
    {
        frase.registro = true;

        frase.registrado = DateTime.Now;

        return frase;
    }
}

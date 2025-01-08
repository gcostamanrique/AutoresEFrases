using AutoresEFrasesAplicacao.Servicos.Fabrica;
using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Enumeracoes;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos;

public class Servico : IServico
{
    private readonly FabricaServico _fabrica;

    public Servico(FabricaServico fabrica)
    {
        _fabrica = fabrica;
    }

    public Autor ModificarAutor(Autor autor, TipoModificacaoAutor tipoModificacaoAutor)
    {
        var modificador = _fabrica.ObterModificacaoAutor(tipoModificacaoAutor);
        return modificador.Modificar(autor);
    }

    public IEnumerable<Autor> ModificarIEnumerableAutor(IEnumerable<Autor> autor, TipoModificacaoIEnumerableAutor tipoModificacaoIEnumerableAutor)
    {
        var modificador = _fabrica.ObterModificacaoIEnumerableAutor(tipoModificacaoIEnumerableAutor);
        return modificador.Modificar(autor);
    }

    public Frase ModificarFrase(Frase frase, TipoModificacaoFrase tipoModificacaoFrase)
    {
        var modificador = _fabrica.ObterModificacaoFrase(tipoModificacaoFrase);
        return modificador.Modificar(frase);
    }

    public IEnumerable<Frase> ModificarIEnumerableFrase(IEnumerable<Frase> frase, TipoModificacaoIEnumerableFrase tipoModificacaoIEnumerableFrase)
    {
        var modificador = _fabrica.ObterModificacaoIEnumerableFrase(tipoModificacaoIEnumerableFrase);
        return modificador.Modificar(frase);
    }
}

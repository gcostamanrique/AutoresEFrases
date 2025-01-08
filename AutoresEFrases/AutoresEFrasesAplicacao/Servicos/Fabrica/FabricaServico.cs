using AutoresEFrasesAplicacao.Servicos.Implementacao;
using AutoresEFrasesDominio.Enumeracoes;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

namespace AutoresEFrasesAplicacao.Servicos.Fabrica;

public class FabricaServico
{
    public IModificarAutor ObterModificacaoAutor(TipoModificacaoAutor tipoModificacaoAutor)
    {
        return tipoModificacaoAutor switch
        {
            TipoModificacaoAutor.GerarComplementoAutor => new GerarComplementoAutor(),
            TipoModificacaoAutor.MarcarAutorComoAtivo => new MarcarAutorComoAtivo(),
            TipoModificacaoAutor.MarcarAutorComoInativo => new MarcarAutorComoInativo(),
            _ => throw new NotImplementedException()
        };
    }

    public IModificarIEnumerableAutor ObterModificacaoIEnumerableAutor(TipoModificacaoIEnumerableAutor tipoModificacaoIEnumerableAutor)
    {
        return tipoModificacaoIEnumerableAutor switch
        {
            TipoModificacaoIEnumerableAutor.MarcarAutorComoAtivo => new MarcarAutorComoAtivo(),
            TipoModificacaoIEnumerableAutor.MarcarAutorComoInativo => new MarcarAutorComoInativo(),
            _ => throw new NotImplementedException()
        };
    }

    public IModificarFrase ObterModificacaoFrase(TipoModificacaoFrase tipoModificacaoFrase)
    {
        return tipoModificacaoFrase switch
        {
            TipoModificacaoFrase.GerarComplementoFrase => new GerarComplementoFrase(),
            TipoModificacaoFrase.MarcarFraseComoAtivo => new MarcarFraseComoAtivo(),
            TipoModificacaoFrase.MarcarFraseComoInativo => new MarcarFraseComoInativo(),
            _ => throw new NotImplementedException()
        };
    }

    public IModificarIEnumerableFrase ObterModificacaoIEnumerableFrase(TipoModificacaoIEnumerableFrase tipoModificacaoIEnumerableFrase)
    {
        return tipoModificacaoIEnumerableFrase switch
        {
            TipoModificacaoIEnumerableFrase.MarcarFraseComoAtivo => new MarcarFraseComoAtivo(),
            TipoModificacaoIEnumerableFrase.MarcarFraseComoInativo => new MarcarFraseComoInativo(),
            _ => throw new NotImplementedException()
        };
    }
}

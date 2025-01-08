using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesDominio.Enumeracoes;

namespace AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;

public interface IServico
{
    public Autor ModificarAutor(Autor autor, TipoModificacaoAutor tipoModificacaoAutor);

    public IEnumerable<Autor> ModificarIEnumerableAutor(IEnumerable<Autor> autor, TipoModificacaoIEnumerableAutor tipoModificacaoIEnumerableAutor);

    public Frase ModificarFrase(Frase frase, TipoModificacaoFrase tipoModificacaoFrase);

    public IEnumerable<Frase> ModificarIEnumerableFrase(IEnumerable<Frase> frase, TipoModificacaoIEnumerableFrase tipoModificacaoIEnumerableFrase);
}

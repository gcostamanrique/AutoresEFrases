namespace AutoresEFrasesDominio.Entidades;

public class Autor
{
    public int? id { get; set; }

    public bool? registro { get; set; }

    public string? nome { get; set; }

    public string? sobrenome { get; set; }

    public bool? status { get; set; }

    public DateTime? nascimento { get; set; }

    public DateTime? falecimento { get; set; }

    public ICollection<Frase>? frase { get; set; }
}

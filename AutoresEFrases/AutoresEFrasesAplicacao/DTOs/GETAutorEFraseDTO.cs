namespace AutoresEFrasesAplicacao.DTOs;

public class GETAutorEFraseDTO
{
    public int? id { get; set; }

    public string? nome { get; set; }

    public string? sobrenome { get; set; }

    public bool? status { get; set; }

    public DateTime? nascimento { get; set; }

    public DateTime? falecimento { get; set; }

    public ICollection<GETFraseDTO>? frase { get; set; }
}

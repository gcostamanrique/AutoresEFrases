namespace AutoresEFrasesAplicacao.DTOs;

public class GETAutorDTO
{
    public int? id { get; set; }

    public string? nome { get; set; }

    public string? sobrenome { get; set; }

    public bool? status { get; set; }

    public DateTime? nascimento { get; set; }

    public DateTime? falecimento { get; set; }
}

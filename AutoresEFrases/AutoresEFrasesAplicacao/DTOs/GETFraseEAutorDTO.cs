namespace AutoresEFrasesAplicacao.DTOs;

public class GETFraseEAutorDTO
{
    public int? id { get; set; }

    public int? autorId { get; set; }

    public string? frase { get; set; }

    public DateTime? registrado { get; set; }

    public GETAutorDTO? autor { get; set; }
}

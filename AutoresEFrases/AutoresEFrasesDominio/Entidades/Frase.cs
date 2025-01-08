namespace AutoresEFrasesDominio.Entidades;

public class Frase
{
    public int? id { get; set; }

    public int? autorId { get; set; }

    public bool? registro { get; set; }

    public string? frase { get; set; }

    public DateTime? registrado { get; set; }

    public Autor? autor { get; set; }
}

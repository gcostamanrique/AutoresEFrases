using AutoresEFrasesDominio.Entidades;
using AutoresEFrasesInfraestrutura.Dados.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace AutoresEFrasesInfraestrutura.Dados;

public class ContextoBancoDados : DbContext
{
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Frase> Frases { get; set; }

    public ContextoBancoDados(DbContextOptions<ContextoBancoDados> opcoes) : base(opcoes) 
    { }

    protected override void OnModelCreating(ModelBuilder modeloContrutor)
    {
        modeloContrutor.ApplyConfiguration(new ConfiguracaoAutorEF());
        modeloContrutor.ApplyConfiguration(new ConfiguracaoFraseEF());
    }
}

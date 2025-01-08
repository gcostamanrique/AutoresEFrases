using AutoresEFrasesDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoresEFrasesInfraestrutura.Dados.Configuracoes;

public class ConfiguracaoFraseEF : IEntityTypeConfiguration<Frase>
{
    public void Configure(EntityTypeBuilder<Frase> construtor)
    {
        construtor.ToTable("TB_FRASE");

        construtor.HasKey(f => f.id);

        construtor.Property(f => f.id)
            .HasColumnName("FRA_ID")
            .IsRequired();

        construtor.Property(f => f.autorId)
            .HasColumnName("FRA_AUT_ID")
            .IsRequired();

        construtor.Property(f => f.registro)
            .HasColumnName("FRA_STATUS_REGISTRO")
            .IsRequired();

        construtor.Property(f => f.frase)
            .HasColumnName("FRA_FRASE")
            .HasMaxLength(1000)
            .IsRequired();

        construtor.Property(f => f.registrado)
            .HasColumnName("FRA_DATA_REGISTRO")
            .IsRequired();

        construtor.HasOne(f => f.autor)
            .WithMany(a => a.frase)
            .HasForeignKey(f => f.autorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

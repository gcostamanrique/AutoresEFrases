using AutoresEFrasesDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoresEFrasesInfraestrutura.Dados.Configuracoes;

public class ConfiguracaoAutorEF : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> construtor)
    {
        construtor.ToTable("TB_AUTOR");

        construtor.HasKey(a => a.id);

        construtor.Property(a => a.id)
            .HasColumnName("AUT_ID")
            .IsRequired();

        construtor.Property(a => a.registro)
            .HasColumnName("AUT_STATUS_REGISTRO")
            .IsRequired();

        construtor.Property(a => a.nome)
            .HasColumnName("AUT_NOME")
            .HasMaxLength(50)
            .IsRequired();

        construtor.Property(a => a.sobrenome)
            .HasColumnName("AUT_SOBRENOME")
            .HasMaxLength(100)
            .IsRequired();

        construtor.Property(a => a.status)
            .HasColumnName("AUT_STATUS_VIDA")
            .IsRequired();

        construtor.Property(a => a.nascimento)
            .HasColumnName("AUT_DATA_NASCIMENTO")
            .IsRequired();

        construtor.Property(a => a.falecimento)
            .HasColumnName("AUT_DATA_FALECIMENTO")
            .IsRequired(false);

        construtor.HasMany(a => a.frase)
            .WithOne(f => f.autor)
            .HasForeignKey(f => f.autorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

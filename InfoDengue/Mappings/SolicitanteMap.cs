using InfoDengue.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoDengue.Mappings;

public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
{
    public void Configure(EntityTypeBuilder<Solicitante> builder)
    {
        builder.HasKey(e => e.IdSolicitante).HasName("PK__Solicita__B6EB1200E2457044");

        builder.ToTable("Solicitante");

        builder.HasIndex(e => e.Cpf, "UQ__Solicita__C1FF930913C8D22D").IsUnique();

        builder.Property(e => e.Cpf)
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.Nome)
            .HasMaxLength(100)
            .IsUnicode(false);
    }
}
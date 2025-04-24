using IPSUPC.BE.Transversales.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class DiaEntityConfiguration : IEntityTypeConfiguration<Dias>
{
    public void Configure(EntityTypeBuilder<Dias> builder)
    {
        builder.ToTable("Dias");

        builder.HasKey(x => x.DiaID);

        builder.Property(x => x.DiaID)
            .HasColumnName("DiaID");

        builder.Property(x => x.Code)
            .HasColumnName("Nombre")
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.HasData(Dias.GetAll()); // Esto pre-carga los días en la BD
    }
}
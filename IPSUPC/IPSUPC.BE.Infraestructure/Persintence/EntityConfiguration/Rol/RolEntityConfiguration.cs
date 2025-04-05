using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class RolEntityConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Nombre)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Nombre).IsUnique();

        builder.HasData(Rol.GetAll());
    }
}
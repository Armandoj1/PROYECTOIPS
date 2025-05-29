using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class CargoAdministradorEntityConfiguration : IEntityTypeConfiguration<CargoAdministrador>
{
    public void Configure(EntityTypeBuilder<CargoAdministrador> builder)
    {
        builder.ToTable("CargosAdministradores");

        builder.HasKey(c => c.CargoId);

        builder.Property(c => c.CargoId)
            .HasColumnName("CargoId");

        builder.Property(c => c.Nombre)
            .HasColumnName("Nombre")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode(false);

        builder.HasData(CargoAdministrador.GetAll());
    }
}
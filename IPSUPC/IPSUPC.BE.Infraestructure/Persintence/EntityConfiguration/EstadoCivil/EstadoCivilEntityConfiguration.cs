using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class EstadoCivilEntityConfiguration : IEntityTypeConfiguration<EstadoCivil>
{
    public void Configure(EntityTypeBuilder<EstadoCivil> builder)
    {
        builder.ToTable(
            DbConstants.Tables.EstadoCivil,
            DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasMaxLength(DbConstants.StringLength.EnumCode)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
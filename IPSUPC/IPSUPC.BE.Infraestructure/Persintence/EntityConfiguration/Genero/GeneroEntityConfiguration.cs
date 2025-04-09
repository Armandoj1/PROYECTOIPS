using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class GeneroEntityConfiguration : IEntityTypeConfiguration<Generos>
{
    public void Configure(EntityTypeBuilder<Generos> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Generos,
            DbConstants.Schemas.Dbo)
           .HasKey(x => x.Id);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EnumCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}
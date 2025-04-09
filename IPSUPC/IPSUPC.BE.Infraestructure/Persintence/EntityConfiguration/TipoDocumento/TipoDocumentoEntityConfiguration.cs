using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class TipoDocumentoEntityConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable(
                DbConstants.Tables.TipoDocumento,
                DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(DbConstants.StringLength.Nombre)
            .IsRequired();

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
    }
}
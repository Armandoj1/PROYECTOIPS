using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static IPSUPC.BE.Infraestructure.Data.DbConstants;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class TipoConsultaEntityConfiguration : IEntityTypeConfiguration<TipoConsulta>
{
    public void Configure(EntityTypeBuilder<TipoConsulta> builder)
    {
        builder.ToTable(
            DbConstants.Tables.TipoConsulta,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.TipoConsultaID);
        builder.Property(e => e.TipoConsultaID)
            .HasColumnName("TipoConsultaID")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("Code")
            .IsRequired()
            .HasMaxLength(StringLength.EnumCode);

        builder.HasData(TipoConsulta.GetAll());

    }
}
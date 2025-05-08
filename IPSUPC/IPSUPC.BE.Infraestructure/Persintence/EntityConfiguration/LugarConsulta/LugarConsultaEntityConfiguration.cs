using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class LugarConsultaEntityConfiguration : IEntityTypeConfiguration<LugarConsulta>
{
    public void Configure(EntityTypeBuilder<LugarConsulta> builder)
    {
        builder.ToTable(
            DbConstants.Tables.LugarConsulta,
            DbConstants.Schemas.Dbo)
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Name)
            .HasMaxLength(40)
            .IsRequired();
        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        builder.HasData(LugarConsulta.GetAll());
    }
}
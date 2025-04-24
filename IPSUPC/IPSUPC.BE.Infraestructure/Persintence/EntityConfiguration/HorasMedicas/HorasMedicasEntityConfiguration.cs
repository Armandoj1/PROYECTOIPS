using IPSUPC.BE.Transversales;
using IPSUPC.BE.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class HorasMedicasEntityConfiguration : IEntityTypeConfiguration<HorasMedicas>
{
    public void Configure(EntityTypeBuilder<HorasMedicas> builder)
    {
        builder.ToTable(
            DbConstants.Tables.HorasMedicas,
            DbConstants.Schemas.Dbo)
            .HasKey(x => x.HoraMedicaID);

        builder
            .Property(x => x.Code)
            .HasMaxLength(DbConstants.StringLength.EnumCode)
            .IsRequired();

        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.HasData(HorasMedicas.GetAll());
    }
}
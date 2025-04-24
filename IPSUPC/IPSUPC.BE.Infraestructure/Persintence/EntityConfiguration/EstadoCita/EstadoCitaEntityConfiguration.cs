using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static IPSUPC.BE.Infraestructure.Data.DbConstants;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration
{
    public class EstadoCitaEntityConfiguration : IEntityTypeConfiguration<EstadoCita>
    {
        public void Configure(EntityTypeBuilder<EstadoCita> builder)
        {
            builder.ToTable(nameof(EstadoCita));

            builder.HasKey(x => x.EstadoCitaID);

            builder.Property(x => x.Code)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(StringLength.EnumCode);  

            builder.HasData(EstadoCita.GetAll());
        }
    }
}

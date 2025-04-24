using IPSUPC.BE.Transversales.Core;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static IPSUPC.BE.Infraestructure.Data.DbConstants;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class CitasMedicasEntityConfiguration : IEntityTypeConfiguration<CitasMedicas>
{
    public void Configure(EntityTypeBuilder<CitasMedicas> builder)
    {
        builder.ToTable(nameof(CitasMedicas));

        builder.HasKey(x => x.CitaMedicaID);

        builder.Property(x => x.FechaCita)
            .IsRequired();

        builder.Property(x => x.Observaciones)
            .HasMaxLength(StringLength.Observacion)
            .IsUnicode(false);

        builder.HasOne<Pacientes>()
            .WithMany()
            .HasForeignKey(x => x.PacienteID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.MedicoID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Dias>()
            .WithMany()
            .HasForeignKey(x => x.DiaID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<EstadoCita>()
            .WithMany()
            .HasForeignKey(x => x.EstadoCitaID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<HorasMedicas>()
            .WithMany()
            .HasForeignKey(x => x.HorasMedicasID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TipoConsulta>()
            .WithMany()
            .HasForeignKey(x => x.TipoConsultaID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
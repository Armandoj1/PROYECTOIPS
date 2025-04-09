using IPSUPC.BE.Infraestructure.Data;
using IPSUPC.BE.Transversales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class PacientesEntityConfiguration : IEntityTypeConfiguration<Pacientes>
{
    public void Configure(EntityTypeBuilder<Pacientes> builder)
    {
        builder.ToTable(
            DbConstants.Tables.Pacientes,
            DbConstants.Schemas.Dbo);

        builder.HasKey(e => e.NumeroDocumento);

        builder.Property(e => e.NumeroDocumento)
            .HasColumnName("NumeroDocumento")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne<TipoDocumento>()
            .WithMany()
            .HasForeignKey(e => e.TipoDocumento)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.PrimerNombre)
            .HasColumnName("PrimerNombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SegundoNombre)
            .HasColumnName("SegundoNombre")
            .HasMaxLength(50);

        builder.Property(e => e.PrimerApellido)
            .HasColumnName("PrimerApellido")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SegundoApellido)
            .HasColumnName("SegundoApellido")
            .HasMaxLength(50);

        builder.Property(e => e.CorreoElectronico)
            .HasColumnName("CorreoElectronico")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Telefono)
            .HasColumnName("Telefono")
            .HasMaxLength(20);

        builder.Property(e => e.Celular)
            .HasColumnName("Celular")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Direccion)
            .HasColumnName("Direccion")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Ciudad)
            .HasColumnName("Ciudad")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Departamento)
            .HasColumnName("Departamento")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Pais)
            .HasColumnName("Pais")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CodigoPostal)
            .HasColumnName("CodigoPostal")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne<Generos>()
            .WithMany()
            .HasForeignKey(x => x.Genero)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<EstadoCivil>()
            .WithMany()
            .HasForeignKey(x => x.EstadoCivil)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.FechaNacimiento)
            .HasColumnName("FechaNacimiento")
            .HasMaxLength(10);

        builder.Property(e => e.LugarNacimiento)
            .HasColumnName("LugarNacimiento")
            .HasMaxLength(50);

        builder.Property(e => e.Nacionalidad)
            .HasColumnName("Nacionalidad")
            .HasMaxLength(50);

        builder.Property(e => e.GrupoSanguineo)
            .HasColumnName("GrupoSanguineo")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(e => e.TieneAlergias)
            .HasColumnName("TieneAlergias")
            .IsRequired();

        builder.Property(e => e.Alergias)
            .HasColumnName("Alergias")
            .HasMaxLength(200);

        builder.Property(e => e.Medicamentos)
            .HasColumnName("Medicamentos")
            .HasMaxLength(200);

        builder.Property(e => e.EnfermedadesCronicas)
            .HasColumnName("EnfermedadesCronicas")
            .HasMaxLength(200);

        builder.Property(e => e.AntecedentesFamiliares)
            .HasColumnName("AntecedentesFamiliares")
            .HasMaxLength(200);

        builder.Property(e => e.FechaRegistro)
            .HasColumnName("FechaRegistro")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.Estado)
            .HasColumnName("Estado")
            .HasMaxLength(1)
            .IsRequired();
    }
}
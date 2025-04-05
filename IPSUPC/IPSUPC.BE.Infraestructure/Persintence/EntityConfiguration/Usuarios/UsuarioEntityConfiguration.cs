using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static IPSUPC.BE.Infraestructure.Data.DbConstants;

namespace IPSUPC.BE.Infraestructure.Persintence.EntityConfiguration;

public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {

        builder.ToTable(nameof(Usuario));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NombreUsuario)
            .HasColumnName("NombreUsuario")
            .IsRequired()
            .HasMaxLength(StringLength.Usuario);

        builder.Property(x => x.Contrasena)
            .HasColumnName("Contrasena")
            .IsRequired()
            .HasMaxLength(StringLength.Contrasena);

        builder.HasOne<Rol>()
            .WithMany()
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Estado)
            .HasColumnName("Estado")
            .IsRequired()
            .HasMaxLength(1)
            .IsUnicode(false)
            .HasConversion<string>();

        builder.Property(x => x.NumeroIdentificacion)
            .HasColumnName("NumeroIdentificacion")
            .IsRequired()
            .HasMaxLength(StringLength.NumeroIdentificacion)
            .IsUnicode(false);
    }
}
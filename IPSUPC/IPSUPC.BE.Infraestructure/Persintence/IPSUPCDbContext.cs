using Microsoft.EntityFrameworkCore;
using MediatR;
using IPSUPC.BE.Infraestructure.Extensions;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Core;

namespace IPSUPC.BE.Infraestructure.Persintence
{
    public class IPSUPCDbContext(DbContextOptions options) : DbContext(options)
    {
        internal IMediator _mediator;

        #region Entities

        // Agrega aquí tus DbSet cuando los tengas
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<HorasMedicas> HorasMedicas { get; set; }
        public DbSet<Dias> Dias { get; set; }
        public DbSet<TipoConsulta> TipoConsultas { get; set; }
        public DbSet<CitasMedicas> CitasMedicas { get; set; }

        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            AuditChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(IPSUPCDbContext).Assembly);

            HasSequences(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void AuditChanges()
        {
            ChangeTracker.DetectChanges();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
                .ToList();

            if (!modifiedEntries.Any()) return;

            var userName = "IPSUPC_Service";

            foreach (var entry in modifiedEntries)
            {
                var props = entry.Properties.ToDictionary(p => p.Metadata.Name, p => p);

                if (entry.State == EntityState.Added)
                {
                    if (props.ContainsKey("CreatedDate"))
                        props["CreatedDate"].CurrentValue = DateTime.UtcNow;

                    if (props.ContainsKey("CreatedBy"))
                        props["CreatedBy"].CurrentValue = userName;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (props.ContainsKey("UpdatedDate"))
                        props["UpdatedDate"].CurrentValue = DateTime.UtcNow;

                    if (props.ContainsKey("UpdatedBy"))
                        props["UpdatedBy"].CurrentValue = userName;
                }

                if (entry.State == EntityState.Deleted)
                {
                    if (props.ContainsKey("DeletedDate"))
                        props["DeletedDate"].CurrentValue = DateTime.UtcNow;

                    if (props.ContainsKey("DeletedBy"))
                        props["DeletedBy"].CurrentValue = userName;

                    if (props.ContainsKey("IsDeleted"))
                        props["IsDeleted"].CurrentValue = true;

                    entry.State = EntityState.Modified;
                }
            }
        }


        private void HasSequences(ModelBuilder modelBuilder)
        {
            // Aquí puedes agregar secuencias si las necesitas
        }
    }

    public class IPSUPCDbContextScopedFactory(
        IDbContextFactory<IPSUPCDbContext> pooledFactory,
        IMediator mediator) : IDbContextFactory<IPSUPCDbContext>
    {
        public IPSUPCDbContext CreateDbContext()
        {
            var context = pooledFactory.CreateDbContext();
            context._mediator = mediator;
            return context;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MediatR;
using IPSUPC.BE.Infraestructure.Extensions;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Core;

namespace IPSUPC.BE.Infraestructure.Persintence
{
    public class IPSUPCDbContext : DbContext
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
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<CargoAdministrador> cargoAdministradores { get; set; }

        #endregion

        public IPSUPCDbContext(DbContextOptions<IPSUPCDbContext> options) : base(options)
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuración de resiliencia a errores transitorios
                optionsBuilder.UseSqlServer("DefaultConnection", options =>
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null));
            }
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

    public class IPSUPCDbContextScopedFactory : IDbContextFactory<IPSUPCDbContext>
    {
        private readonly IDbContextFactory<IPSUPCDbContext> _pooledFactory;
        private readonly IMediator _mediator;

        public IPSUPCDbContextScopedFactory(
            IDbContextFactory<IPSUPCDbContext> pooledFactory,
            IMediator mediator)
        {
            _pooledFactory = pooledFactory;
            _mediator = mediator;
        }

        public IPSUPCDbContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            context._mediator = _mediator;
            return context;
        }
    }
}
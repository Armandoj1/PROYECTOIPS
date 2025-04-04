using Microsoft.EntityFrameworkCore;
using MediatR;
using IPSUPC.BE.Infraestructure.Extensions;

namespace IPSUPC.BE.Infraestructure.Persintence
{
    public class IPSUPCDbContext(DbContextOptions options) : DbContext(options)
    {
        internal IMediator _mediator;

        #region Entities

        // Agrega aquí tus DbSet cuando los tengas

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
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("CreatedBy").CurrentValue = userName;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedBy").CurrentValue = userName;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.Property("DeletedDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("DeletedBy").CurrentValue = userName;
                    entry.Property("IsDeleted").CurrentValue = true;
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
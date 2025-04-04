using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Infraestructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Entity;


namespace Microsoft.AspNetCore.Hosting;

public static class IHostExtensions
{
    public static async Task MigrateDbContext<TContext>(this IHost webHost) where TContext : DbContext
    {
        using var scope = webHost.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        context.Database.SetCommandTimeout(TimeSpan.FromMinutes(2));
        await context.Database.MigrateAsync();
    }

    public static async Task InitializeData(this IHost webHost)
    {
        using var scope = webHost.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<IPSUPCDbContext>();
        await SampleDataSeeder.PopulateSamples(context);
    }
}

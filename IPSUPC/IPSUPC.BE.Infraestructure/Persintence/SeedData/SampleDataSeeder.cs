
using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Infraestructure.Persistence.SeedData;

public static class SampleDataSeeder
{
    public static async Task PopulateSamples(IPSUPCDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        context.Database.EnsureCreated();

        // Verifica si los datos ya existen antes de insertarlos
        //Poner datos de prueba, cuando las primeras clases estén para la migración
        if (!await context.Set<Rol>().AnyAsync())
        {
            context.Set<Rol>().AddRange(Rol.GetAll());
        }

        //if (!await context.Set<TipoCliente>().AnyAsync())
        //{
        //    context.Set<TipoCliente>().AddRange(TipoCliente.GetAll());
        //}

        await context.SaveChangesAsync();
    }
}
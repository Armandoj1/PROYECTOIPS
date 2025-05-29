using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class AdministradorDAL : IAdministradorDAL
{
    private readonly IPSUPCDbContext _context;

    public AdministradorDAL(IPSUPCDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Administrador>> GetAdministradoresAsync()
    {
        return await _context.Set<Administrador>().ToListAsync();
    }

    public async Task<IEnumerable<Administrador>> GetAdministradoresByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        return await _context.Set<Administrador>()
            .Where(a => a.NumeroDocumento == numeroIdentificacion)
            .ToListAsync();
    }

    public async Task<Administrador> CreateAdministradorAsync(Administrador administrador)
    {
        await _context.Set<Administrador>().AddAsync(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }

    public async Task<Administrador> UpdateAdministradorAsync(Administrador administrador)
    {
        var existingAdministrador = await _context.Set<Administrador>().FindAsync(administrador.NumeroDocumento);
        if (existingAdministrador == null)
            throw new Exception("Administrador no encontrado");

        _context.Entry(existingAdministrador).CurrentValues.SetValues(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }

    public async Task<Administrador> DeleteAdministradorAsync(string id)
    {
        var administrador = await _context.Set<Administrador>().FindAsync(id);
        if (administrador != null)
        {
            _context.Entry(administrador).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        return administrador;
    }

    public async Task<Administrador> CambiarFotoPerfil(string id, string url)
    {
        var administrador = await _context.Set<Administrador>().FindAsync(id);
        if (administrador != null)
        {
            administrador.ImagenUrl = url;
            await _context.SaveChangesAsync();
        }
        return administrador;
    }

}
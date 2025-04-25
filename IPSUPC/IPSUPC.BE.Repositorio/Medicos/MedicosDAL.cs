using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class MedicosDAL : IMedicosDAL
{

    private readonly IPSUPCDbContext _context;

    public MedicosDAL(IPSUPCDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medico>> GetMedicosAsync()
    {
        return await _context.Set<Medico>().ToListAsync();
    }

    public async Task<IEnumerable<Medico>> GetMedicosByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        return await _context.Set<Medico>()
            .Where(m => m.NumeroDocumento == numeroIdentificacion)
            .ToListAsync();
    }

    public async Task<Medico> CreateMedicosAsync(Medico medicos)
    {
        await _context.Set<Medico>().AddAsync(medicos);
        await _context.SaveChangesAsync();
        return medicos;
    }

    public async Task<Medico> CambiarFotoPerfil(string id, string url)
    {
        var Medicos = await _context.Medico.FindAsync(id);
        if (Medicos != null)
        {
            Medicos.ImagenUrl = url;
            await _context.SaveChangesAsync();
        }
        return Medicos;
    }

    public async Task<Medico> UpdateMedicosAsync(Medico medicos)
    {
        var existingMedicos = await _context.Set<Medico>().FindAsync(medicos.NumeroDocumento);
        if (existingMedicos == null)
            throw new Exception("Medico no encontrado");
        _context.Entry(existingMedicos).CurrentValues.SetValues(medicos);
        await _context.SaveChangesAsync();
        return medicos;
    }

    public async Task<Medico> DeleteMedicosAsync(string id)
    {
        var Medicos = await _context.Medico.FindAsync(id);
        if (Medicos != null)
        {
            _context.Entry(Medicos).State = EntityState.Deleted;
            Medicos.Estado = "I";
            await _context.SaveChangesAsync();
        }
        return Medicos;
    }

}
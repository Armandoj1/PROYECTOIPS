using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class CitasMedicasDAL : ICitasMedicasDAL
{
    private readonly IPSUPCDbContext _context;

    public CitasMedicasDAL(IPSUPCDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CitasMedicas>> GetAllCitas()
    {
        return await _context.CitasMedicas.ToListAsync();
    }

    public async Task<IEnumerable<CitasMedicas>> GetCitasMedico(string MedicoID)
    {
        return await _context.Set<CitasMedicas>()
            .Where(c => c.MedicoID == MedicoID)
            .ToListAsync();
    }

    public async Task<IEnumerable<CitasMedicas>> GetCitasPaciente(string PacienteID)
    {
        return await _context.Set<CitasMedicas>()
            .Where(c => c.PacienteID == PacienteID)
            .ToListAsync();
    }

    public async Task<IEnumerable<CitasMedicas>> GetCitasTipoConsulta(int TipoConsulta)
    {
        return await _context.Set<CitasMedicas>()
            .Where(c => c.TipoConsultaID == TipoConsulta)
            .ToListAsync();
    }

    public async Task<CitasMedicas> GetCitaById(int id)
    {
        return await _context.Set<CitasMedicas>()
            .FirstOrDefaultAsync(c => c.CitaMedicaID == id);
    }

    public async Task<CitasMedicas> CreateCita(CitasMedicas citasMedicas)
    {
        await _context.Set<CitasMedicas>().AddAsync(citasMedicas);
        await _context.SaveChangesAsync();
        return citasMedicas;
    }

    public async Task<CitasMedicas> UpdateCita(CitasMedicas citasMedicas)
    {
        _context.Set<CitasMedicas>().Update(citasMedicas);
        await _context.SaveChangesAsync();
        return citasMedicas;
    }

    public async Task UpdateEstadoCitaId(int id, int EstadoCitaID)
    {
        var Citas = await _context.CitasMedicas
            .FirstOrDefaultAsync(e => e.CitaMedicaID == id);

        if (Citas == null)
        {
            throw new InvalidOperationException("El horario médico no existe.");
        }

        Citas.EstadoCitaID = EstadoCitaID;
        _context.Entry(Citas).Property(h => h.EstadoCitaID).IsModified = true;
        await _context.SaveChangesAsync();
    }


}
using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales.Core;
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

    public async Task<CitasMedicas> CreateCita(CitasMedicas cita)
    {
        var diaDeLaSemana = Dias.GetByDayOfWeek(cita.FechaCita.DayOfWeek);
        cita.DiaID = diaDeLaSemana.DiaID;
        var horaDisponible = await _context.HorasMedicas
            .AnyAsync(h => h.HoraMedicaID == cita.HorasMedicasID);

        if (!horaDisponible)
        {
            throw new InvalidOperationException("La hora seleccionada no es válida.");
        }

        bool existeCita = await _context.CitasMedicas
            .AnyAsync(c =>
                c.MedicoID == cita.MedicoID &&
                c.FechaCita == cita.FechaCita);

        if (existeCita)
        {
            throw new InvalidOperationException("Ya existe una cita médica en la misma fecha y hora.");
        }

        await _context.Set<CitasMedicas>().AddAsync(cita);
        await _context.SaveChangesAsync();

        return cita; 
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
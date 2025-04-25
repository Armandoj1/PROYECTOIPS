using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class PacientesDAL : IPacientesDAL
{
    private readonly IPSUPCDbContext _context;

    public PacientesDAL(IPSUPCDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pacientes>> GetPacientesAsync()
    {
        return await _context.Set<Pacientes>().ToListAsync();
    }

    public async Task<IEnumerable<Pacientes>> GetPacientesByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        return await _context.Set<Pacientes>()
            .Where(p => p.NumeroDocumento == numeroIdentificacion)
            .ToListAsync();
    }

    public async Task<Pacientes> CreatePacientesAsync(Pacientes pacientes)
    {
        await _context.Set<Pacientes>().AddAsync(pacientes);
        await _context.SaveChangesAsync();
        return pacientes;
    }

    public async Task<Pacientes> CambiarFotoPerfil(string id, string url)
    {
        var paciente = await _context.Set<Pacientes>().FindAsync(id);
        if (paciente == null)
            throw new Exception("Paciente no encontrado");
        paciente.ImagenUrl = url;
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<Pacientes> UpdatePacientesAsync(Pacientes pacientes)
    {
        var existingPacientes = await _context.Set<Pacientes>().FindAsync(pacientes.NumeroDocumento);
        if (existingPacientes == null)
            throw new Exception("Paciente no encontrado");
        _context.Entry(existingPacientes).CurrentValues.SetValues(pacientes);
        await _context.SaveChangesAsync();
        return pacientes;
    }

    public async Task<Pacientes> DeletePacientesAsync(string id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente != null)
        {
            _context.Entry(paciente).State = EntityState.Deleted;
            paciente.Estado = "I";
            await _context.SaveChangesAsync();
        }
        return paciente;
    }

}
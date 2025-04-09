using IPSUPC.BE.Transversales.Entidades;
namespace IPSUPC.BE.Servicio.Interface;

public interface IPacientesBLL
{
    Task<IEnumerable<PacientesDTO>> GetPacientesAsync();
    Task<IEnumerable<PacientesDTO>> GetPacientesByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Pacientes> CreatePacientesAsync(Pacientes pacientes);
    Task<Pacientes> UpdatePacientesAsync(Pacientes pacientes);
    Task<Pacientes> DeletePacientesAsync(string id);
}
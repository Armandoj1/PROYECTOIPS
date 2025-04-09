using IPSUPC.BE.Transversales.Entidades;
namespace IPSUPC.BE.Repositorio.Interface;

public interface IPacientesDAL
{
    Task<IEnumerable<Pacientes>> GetPacientesAsync();
    Task<IEnumerable<Pacientes>> GetPacientesByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Pacientes> CreatePacientesAsync(Pacientes pacientes);
    Task<Pacientes> UpdatePacientesAsync(Pacientes pacientes);
    Task<Pacientes> DeletePacientesAsync(string id);
}

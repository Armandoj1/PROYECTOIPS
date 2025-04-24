using IPSUPC.BE.Transversales.Entidades;
namespace IPSUPC.BE.Repositorio.Interface;

public interface ICitasMedicasDAL
{
    Task<IEnumerable<CitasMedicas>> GetAllCitas();
    Task<IEnumerable<CitasMedicas>> GetCitasMedico(string MedicoID);
    Task<IEnumerable<CitasMedicas>> GetCitasPaciente(string PacienteID);
    Task<IEnumerable<CitasMedicas>> GetCitasTipoConsulta(int TipoConsulta);
    Task<CitasMedicas> GetCitaById(int id);
    Task<CitasMedicas> CreateCita(CitasMedicas cita);
    Task<CitasMedicas> UpdateCita(CitasMedicas cita);
    Task UpdateEstadoCitaId(int id, int EstadoCitaID);
}
using IPSUPC.BE.Transversales.Entidades;
namespace IPSUPC.BE.Servicio.Interface;

public interface ICitasMedicasBLL
{
    Task<IEnumerable<CitasMedicasDTO>> GetAllCitas();
    Task<IEnumerable<CitasMedicasDTO>> GetCitasMedico(string MedicoID);
    Task<IEnumerable<CitasMedicasDTO>> GetCitasPaciente(string PacienteID);
    Task<IEnumerable<CitasMedicasDTO>> GetCitasTipoConsulta(int TipoConsulta);
    Task<CitasMedicasDTO> GetCitaById(int id);
    Task<CitasMedicas> CreateCita(CitasMedicas cita);
    Task<CitasMedicas> UpdateCita(CitasMedicas cita);
    Task UpdateEstadoCitaId(int id, int EstadoCitaID);
}
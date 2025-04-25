using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio.Interface;

public interface IMedicosBLL
{
    Task<IEnumerable<MedicoDTO>> GetMedicosAsync();

    Task<IEnumerable<MedicoDTO>> GetMedicosByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Medico> CreateMedicosAsync(Medico medicos);
    Task<Medico> UpdateMedicosAsync(Medico medicos);
    Task<Medico> DeleteMedicosAsync(string id);
    Task<Medico> CambiarFotoPerfil(string id, string url);
}
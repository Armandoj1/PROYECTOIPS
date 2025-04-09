using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Repositorio.Interface;

public interface IMedicosDAL
{
    Task<IEnumerable<Medico>> GetMedicosAsync();
    Task<IEnumerable<Medico>> GetMedicosByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Medico> CreateMedicosAsync(Medico medicos);
    Task<Medico> UpdateMedicosAsync(Medico medicos);
    Task<Medico> DeleteMedicosAsync(string id);
}
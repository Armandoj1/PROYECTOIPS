using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Repositorio.Interface;

public interface IAdministradorDAL
{
    Task<IEnumerable<Administrador>> GetAdministradoresAsync();
    Task<IEnumerable<Administrador>> GetAdministradoresByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Administrador> CreateAdministradorAsync(Administrador administrador);
    Task<Administrador> UpdateAdministradorAsync(Administrador administrador);
    Task<Administrador> DeleteAdministradorAsync(string id);
    Task<Administrador> CambiarFotoPerfil(string id, string url);
}
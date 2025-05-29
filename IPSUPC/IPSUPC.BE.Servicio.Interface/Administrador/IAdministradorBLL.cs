using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio.Interface;

public interface IAdministradorBLL
{
    Task<IEnumerable<AdministradorDTO>> GetAdministradoresAsync();
    Task<IEnumerable<AdministradorDTO>> GetAdministradoresByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Administrador> CreateAdministradorAsync(Administrador administrador);
    Task<Administrador> UpdateAdministradorAsync(Administrador administrador);
    Task<Administrador> DeleteAdministradorAsync(string id);
    Task<Administrador> CambiarFotoPerfil(string id, string url);
}
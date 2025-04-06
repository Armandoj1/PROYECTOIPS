using IPSUPC.BE.Transversales.Entidades;
using Microsoft.Extensions.Configuration;
namespace IPSUPC.BE.Servicio.Interface;

public interface IUsuarioBLL
{
    Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync();
    Task<UsuarioDTO> GetUsuarioByIdAsync(int id);
    Task<IEnumerable<Usuario>> GetUsuarioByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<UsuarioCreateDTO> CreateUsuarioAsync(UsuarioCreateDTO usuario);
    Task<UsuarioCreateDTO> UpdateUsuarioAsync(UsuarioCreateDTO usuario);
    Task<Usuario> DeleteUsuarioAsync(int id);
    Task<string> LoginAsync(string nombreUsuario, string password, IConfiguration config);
}
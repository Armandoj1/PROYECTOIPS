
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Repositorio.Interface;
public interface IUsuarioDAL
{
    Task<IEnumerable<Usuario>> GetUsuarioAsync();
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<IEnumerable<Usuario>> GetUsuarioByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task<Usuario> DeleteUsuarioAsync(int id);
    Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada);
}
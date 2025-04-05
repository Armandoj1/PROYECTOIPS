using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio;
public class UsuarioBLL : IUsuarioBLL
{
    private readonly IUsuarioDAL _usuarioDAL;

    public UsuarioBLL(IUsuarioDAL usuarioDAL)
    {
        _usuarioDAL = usuarioDAL;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return await _usuarioDAL.GetUsuarioAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _usuarioDAL.GetUsuarioByIdAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        return await _usuarioDAL.GetUsuarioByNumeroIdentificacionAsync(numeroIdentificacion);
 
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.CreateUsuarioAsync(usuario);
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.UpdateUsuarioAsync(usuario);
    }

    public async Task<Usuario> DeleteUsuarioAsync(int id)
    {
        return await _usuarioDAL.DeleteUsuarioAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string contrasena)
    {
        return await _usuarioDAL.GetUsuarioByCredentialsAsync(nombreUsuario, contrasena);
    }

}
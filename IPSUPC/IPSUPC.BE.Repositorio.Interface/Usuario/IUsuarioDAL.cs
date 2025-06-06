﻿
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Repositorio.Interface;
public interface IUsuarioDAL
{
    Task<IEnumerable<Usuario>> GetUsuarioAsync();
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<IEnumerable<UsuarioCreateDTO>> GetUsuariosByNumeroIdentificacionAsync(string numeroIdentificacion);
    Task<UsuarioCreateDTO> CreateUsuarioAsync(UsuarioCreateDTO usuario);
    Task<UsuarioCreateDTO> UpdateUsuarioAsync(UsuarioCreateDTO usuario);
    Task<Usuario> DeleteUsuarioAsync(int id);
    Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada);
    Task<bool> CambiarPasswordAsync(string identificacion, string nuevaPassword);
}
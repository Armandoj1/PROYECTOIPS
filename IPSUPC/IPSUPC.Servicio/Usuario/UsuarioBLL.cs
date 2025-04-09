using AutoMapper;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Encriptacion;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IPSUPC.BE.Infraestructure.Persintence;

namespace IPSUPC.BE.Servicio;
public class UsuarioBLL : IUsuarioBLL
{
    private readonly IUsuarioDAL _usuarioDAL;
    private readonly IMapper _mapper;
    private readonly IPSUPCDbContext _context;

    public UsuarioBLL(IUsuarioDAL usuarioDAL, IMapper mapper, IPSUPCDbContext context)
    {
        _usuarioDAL = usuarioDAL;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync()
    {
        var usuarios = await _usuarioDAL.GetUsuarioAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
    {
        var usuarios = await _usuarioDAL.GetUsuarioByIdAsync(id);
        return _mapper.Map<UsuarioDTO>(usuarios);
    }

    public async Task<IEnumerable<UsuarioCreateDTO>> GetUsuarioByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        return await _usuarioDAL.GetUsuariosByNumeroIdentificacionAsync(numeroIdentificacion);
 
    }

    public async Task<UsuarioCreateDTO> CreateUsuarioAsync(UsuarioCreateDTO usuario)
    {
        return await _usuarioDAL.CreateUsuarioAsync(usuario);
    }

    public async Task<UsuarioCreateDTO> UpdateUsuarioAsync(UsuarioCreateDTO usuario)
    {
        return await _usuarioDAL.UpdateUsuarioAsync(usuario);
    }

    public async Task<Usuario> DeleteUsuarioAsync(int id)
    {
        return await _usuarioDAL.DeleteUsuarioAsync(id);
    }

    public async Task<string> LoginAsync(string nombreUsuario, string password, IConfiguration config)
    {
        var passwordEncriptada = Encrypt.EncriptarContrasena(password);
        var usuarios = await _usuarioDAL.GetUsuarioByCredentialsAsync(nombreUsuario, passwordEncriptada);

        if (usuarios is null || !usuarios.Any())
            throw new UnauthorizedAccessException("Credenciales incorrectas.");

        var usuarioActivo = usuarios.FirstOrDefault(u => u.Estado == 'A')
            ?? throw new UnauthorizedAccessException("El usuario no está activo.");

        var roles = string.Join(",", usuarios.Select(u => Rol.GetRolById(u.RolId)?.Nombre ?? "Desconocido"));

        var usuarioDTO = new UsuarioDTO
        {
            NumeroIdentificacion = usuarioActivo.NumeroIdentificacion,
            NombreUsuario = usuarioActivo.NombreUsuario,
            RolId = roles
        };

        return JwtConfiguration.GetToken(usuarioDTO, config);
    }

    public async Task<bool> CambiarPasswordAsync(CambiarPassword dto)
    {
        return await _usuarioDAL.CambiarPasswordAsync(dto.NumeroIdentificacion, dto.NuevaPassword);
    }

}
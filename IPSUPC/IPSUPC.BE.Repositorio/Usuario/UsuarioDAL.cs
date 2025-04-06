using AutoMapper;
using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class UsuarioDAL : IUsuarioDAL
{
    private readonly IPSUPCDbContext _context;
    private readonly IMapper _mapper;

    public UsuarioDAL(IPSUPCDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }
     
    public async Task<IEnumerable<Usuario>> GetUsuarioByNumeroIdentificacionAsync(string numeroDocumento)
    {
        return await _context.Usuarios
            .Where(u => u.NumeroIdentificacion == numeroDocumento)
            .ToListAsync();
    }

    public async Task<UsuarioCreateDTO> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        usuario.Contrasena = Encrypt.EncriptarContrasena(usuario.Contrasena);

        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuarioDto;
    }

    public async Task<UsuarioCreateDTO> UpdateUsuarioAsync(UsuarioCreateDTO usuarioDto)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(usuarioDto.Id);

        if (usuarioExistente is null)
            throw new Exception("Usuario no encontrado");

        _mapper.Map(usuarioDto, usuarioExistente);
        usuarioExistente.Contrasena = Encrypt.EncriptarContrasena(usuarioDto.Contrasena);

        await _context.SaveChangesAsync();
        return usuarioDto;
    }
    

    public async Task<Usuario> DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Entry(usuario).State = EntityState.Deleted;
            usuario.Estado = 'I';
            await _context.SaveChangesAsync();
        }
        return usuario;
    }


    public async Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada)
    {
        return await _context.Usuarios
            .Where(u => u.NombreUsuario == nombreUsuario &&
                        u.Contrasena == passwordEncriptada)
            .ToListAsync();
    }
}
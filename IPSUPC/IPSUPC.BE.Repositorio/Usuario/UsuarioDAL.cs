using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        return await _context.Usuario.ToListAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuario.FindAsync(id);
    }

    public async Task<IEnumerable<UsuarioCreateDTO>> GetUsuariosByNumeroIdentificacionAsync(string numeroDocumento)
    {
        return await _context.Usuario
            .Where(u => u.NumeroIdentificacion == numeroDocumento)
            .ProjectTo<UsuarioCreateDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<UsuarioCreateDTO> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        usuario.Contrasena = Encrypt.EncriptarContrasena(usuario.Contrasena);

        await _context.Usuario.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuarioDto;
    }

    public async Task<UsuarioCreateDTO> UpdateUsuarioAsync(UsuarioCreateDTO usuarioDto)
    {
        var usuarioExistente = await _context.Usuario.FindAsync(usuarioDto.Id);

        if (usuarioExistente is null)
            throw new Exception("Usuario no encontrado");

        _mapper.Map(usuarioDto, usuarioExistente);
        usuarioExistente.Contrasena = Encrypt.EncriptarContrasena(usuarioDto.Contrasena);

        await _context.SaveChangesAsync();
        return usuarioDto;
    }
    

    public async Task<Usuario> DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
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
        return await _context.Usuario
            .Where(u => u.NombreUsuario == nombreUsuario &&
                        u.Contrasena == passwordEncriptada)
            .ToListAsync();
    }

    public async Task<bool> CambiarPasswordAsync(string identificacion, string nuevaPassword)
    {
        var usuarios = await _context.Usuario
            .Where(u => u.NumeroIdentificacion == identificacion)
            .ToListAsync();

        if (!usuarios.Any())
            throw new KeyNotFoundException("El usuario no existe.");

        var nuevaPasswordEncriptada = Encrypt.EncriptarContrasena(nuevaPassword);

        usuarios.ForEach(u => u.Contrasena = nuevaPasswordEncriptada);

        await _context.SaveChangesAsync();
        return true;
    }

}
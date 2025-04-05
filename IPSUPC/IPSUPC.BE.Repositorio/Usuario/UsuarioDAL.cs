using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IPSUPC.BE.Repositorio;

public class UsuarioDAL : IUsuarioDAL
{
    private readonly IPSUPCDbContext _context;

    public UsuarioDAL(IPSUPCDbContext context)
    {
        _context = context;
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

    public async Task<Usuario> CreateUsuarioAsync (Usuario usuario)
    {
        usuario.Contrasena = Encrypt.EncriptarContrasena(usuario.Contrasena);

        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }
    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        usuario.Contrasena = Encrypt.EncriptarContrasena(usuario.Contrasena);
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            usuario.Estado = 'I';
            await _context.SaveChangesAsync();
        }

        return usuario;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada)
    {
        return await _context.Usuarios
            .Where(u => u.NombreUsuario == nombreUsuario &&
                        u.Contrasena == passwordEncriptada &&
                        u.Estado == 'A')
            .ToListAsync();
    }
}
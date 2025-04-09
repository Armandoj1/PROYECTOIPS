namespace IPSUPC.BE.Transversales.Entidades;

public class UsuarioCreateDTO
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Contrasena { get; set; }
    public int RolId { get; set; }
    public char Estado { get; set; }
    public string NumeroIdentificacion { get; set; }
}
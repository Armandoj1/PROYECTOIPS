namespace IPSUPC.BE.Transversales;

public sealed class Rol
{
    public static readonly Rol Administrador = new(1, Roles.Administrador);
    public static readonly Rol Medico = new(2, Roles.Medico);
    public static readonly Rol Paciente = new(3, Roles.Paciente);

    public static class Roles
    {
        public const string Administrador = "ADMINISTRADOR";
        public const string Medico = "MEDICO";
        public const string Paciente = "PACIENTE";
    }

    public int Id { get; }
    public string Nombre { get; }

    private Rol(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    private Rol() { }

    public static Rol[] GetAll()
        => new[] { Administrador, Medico, Paciente};

    public static Rol GetRolById(int id)
        => GetAll().FirstOrDefault(r => r.Id == id) ?? new Rol(0, "Rol desconocido");

    public static Rol GetRolByNombre(string nombre)
        => GetAll().FirstOrDefault(r => r.Nombre == nombre);

    public static bool IsValidNombre(string nombre)
        => GetAll().Any(r => r.Nombre == nombre);
}
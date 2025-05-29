namespace IPSUPC.BE.Transversales;

public sealed class CargoAdministrador
{
    public static readonly CargoAdministrador GerenteGeneral = new(1, Cargos.GerenteGeneral);
    public static readonly CargoAdministrador DirectorIPS = new(2, Cargos.DirectorIPS);
    public static readonly CargoAdministrador DirectorMedico = new(3, Cargos.DirectorMedico);
    public static readonly CargoAdministrador JefeRecursosHumanos = new(4, Cargos.JefeRecursosHumanos);
    public static readonly CargoAdministrador AuxiliarAdministrativo = new(5, Cargos.AuxiliarAdministrativo);
    public static readonly CargoAdministrador CoordinadorCitas = new(6, Cargos.CoordinadorCitas);
    public static readonly CargoAdministrador SupervisorGeneral = new(7, Cargos.SupervisorGeneral);

    public static class Cargos
    {
        public const string GerenteGeneral = "GERENTE GENERAL";
        public const string DirectorIPS = "DIRECTOR DE IPS";
        public const string DirectorMedico = "DIRECTOR MÉDICO";
        public const string JefeRecursosHumanos = "JEFE DE RECURSOS HUMANOS";
        public const string AuxiliarAdministrativo = "AUXILIAR ADMINISTRATIVO";
        public const string CoordinadorCitas = "COORDINADOR DE CITAS";
        public const string SupervisorGeneral = "SUPERVISOR GENERAL";
    }

    public int CargoId { get; }
    public string Nombre { get; }

    private CargoAdministrador(int cargoId, string nombre)
    {
        CargoId = cargoId;
        Nombre = nombre;
    }

    private CargoAdministrador() { }

    public static CargoAdministrador[] GetAll()
        => new[] {
            GerenteGeneral,
            DirectorIPS,
            DirectorMedico,
            JefeRecursosHumanos,
            AuxiliarAdministrativo,
            CoordinadorCitas,
            SupervisorGeneral
        };

    public static CargoAdministrador GetById(int id)
        => GetAll().First(c => c.CargoId == id);

    public static CargoAdministrador GetByNombre(string nombre)
        => GetAll().First(c => c.Nombre == nombre);

    public static bool IsValidNombre(string nombre)
        => GetAll().Any(c => c.Nombre == nombre);
}
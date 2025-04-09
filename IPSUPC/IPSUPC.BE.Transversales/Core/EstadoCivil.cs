namespace IPSUPC.BE.Transversales;

public sealed class EstadoCivil
{
    public static readonly EstadoCivil Soltero = new(1, EstadoCiviles.Soltero);
    public static readonly EstadoCivil Casado = new(2, EstadoCiviles.Casado);
    public static readonly EstadoCivil UnionLibre = new(3, EstadoCiviles.UnionLibre);
    public static readonly EstadoCivil Separado = new(4, EstadoCiviles.Separado);
    public static readonly EstadoCivil Divorciado = new(5, EstadoCiviles.Divorciado);
    public static readonly EstadoCivil Viudo = new(6, EstadoCiviles.Viudo);

    public static class EstadoCiviles
    {
        public const string Soltero = "Soltero/a";
        public const string Casado = "Casado/a";
        public const string UnionLibre = "Unión libre o unión de hecho";
        public const string Separado = "Separado/a";
        public const string Divorciado = "Divorciado/a";
        public const string Viudo = "Viudo/a";
    }

    public int Id { get; }
    public string Name { get; }

    private EstadoCivil(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private EstadoCivil() { }

    public static EstadoCivil[] GetAll() => new[]
    {
        Soltero,
        Casado,
        UnionLibre,
        Separado,
        Divorciado,
        Viudo
    };

    public static EstadoCivil GetById(int id) =>
        GetAll().First(x => x.Id == id);

    public static EstadoCivil GetByName(string name) =>
        GetAll().First(x => x.Name == name);

    public static bool IsValidName(string name) =>
        GetAll().Any(x => x.Name == name);
}
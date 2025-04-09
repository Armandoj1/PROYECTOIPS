namespace IPSUPC.BE.Transversales;

public sealed class Generos
{
    public static readonly Generos Masculino = new(1, GenerosNames.Masculino);
    public static readonly Generos Femenino = new(2, GenerosNames.Femenino);
    public static readonly Generos Otro = new(3, GenerosNames.Otro);
    
    public static class GenerosNames
    {
        public const string Masculino = "MASCULINO";
        public const string Femenino = "FEMENINO";
        public const string Otro = "OTRO";
    }

    public int Id { get; }
    public string Code { get; }
    private Generos(int id, string code)
    {
        Id = id;
        Code = code;
    }
    private Generos() { }
    public static Generos[] GetAll()
        => new[] {
                Masculino,
                Femenino,
                Otro
        };
    public static Generos GetById(int id)
        => GetAll().First(x => x.Id == id);
    public static Generos GetByCode(string code)
        => GetAll().First(x => x.Code == code);
    public static bool IsValidCode(string code)
        => GetAll().Any(x => x.Code == code);
}           
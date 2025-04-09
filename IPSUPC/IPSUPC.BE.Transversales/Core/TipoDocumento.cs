namespace IPSUPC.BE.Transversales;

public sealed class TipoDocumento
{
    public static readonly TipoDocumento CedulaCiudadania = new(1, TipoDocumentos.CedulaCiudadania);
    public static readonly TipoDocumento TarjetaIdentidad = new(2, TipoDocumentos.TarjetaIdentidad);
    public static readonly TipoDocumento Pasaporte = new(3, TipoDocumentos.Pasaporte);
    public static readonly TipoDocumento CedulaExtranjeria = new(4, TipoDocumentos.CedulaExtranjeria);

    public static class TipoDocumentos
    {
        public const string CedulaCiudadania = "Cedula Ciudadania";
        public const string TarjetaIdentidad = "Tarjeta de Identidad";
        public const string Pasaporte = "Pasaporte";
        public const string CedulaExtranjeria = "Cedula Extranjeria";
    }

    public int Id { get; }
    public string Name { get; }

    private TipoDocumento(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private TipoDocumento() { }

    public static TipoDocumento[] GetAll()
          => new[] {
                CedulaCiudadania,
                TarjetaIdentidad,
                Pasaporte,
                CedulaExtranjeria
          };

    public static TipoDocumento GetById(int id)
         => GetAll().First(x => x.Id == id);

    public static TipoDocumento GetByName(string name)
        => GetAll().First(x => x.Name == name);

    public static bool IsValidName(string name)
        => GetAll().Any(x => x.Name == name);
}
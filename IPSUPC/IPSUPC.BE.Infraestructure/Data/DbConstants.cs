namespace IPSUPC.BE.Infraestructure.Data;

public static class DbConstants
{
    public const string DateTime2 = "datetime(7)";

    public static class Schemas
    {
        public const string Dbo = "dbo";
    }

    public static class Tables
    {
        //Añadir las tablas ejemplo debajo
        //public const string Productos = nameof(Productos);
        public const string Usuarios = nameof(Usuarios);
        public const string Medicos = nameof(Medicos);
        public const string Generos = nameof(Generos);
        public const string TipoDocumento = nameof(TipoDocumento);
        public const string Pacientes = nameof(Pacientes);
        public const string EstadoCivil = nameof(EstadoCivil);
        public const string HorasMedicas = nameof(HorasMedicas);
        public const string CitasMedicas = nameof(CitasMedicas);
        public const string Dia = nameof(Dia);
        public const string EstadoCita = nameof(EstadoCita);
        public const string TipoConsulta = nameof(TipoConsulta);
        public const string EFMigrationsHistory = $"_{nameof(EFMigrationsHistory)}_";
    }

    public static class StringLength
    {
        public const int Nombre = 250;
        public const int Email = 320;
        public const int Telefono = 15;
        public const int Contrasena = 100;
        public const int Direccion = 200;
        public const int EnumCode = 20;
        public const int CodigoPostal = 10;
        public const int Usuario = 100;
        public const int NumeroIdentificacion = 15;
        public const int Descripcion = 300;
        public const int Observacion = 500;
    }

    public static class ShadowProperties
    {
        public const string CreatedBy = nameof(CreatedBy);
        public const string CreatedDate = nameof(CreatedDate);
        public const string UpdatedBy = nameof(UpdatedBy);
        public const string UpdatedDate = nameof(UpdatedDate);
        public const string IsDeleted = nameof(IsDeleted);
        public const string DeletedBy = nameof(DeletedBy);
        public const string DeletedDate = nameof(DeletedDate);
        public const int CreatedByLength = 50;
        public const int UpdatedByLength = 50;
        public const int DeletedByLength = 50;
    }
}
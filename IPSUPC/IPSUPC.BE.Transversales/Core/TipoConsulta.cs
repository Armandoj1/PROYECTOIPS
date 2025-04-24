namespace IPSUPC.BE.Transversales
{
    public sealed class TipoConsulta
    {
        public static readonly TipoConsulta Enfermeria = new(1, Tipos.Enfermeria);
        public static readonly TipoConsulta Psicologia = new(2, Tipos.Psicologia);
        public static readonly TipoConsulta MedicinaGeneral = new(3, Tipos.MedicinaGeneral);
        public static readonly TipoConsulta Odontologia = new(4, Tipos.Odontologia);

        public static class Tipos
        {
            public const string Enfermeria = "ENFERMERÍA";
            public const string Psicologia = "PSICOLOGÍA";
            public const string MedicinaGeneral = "MEDICINA GENERAL";
            public const string Odontologia = "ODONTOLOGÍA"; 
        }

        public int TipoConsultaID { get; }
        public string Code { get; }

        private TipoConsulta(int id, string code)
        {
            TipoConsultaID = id;
            Code = code;
        }

        private TipoConsulta() { }

        public static TipoConsulta[] GetAll()
            => new[] { Enfermeria, Psicologia, MedicinaGeneral, Odontologia };

        public static TipoConsulta GetById(int id)
            => GetAll().First(x => x.TipoConsultaID == id);

        public static TipoConsulta GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValidCode(string code)
            => GetAll().Any(x => x.Code == code);
    }
}
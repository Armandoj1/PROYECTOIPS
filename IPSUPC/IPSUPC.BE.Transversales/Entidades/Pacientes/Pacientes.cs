namespace IPSUPC.BE.Transversales.Entidades;

public class Pacientes
{
    public string NumeroDocumento { get; set; }
    public int TipoDocumento { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
    public string Celular { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Departamento { get; set; }
    public string Pais { get; set; }
    public string CodigoPostal { get; set; }
    public int Genero { get; set; }
    public int EstadoCivil { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string LugarNacimiento { get; set; }
    public string Nacionalidad { get; set; }
    public string GrupoSanguineo { get; set; }
    public bool TieneAlergias { get; set; }
    public string Alergias { get; set; }
    public string Medicamentos { get; set; }
    public string EnfermedadesCronicas { get; set; }
    public string AntecedentesFamiliares { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
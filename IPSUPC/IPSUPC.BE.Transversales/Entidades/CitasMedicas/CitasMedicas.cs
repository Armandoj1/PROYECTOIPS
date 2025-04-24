namespace IPSUPC.BE.Transversales.Entidades;

public class CitasMedicas
{
    public int CitaMedicaID { get; set; }
    public string PacienteID { get; set; }
    public string MedicoID { get; set; }
    public int TipoConsultaID { get; set; }
    public int HorasMedicasID { get; set; }
    public int EstadoCitaID { get; set; }
    public int DiaID { get; set; }
    public DateTime FechaCita { get; set; }
    public string Observaciones { get; set; }   
}
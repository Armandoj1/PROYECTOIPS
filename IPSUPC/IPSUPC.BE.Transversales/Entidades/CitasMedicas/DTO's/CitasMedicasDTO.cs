using System.ComponentModel.DataAnnotations;

namespace IPSUPC.BE.Transversales.Entidades;

public class CitasMedicasDTO
{
    public int CitaMedicaID { get; set; }
    public string PacienteID { get; set; }
    public string MedicoID { get; set; }
    public string TipoConsultaID { get; set; }
    public string HorasMedicasID { get; set; }
    public string EstadoCitaID { get; set; }
    public string DiaID { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaCita { get; set; }
    public string Observaciones { get; set; }
}
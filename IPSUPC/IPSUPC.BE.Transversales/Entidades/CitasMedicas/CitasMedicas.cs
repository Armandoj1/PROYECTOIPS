using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IPSUPC.BE.Transversales.Entidades;

public class CitasMedicas
{
    public int CitaMedicaID { get; set; }
    public string PacienteID { get; set; }
    public string MedicoID { get; set; }
    public int TipoConsultaID { get; set; }
    public int HorasMedicasID { get; set; }
    public int EstadoCitaID { get; set; }
    [JsonIgnore]
    public int DiaID { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaCita { get; set; }
    public string Observaciones { get; set; }   
    public int LugarConsultaID { get; set; }
}
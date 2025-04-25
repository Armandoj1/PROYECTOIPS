using AutoMapper;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio;

public class CitasMedicasBLL : ICitasMedicasBLL
{

    private readonly ICitasMedicasDAL _citasMedicasDAL;
    private readonly IMapper _mapper;

    public CitasMedicasBLL(ICitasMedicasDAL citasMedicasDAL, IMapper mapper)
    {
        _citasMedicasDAL = citasMedicasDAL;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CitasMedicasDTO>> GetAllCitas()
    {
        var citas = await _citasMedicasDAL.GetAllCitas();
        return _mapper.Map<IEnumerable<CitasMedicasDTO>>(citas);
    }

    public async Task<IEnumerable<CitasMedicasDTO>> GetCitasMedico(string MedicoID)
    {
        var citas = await _citasMedicasDAL.GetCitasMedico(MedicoID);
        return _mapper.Map<IEnumerable<CitasMedicasDTO>>(citas);
    }

    public async Task<IEnumerable<CitasMedicasDTO>> GetCitasPaciente(string PacienteID)
    {
        var citas = await _citasMedicasDAL.GetCitasPaciente(PacienteID);
        return _mapper.Map<IEnumerable<CitasMedicasDTO>>(citas);
    }

    public async Task<IEnumerable<CitasMedicasDTO>> GetCitasTipoConsulta(int TipoConsulta)
    {
        var citas = await _citasMedicasDAL.GetCitasTipoConsulta(TipoConsulta);
        return _mapper.Map<IEnumerable<CitasMedicasDTO>>(citas);
    }

    public async Task<CitasMedicasDTO> GetCitaById(int id)
    {
        var citas = await _citasMedicasDAL.GetCitaById(id);
        return _mapper.Map<CitasMedicasDTO>(citas);
    }

    public async Task<CitasMedicas> CreateCita(CitasMedicas cita)
    {
        return await _citasMedicasDAL.CreateCita(cita);
    }

    public async Task<CitasMedicas> UpdateCita(CitasMedicas cita)
    {
        return await _citasMedicasDAL.UpdateCita(cita);
    }

    public async Task UpdateEstadoCitaId(int id, int EstadoCitaID)
    {
        await _citasMedicasDAL.UpdateEstadoCitaId(id, EstadoCitaID);
    }

}
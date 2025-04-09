using AutoMapper;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio;

public class MedicosBLL : IMedicosBLL
{
    private readonly IMedicosDAL _medicosDAL;
    private readonly IMapper _mapper;
    public MedicosBLL(IMedicosDAL medicosDAL, IMapper mapper)
    {
        _medicosDAL = medicosDAL;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MedicoDTO>> GetMedicosAsync()
    {
        var medicos = await _medicosDAL.GetMedicosAsync();
        return _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
    }

    public async Task<IEnumerable<MedicoDTO>> GetMedicosByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        var medicos = await _medicosDAL.GetMedicosByNumeroIdentificacionAsync(numeroIdentificacion);
        return _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
    }

    public async Task<Medico> CreateMedicosAsync(Medico medicos)
    {
        return await _medicosDAL.CreateMedicosAsync(medicos);
    }
    public async Task<Medico> UpdateMedicosAsync(Medico medicos)
    {
        return await _medicosDAL.UpdateMedicosAsync(medicos);
    }
    public async Task<Medico> DeleteMedicosAsync(string id)
    {
        return await _medicosDAL.DeleteMedicosAsync(id);
    }
}
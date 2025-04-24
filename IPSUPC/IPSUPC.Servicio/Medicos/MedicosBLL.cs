using AutoMapper;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales.Image;

namespace IPSUPC.BE.Servicio;

public class MedicosBLL : IMedicosBLL
{
    private readonly IMedicosDAL _medicosDAL;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public MedicosBLL(IMedicosDAL medicosDAL, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _medicosDAL = medicosDAL;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
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

    public async Task<Medico> CreateMedicosAsync(Medico medico)
    {
        if (medico.ImagenFile != null)
        {
            medico.ImagenUrl = await _cloudinaryService.SubirImagenAsync(medico.ImagenFile);
        }

        return await _medicosDAL.CreateMedicosAsync(medico);
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
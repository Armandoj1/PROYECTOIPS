using AutoMapper;
using IPSUPC.BE.Repositorio;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales.Image;

namespace IPSUPC.BE.Servicio;

public class PacientesBLL : IPacientesBLL
{
    private readonly IPacientesDAL _pacientesDAL;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public PacientesBLL (IPacientesDAL pacientesDAL, IMapper mapper, ICloudinaryService cloudinaryService)
    {
       _pacientesDAL = pacientesDAL;
       _mapper = mapper;
       _cloudinaryService = cloudinaryService;
    }

    public async Task<IEnumerable<PacientesDTO>> GetPacientesAsync()
    {
        var pacientes = await _pacientesDAL.GetPacientesAsync();
        return _mapper.Map<IEnumerable<PacientesDTO>>(pacientes);
    }

    public async Task<IEnumerable<PacientesDTO>> GetPacientesByNumeroIdentificacionAsync(string id)
    {
        var pacientes = await _pacientesDAL.GetPacientesByNumeroIdentificacionAsync(id);
        return _mapper.Map<IEnumerable<PacientesDTO>>(pacientes);
    }

    public async Task<Pacientes> CreatePacientesAsync(PacientesDTO pacientesdto)
    {
        var pacientes = _mapper.Map<Pacientes>(pacientesdto);
        if (pacientesdto.ImagenFile != null)
        {
            pacientes.ImagenUrl = await _cloudinaryService.SubirImagenAsync(pacientesdto.ImagenFile);
        }
        return await _pacientesDAL.CreatePacientesAsync(pacientes);
    }

    public async Task<Pacientes> UpdatePacientesAsync(Pacientes pacientes)
    {
        return await _pacientesDAL.UpdatePacientesAsync(pacientes);
    }

    public async Task<Pacientes> DeletePacientesAsync(string id)
    {
        return await _pacientesDAL.DeletePacientesAsync(id);
    }

}
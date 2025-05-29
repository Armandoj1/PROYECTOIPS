using AutoMapper;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales.Image;

namespace IPSUPC.BE.Servicio;

public class AdministradorBLL : IAdministradorBLL
{
    private readonly IAdministradorDAL _administradorDAL;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public AdministradorBLL(
        IAdministradorDAL administradorDAL,
        IMapper mapper,
        ICloudinaryService cloudinaryService)
    {
        _administradorDAL = administradorDAL;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<IEnumerable<AdministradorDTO>> GetAdministradoresAsync()
    {
        var administradores = await _administradorDAL.GetAdministradoresAsync();
        return _mapper.Map<IEnumerable<AdministradorDTO>>(administradores);
    }

    public async Task<IEnumerable<AdministradorDTO>> GetAdministradoresByNumeroIdentificacionAsync(string numeroIdentificacion)
    {
        var administradores = await _administradorDAL.GetAdministradoresByNumeroIdentificacionAsync(numeroIdentificacion);
        return _mapper.Map<IEnumerable<AdministradorDTO>>(administradores);
    }

    public async Task<Administrador> CreateAdministradorAsync(Administrador administrador)
    {
        if (administrador.ImagenFile != null)
        {
            administrador.ImagenUrl = await _cloudinaryService.SubirImagenAsync(administrador.ImagenFile);
        }

        return await _administradorDAL.CreateAdministradorAsync(administrador);
    }

    public async Task<Administrador> UpdateAdministradorAsync(Administrador administrador)
    {
        return await _administradorDAL.UpdateAdministradorAsync(administrador);
    }

    public async Task<Administrador> DeleteAdministradorAsync(string id)
    {
        return await _administradorDAL.DeleteAdministradorAsync(id);
    }

    public async Task<Administrador> CambiarFotoPerfil(string id, string url)
    {
        return await _administradorDAL.CambiarFotoPerfil(id, url);
    }
}
using AutoMapper;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {

        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dest => dest.RolId, opt => opt.MapFrom(src =>
            Rol.GetRolById(src.RolId) != null ? Rol.GetRolById(src.RolId).Nombre : "Desconocido"));

        CreateMap<UsuarioCreateDTO, Usuario>();
        CreateMap<Usuario, UsuarioCreateDTO>();


    }
}
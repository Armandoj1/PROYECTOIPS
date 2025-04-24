using AutoMapper;
using IPSUPC.BE.Transversales;
using IPSUPC.BE.Transversales.Entidades;

public class PacientesProfile : Profile
{
    public PacientesProfile()
    {
        CreateMap<Pacientes, PacientesDTO>()
            .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(src =>
                TipoDocumento.GetById(src.TipoDocumento) != null
                    ? TipoDocumento.GetById(src.TipoDocumento).Name
                    : "Desconocido"))
            .ForMember(dest => dest.Genero, opt => opt.MapFrom(src =>
                Generos.GetById(src.Genero) != null
                    ? Generos.GetById(src.Genero).Code
                    : "Desconocido"))
            .ForMember(dest => dest.EstadoCivil, opt => opt.MapFrom(src =>
                EstadoCivil.GetById(src.EstadoCivil) != null
                    ? EstadoCivil.GetById(src.EstadoCivil).Name
                    : "Desconocido"));

    }
}
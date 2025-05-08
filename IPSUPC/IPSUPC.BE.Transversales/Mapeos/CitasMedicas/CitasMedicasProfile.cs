using AutoMapper;
using IPSUPC.BE.Transversales.Core;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Transversales.Mapeos;

public class CitasMedicasProfile : Profile
{

    public CitasMedicasProfile()
    {
        CreateMap<CitasMedicas, CitasMedicasDTO>()
            .ForMember(dest => dest.TipoConsultaID, opt => opt.MapFrom(src =>
                TipoConsulta.GetById(src.TipoConsultaID) != null
                ? TipoConsulta.GetById(src.TipoConsultaID).Code
                : "Desconocido"))
            .ForMember(dest => dest.EstadoCitaID, opt => opt.MapFrom(src =>
                EstadoCita.GetById(src.EstadoCitaID) != null
                ? EstadoCita.GetById(src.EstadoCitaID).Code
                : "Desconocido"))
            .ForMember(dest => dest.HorasMedicasID, opt => opt.MapFrom(src =>
                HorasMedicas.GetById(src.HorasMedicasID) != null
                ? HorasMedicas.GetById(src.HorasMedicasID).Code
                : "Desconocido"))
            .ForMember(dest => dest.DiaID, opt => opt.MapFrom(src =>
                Dias.GetById(src.DiaID) != null
                ? Dias.GetById(src.DiaID).Code
                : "Desconocido"))
            .ForMember(dest => dest.LugarConsultaID, opt => opt.MapFrom(src =>
                LugarConsulta.GetById(src.LugarConsultaID) != null
                ? LugarConsulta.GetById(src.LugarConsultaID).Name
                : "Desconocido"));

    }
}
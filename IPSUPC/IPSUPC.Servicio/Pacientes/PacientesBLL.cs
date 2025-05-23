﻿using AutoMapper;
using IPSUPC.BE.Repositorio;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.BE.Servicio;

public class PacientesBLL : IPacientesBLL
{
    private readonly IPacientesDAL _pacientesDAL;
    private readonly IMapper _mapper;

    public PacientesBLL (IPacientesDAL pacientesDAL, IMapper mapper)
    {
       _pacientesDAL = pacientesDAL;
       _mapper = mapper;
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

    public async Task<Pacientes> CreatePacientesAsync(Pacientes pacientes)
    {
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
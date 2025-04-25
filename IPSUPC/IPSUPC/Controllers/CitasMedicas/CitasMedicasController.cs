using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IPSUPC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CitasMedicasController : ControllerBase
{
    private readonly ICitasMedicasBLL _citasMedicasBLL;

    public CitasMedicasController(ICitasMedicasBLL citasMedicasBLL)
    {
        _citasMedicasBLL = citasMedicasBLL;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _citasMedicasBLL.GetAllCitas();  
        return new OkObjectResult(result);
    }

    [HttpGet("GetCitasMedico/{MedicoID}")]
    public async Task<IActionResult> GetCitasMedico(string MedicoID)
    {
        var result = await _citasMedicasBLL.GetCitasMedico(MedicoID);
        return new OkObjectResult(result);
    }

    [HttpGet("GetCitasPaciente/{PacienteID}")]
    public async Task<IActionResult> GetCitasPaciente(string PacienteID)
    {
        var result = await _citasMedicasBLL.GetCitasPaciente(PacienteID);
        return new OkObjectResult(result);
    }

    [HttpGet("GetCitasTipoConsulta/{TipoConsulta}")]
    public async Task<IActionResult> GetCitasTipoConsulta(int TipoConsulta)
    {
        var result = await _citasMedicasBLL.GetCitasTipoConsulta(TipoConsulta);
        return new OkObjectResult(result);
    }

    [HttpGet("GetCitaById/{id}")]
    public async Task<IActionResult> GetCitaById(int id)
    {
        var result = await _citasMedicasBLL.GetCitaById(id);
        return new OkObjectResult(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CitasMedicas cita)
    {
        var result = await _citasMedicasBLL.CreateCita(cita);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] CitasMedicas cita)
    {
        var result = await _citasMedicasBLL.UpdateCita(cita);
        return new OkObjectResult(result);
    }

    [HttpPatch("UpdateEstadoCitaId/{id}/{EstadoCitaID}")]
    public async Task<IActionResult> UpdateEstadoCitaId(int id, int EstadoCitaID)
    {
        await _citasMedicasBLL.UpdateEstadoCitaId(id, EstadoCitaID);
        return Ok();
    }
}
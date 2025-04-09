using Microsoft.AspNetCore.Mvc;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;

namespace IPSUPC.Controllers
{
    [Route("api/[controller]")]
 
    public class PacientesController : ControllerBase
    {

        private readonly IPacientesBLL _pacienteBLL;

        public PacientesController(IPacientesBLL pacienteBLL)
        {
            _pacienteBLL = pacienteBLL;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pacienteBLL.GetPacientesAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("GetById/{NumeroDocumento}")]
        public async Task<IActionResult> GetById(string NumeroDocumento)
        {
            var result = await _pacienteBLL.GetPacientesByNumeroIdentificacionAsync(NumeroDocumento);
            return new OkObjectResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Pacientes paciente)
        {
            var result = await _pacienteBLL.CreatePacientesAsync(paciente);
            return new OkObjectResult(result);
        }

        [HttpPut("Update/{NumeroDocumento}")]
        public async Task<IActionResult> Update([FromBody] Pacientes paciente)
        {
            var result = await _pacienteBLL.UpdatePacientesAsync(paciente);
            return new OkObjectResult(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string NumeroIdentificacion)
        {
            var result = await _pacienteBLL.DeletePacientesAsync(NumeroIdentificacion);
            return new OkObjectResult(result);
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Servicio;
using AutoMapper;
using IPSUPC.BE.Transversales.Image;

namespace IPSUPC.Controllers
{
    [Route("api/[controller]")]
 
    public class PacientesController : ControllerBase
    {

        private readonly IPacientesBLL _pacienteBLL;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public PacientesController(IPacientesBLL pacienteBLL, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _pacienteBLL = pacienteBLL;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
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
        public async Task<IActionResult> Create([FromBody] Pacientes pacienteForm)
        {
            var result = await _pacienteBLL.CreatePacientesAsync(pacienteForm);
            return Ok(result);
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

        [HttpPatch("CambiarFotoPerfil")]
        public async Task<IActionResult> CambiarFotoPerfil(string id, [FromForm] CambioFotoPerfil imagenForm)
        {
            if (imagenForm.ImagenUrl == null)
                return BadRequest("No se recibió ninguna imagen.");

            var imagenUrl = await _cloudinaryService.SubirImagenAsync(imagenForm.ImagenUrl);

            var pacienteActualizado = await _pacienteBLL.CambiarFotoPerfil(id, imagenUrl);
            if (pacienteActualizado == null)
                return NotFound("Paciente no encontrado.");

            return Ok(pacienteActualizado);
        }


    }
}
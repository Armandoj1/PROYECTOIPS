using AutoMapper;
using IPSUPC.BE.Infraestructure.Migrations;
using IPSUPC.BE.Servicio;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales.Image;
using Microsoft.AspNetCore.Mvc;

namespace IPSUPC.Controllers.Medicos
{

    [Route("api/[controller]")]

    public class MedicosController : ControllerBase
    {
        private readonly IMedicosBLL _medicosBLL;
        private readonly ICloudinaryService _cloudinaryService;

        public MedicosController(IMedicosBLL medicosBLL, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _medicosBLL = medicosBLL;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _medicosBLL.GetMedicosAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("GetById/{NumeroDocumento}")]
        public async Task<IActionResult> GetById(string NumeroDocumento)
        {
            var result = await _medicosBLL.GetMedicosByNumeroIdentificacionAsync(NumeroDocumento);
            return new OkObjectResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Medico medico)
        {
            var result = await _medicosBLL.CreateMedicosAsync(medico);
            return Ok(result);
        }

        [HttpPut("Update/{NumeroDocumento}")]
        public async Task<IActionResult> Update([FromBody] Medico medico)
        {
            var result = await _medicosBLL.UpdateMedicosAsync(medico);
            return new OkObjectResult(result);
        }

        [HttpDelete("Delete/{NumeroDocumento}")]
        public async Task<IActionResult> Delete(string NumeroDocumento)
        {
            var result = await _medicosBLL.DeleteMedicosAsync(NumeroDocumento);
            return new OkObjectResult(result);
        }

        [HttpPatch("CambiarFotoPerfil")]
        public async Task<IActionResult> CambiarFotoPerfil(string id, [FromForm] CambioFotoPerfil fotoPerfil)
        {
            if (fotoPerfil.ImagenUrl == null)
                return BadRequest("No se recibió ninguna imagen.");

            var imagenUrl = await _cloudinaryService.SubirImagenAsync(fotoPerfil.ImagenUrl);

            var medicoActualizado = await _medicosBLL.CambiarFotoPerfil(id, imagenUrl);
            if (medicoActualizado == null)
                return NotFound("Médico no encontrado.");

            return Ok(medicoActualizado);
        }

    }
}
using IPSUPC.BE.Servicio;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using IPSUPC.BE.Transversales.Image;
using Microsoft.AspNetCore.Mvc;

namespace IPSUPC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorBLL _administradorBLL;
        private readonly IConfiguration _configuration;
        private readonly ICloudinaryService _cloudinaryService;


        public AdministradorController(IAdministradorBLL administradorBLL, IConfiguration configuration, ICloudinaryService cloudinaryService)
        {
            _administradorBLL = administradorBLL;
            _configuration = configuration;
            _cloudinaryService = cloudinaryService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _administradorBLL.GetAdministradoresAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string numeroDocumento)
        {
            var result = await _administradorBLL.GetAdministradoresByNumeroIdentificacionAsync(numeroDocumento);
            return new OkObjectResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Administrador administrador)
        {
            if (administrador == null)
            {
                return BadRequest("El administrador no puede ser nulo.");
            }
            var result = await _administradorBLL.CreateAdministradorAsync(administrador);
            return new OkObjectResult(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Administrador administrador)
        {
            if (administrador == null)
            {
                return BadRequest("El administrador no puede ser nulo.");
            }
            var result = await _administradorBLL.UpdateAdministradorAsync(administrador);
            return new OkObjectResult(result);
        }

        [HttpDelete("Delete/{numeroDocumento}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("El ID del administrador no puede ser nulo o vacío.");
            }
            var result = await _administradorBLL.DeleteAdministradorAsync(id);
            return new OkObjectResult(result);
        }

        [HttpPatch("CambiarFotoPerfil")]
        public async Task<IActionResult> CambiarFotoPerfil(string id, [FromForm] CambioFotoPerfil fotoPerfil)
        {
            if (fotoPerfil.ImagenUrl == null)
                return BadRequest("No se recibió ninguna imagen.");

            var imagenUrl = await _cloudinaryService.SubirImagenAsync(fotoPerfil.ImagenUrl);

            var medicoActualizado = await _administradorBLL.CambiarFotoPerfil(id, imagenUrl);
            if (medicoActualizado == null)
                return NotFound("Médico no encontrado.");

            return Ok(medicoActualizado);
        }

    }

}
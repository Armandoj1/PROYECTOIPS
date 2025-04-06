using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IPSUPC.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioBLL _usuarioBLL;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioBLL usuarioBLL, IConfiguration configuration)
        {
            _usuarioBLL = usuarioBLL;
            _configuration = configuration;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usuarioBLL.GetUsuarioAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usuarioBLL.GetUsuarioByIdAsync(id);
            return new OkObjectResult(result);
        }

        [HttpGet("GetByNumeroIdentificacion/{numeroIdentificacion}")]
        public async Task<IActionResult> GetByNumeroIdentificacion(string numeroIdentificacion)
        {
            var result = await _usuarioBLL.GetUsuarioByNumeroIdentificacionAsync(numeroIdentificacion);
            return new OkObjectResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDTO usuario)
        {
            var result = await _usuarioBLL.CreateUsuarioAsync(usuario);
            return new OkObjectResult(result);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] UsuarioCreateDTO usuario)
        {
            var result = await _usuarioBLL.UpdateUsuarioAsync(usuario);
            return new OkObjectResult(result);
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioBLL.DeleteUsuarioAsync(id);
            return new OkObjectResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomLoginRequest loginRequest)
        {
            try
            {
                var token = await _usuarioBLL.LoginAsync(loginRequest.NombreUsuario, loginRequest.Password, _configuration);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IPSUPC.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController
    {

        private readonly IUsuarioBLL _usuarioBLL;

        public UsuarioController(IUsuarioBLL usuarioBLL)
        {
            _usuarioBLL = usuarioBLL;
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
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            var result = await _usuarioBLL.CreateUsuarioAsync(usuario);
            return new OkObjectResult(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Usuario usuario)
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

        [HttpGet("GetCredenciales/{usuario}/{password}")]
        public async Task<IActionResult> GetCredenciales(string usuario, string password)
        {
            var result = await _usuarioBLL.GetUsuarioByCredentialsAsync(usuario, password);
            return new OkObjectResult(result);
        }

    }
}
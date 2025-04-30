using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IPSUPC.API.Controllers
{
    [ApiController]
    [Route("swaggerjson")]
    public class SwaggerController : ControllerBase
    {
        private readonly ISwaggerProvider _swaggerProvider;

        public SwaggerController(ISwaggerProvider swaggerProvider)
        {
            _swaggerProvider = swaggerProvider;
        }

        [HttpGet("{documentName}")]
        public IActionResult GetSwaggerJson(string documentName = "v1")
        {
            var swagger = _swaggerProvider.GetSwagger(documentName);
            return Ok(swagger);
        }
    }
}
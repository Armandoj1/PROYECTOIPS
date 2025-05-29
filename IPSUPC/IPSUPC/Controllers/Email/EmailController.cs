using IPSUPC.BE.Infraestructure.Options;
using IPSUPC.BE.Servicio.Interface.Email;
using IPSUPC.BE.Transversales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IPSUPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;

        public EmailController(IEmailService emailService, IOptions<EmailSettings> emailSettings)
        {
            _emailService = emailService;
            _emailSettings = emailSettings.Value;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromForm] EmailRequest request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.To) || string.IsNullOrWhiteSpace(request.Subject) || string.IsNullOrWhiteSpace(request.Body))
            {
                return BadRequest("Todos los campos son obligatorios.");
            }

            await _emailService.SendEmailAsync(request.To, request.Subject, request.Body, request.Attachment, cancellationToken);
            return Ok(new { Message = "Correo enviado exitosamente." });
        }

        [HttpGet("email-config")]
        public IActionResult GetEmailConfig()
        {
            return Ok(_emailSettings);
        }
    }
}
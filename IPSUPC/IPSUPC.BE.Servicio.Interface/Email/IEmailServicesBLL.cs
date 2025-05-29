using Microsoft.AspNetCore.Http;

namespace IPSUPC.BE.Servicio.Interface.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, IFormFile? attachment = null, CancellationToken cancellationToken = default);
    }
}
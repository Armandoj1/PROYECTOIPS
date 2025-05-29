using Microsoft.AspNetCore.Http;
namespace IPSUPC.BE.Transversales;
#nullable enable
public class EmailRequest
{
    public string To { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string Body { get; set; } = default!;
    public IFormFile? Attachment { get; set; }
}
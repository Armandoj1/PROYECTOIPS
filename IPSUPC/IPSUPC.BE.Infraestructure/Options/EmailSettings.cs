namespace IPSUPC.BE.Infraestructure.Options;

public record EmailSettings
{
    public string SmtpServer { get; set; } = default!;
    public int SmtpPort { get; set; }
    public string SenderEmail { get; set; } = default!;
    public string SenderPassword { get; set; } = default!;
    public bool EnableSSL { get; set; }
}
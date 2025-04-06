using System.Text.Json.Serialization;

namespace IPSUPC.BE.Transversales.Entidades;

public class CustomLoginRequest
{
    public string? NombreUsuario { get; init; }
    public required string Password { get; init; }
    //[JsonIgnore]
    //public required string Email { get; init; }
    //[JsonIgnore]
    //public string? TwoFactorCode { get; init; }
    //[JsonIgnore]
    //public string? TwoFactorRecoveryCode { get; init; }
}
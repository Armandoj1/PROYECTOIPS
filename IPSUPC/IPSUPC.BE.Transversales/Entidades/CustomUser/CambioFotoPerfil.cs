using Microsoft.AspNetCore.Http;

namespace IPSUPC.BE.Transversales.Entidades;

public class CambioFotoPerfil
{
    public IFormFile ImagenUrl { get; set; }
    public string Id { get; set; }
}
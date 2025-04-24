using Microsoft.AspNetCore.Http;

namespace IPSUPC.BE.Transversales.Image
{
    public interface ICloudinaryService
    {
        Task<string> SubirImagenAsync(IFormFile file);
    }
}
using Microsoft.AspNetCore.Http;

namespace T.Infrastructure.ImageServer
{
    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files, string category, string name);
    }
}

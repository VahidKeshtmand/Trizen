using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;

namespace T.Infrastructure.ImageServer
{
    public class ImageUploadService : IImageUploadService
    {
        public List<string> Upload(List<IFormFile> files, string category, string name)
        {
            var client = new RestClient($"https://localhost:7235/api/File?apikey=MySecretKey&&category={category}&&name={name}");
            // client.Timeout = -1;
            var request = new RestRequest("", Method.Post);

            foreach (var file in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(file.FileName, bytes, file.FileName, file.ContentType);
            }
            var response = client.Execute(request);
            var upload = JsonConvert.DeserializeObject<UploadFileDto>(response.Content);
            return upload.FileNameAddresses;
        }
    }
}

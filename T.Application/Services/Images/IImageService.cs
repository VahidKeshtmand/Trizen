using Microsoft.AspNetCore.Http;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace T.Application.Images
{
    public interface IImageService
    {
        string Upload(IFormFile image, string category);
        List<string> Upload(List<IFormFile> images, string category);
        BaseDto Remove(int id);
    }

    public class ImageService : IImageService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IHostingEnvironment _webHostEnvironment;

        public ImageService(IDatabaseContext databaseContext, IHostingEnvironment webHostEnvironment)
        {
            _databaseContext = databaseContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public BaseDto Remove(int id)
        {
            var image = _databaseContext.Images.FirstOrDefault(x => x.Id == id);
            if (image == null)
                return new BaseDto
                {
                    IsSuccess = false
                };
            var address = _webHostEnvironment.WebRootPath + $@"{image.Src}";
            try
            {
                _databaseContext.Images.Remove(image);
                _databaseContext.SaveChanges();
                File.Delete(address);
            }
            catch (System.Exception)
            {
                return new BaseDto
                {
                    IsSuccess = false
                };
            }
            return new BaseDto
            {
                IsSuccess = true
            };

        }

        public string Upload(IFormFile image, string category)
        {
            var uploadRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, $@"Images\{category}");
            if (!Directory.Exists(uploadRootFolder))
                Directory.CreateDirectory(uploadRootFolder);
            var imageName = $"{Guid.NewGuid()} - {image.FileName}";
            var imageAddress = Path.Combine(uploadRootFolder, imageName);
            using (var fileStream = new FileStream(imageAddress, FileMode.Create)) image.CopyTo(fileStream);
            return $@"\Images\{category}\" + imageName;
        }

        public List<string> Upload(List<IFormFile> images, string category)
        {
            var uploadRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, $@"Images\{category}");
            if (!Directory.Exists(uploadRootFolder))
                Directory.CreateDirectory(uploadRootFolder);
            var addresses = new List<string>();
            foreach (var item in images)
            {
                var imageName = $"{Guid.NewGuid()} - {item.FileName}";
                var imageAddress = Path.Combine(uploadRootFolder, imageName);
                using (var fileStream = new FileStream(imageAddress, FileMode.Create)) item.CopyTo(fileStream);
                addresses.Add($@"\Images\{category}\" + imageName);
            }
            return addresses;
        }
    }
}

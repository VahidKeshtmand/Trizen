using Microsoft.AspNetCore.Mvc;
using T.StaticFiles.Endpoint.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace T.StaticFiles.Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public IActionResult Post(string apiKey, string category, string name)
    {
        if (apiKey != "MySecretKey")
            return BadRequest();

        var files = Request.Form.Files;
        //var folderName = Path.Combine("Resource", "Images");
        //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        if (files != null)
        {
            var result = UploadImage(files, category, name);
            return Ok(result);
        }
        return BadRequest();
    }

    private UploadFileDto UploadImage(IFormFileCollection files, string category, string name)
    {
        var dataTime = DateTime.Now;
        var folder = string.Empty;
        if (name == "0")
        {
            folder = $@"Resources/Images/{category}/{dataTime.Year}/{dataTime.Year} - {dataTime.Month}/";
        }
        else
        {
            folder = $@"Resources/Images/{category}/{name}/{dataTime.Year}/{dataTime.Year} - {dataTime.Month}/";
        }
        var uploadRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
        if (!Directory.Exists(uploadRootFolder))
            Directory.CreateDirectory(uploadRootFolder);
        List<string> address = new List<string>();
        var newName = Guid.NewGuid().ToString();
        foreach (var file in files)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = newName + file.FileName;
                var filePath = Path.Combine(uploadRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) file.CopyTo(fileStream);
                address.Add(folder + fileName);
            }
        }

        return new UploadFileDto
        {
            Status = true,
            FileNameAddresses = address
        };
    }
}

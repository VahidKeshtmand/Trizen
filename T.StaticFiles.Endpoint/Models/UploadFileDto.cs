namespace T.StaticFiles.Endpoint.Models
{
    public class UploadFileDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddresses { get; set; } = new();
    }
}

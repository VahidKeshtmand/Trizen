namespace T.Application.Dtos.Common
{
    public class BaseDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }

    public class BaseDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}

namespace T.Domain.Attributes
{
    // این Attribute فقط برای کلاس ها استفاده میشن.
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute : Attribute{}
}

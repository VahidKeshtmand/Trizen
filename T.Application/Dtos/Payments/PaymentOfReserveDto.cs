namespace T.Application.Dtos.Payments;

public class PaymentOfReserveDto
{
    public Guid PaymentId { get; set; }
    public double Amount { get; set; }
}

public class PaymentDto
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public int Amount { get; set; }
    public string UserId { get; set; }
}

public class VerificationPayResultDto
{
    public int Status { get; set; }
    public long RefId { get; set; }
}


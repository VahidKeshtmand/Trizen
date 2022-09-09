using T.Domain.Attributes;
using T.Domain.Flights;
using T.Domain.Reserves;

namespace T.Domain.Payments;

[Auditable]
public class Payment
{
    public Guid Id { get; set; }
    public double Amount { get; private set; }
    public bool IsPay { get; private set; } = false;
    public DateTime? DatePay { get; private set; } = null;
    public string? Authority { get; private set; }
    public long RefId { get; private set; } = 0;
    public Reserve Reserve { get; private set; }
    public int ReserveId { get; private set; }

    public Payment(double amount, int reserveId)
    {
        Amount = amount;
        ReserveId = reserveId;
    }

    public void PaymentIsDone(string authority, long refId)
    {
        IsPay = true;
        DatePay = DateTime.Now;
        Authority = authority;
        RefId = refId;
    }
}

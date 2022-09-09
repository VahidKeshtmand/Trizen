using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Payments;
using T.Application.Interfaces.Contexts;
using T.Domain.Payments;

namespace T.Application.Services.PaymentServices;



public interface IPaymentService
{
    PaymentOfReserveDto PayForReserve(int reserveId);
    PaymentDto GetPayment(Guid paymentId);
    bool VerifyPayment(Guid id, string authority, long refId);
}

public class PaymentService : IPaymentService
{
    private readonly IDatabaseContext _databaseContext;
    private readonly IIdentityDatabaseContext _identityDatabaseContext;

    public PaymentService(IDatabaseContext databaseContext, IIdentityDatabaseContext identityDatabaseContext)
    {
        _databaseContext = databaseContext;
        _identityDatabaseContext = identityDatabaseContext;
    }

    public PaymentDto GetPayment(Guid paymentId)
    {
        var payment = _databaseContext.Payments
            .Include(x => x.Reserve).ThenInclude(x => x.ReserveRooms).ThenInclude(x => x.Room).SingleOrDefault(x => x.Id == paymentId);
        if (payment == null)
            throw new Exception("");
        var user = _identityDatabaseContext.Users.FirstOrDefaultAsync(x => x.Id == payment.Reserve.UserId).Result;
        if (user == null)
            throw new Exception("");

        var description = $"پرداخت سفارش شماره {payment.ReserveId} " + Environment.NewLine;
        description += $"محصولات" + Environment.NewLine;
        foreach (var item in payment.Reserve.ReserveRooms.Select(x => x.Room.Name))
        {
            description += $" -{item}";
        }
        return new PaymentDto
        {
            Amount = (int)payment.Reserve.TotalPrice(),
            Email = user.Email,
            Description = description,
            PhoneNumber = user.PhoneNumber,
            UserId = user.Id,
            Id = payment.Id
        };
    }

    public PaymentOfReserveDto PayForReserve(int reserveId)
    {
        var reserve = _databaseContext.Reserves
            .Include(x => x.ReserveRooms).SingleOrDefault(x => x.Id == reserveId);

        if (reserve == null)
            throw new Exception("");

        var payment = _databaseContext.Payments.SingleOrDefault(x => x.ReserveId == reserve.Id);
        if (payment == null)
        {
            payment = new Payment(reserve.TotalPrice(), reserve.Id);
            _databaseContext.Payments.Add(payment);
            _databaseContext.SaveChanges();
        }

        return new PaymentOfReserveDto
        {
            Amount = payment.Amount,
            PaymentId = payment.Id,

        };
    }

    public bool VerifyPayment(Guid id, string authority, long refId)
    {
        var payment = _databaseContext.Payments
            .Include(x => x.Reserve)
            .SingleOrDefault(x => x.Id == id);

        if (payment == null)
            throw new Exception();

        payment.Reserve.PaymentDone();
        payment.PaymentIsDone(authority, refId);
        _databaseContext.SaveChanges();
        return true;
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OS.Website.EndPoint.Utilities;
using T.Application.Dtos.Baskets;
using T.Application.Services.Baskets;
using T.Application.Services.Orders;
using T.Application.Services.PaymentServices;
using T.Domain.Account;
using T.Website.Endpoint.Models.Baskets;

namespace T.Website.Endpoint.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;
    private readonly SignInManager<User> _signInManager;
    private readonly IPaymentService _paymentService;
    private string UserId = null;

    public BasketController(IBasketService basketService, SignInManager<User> signInManager, IOrderService orderService, IPaymentService paymentService)
    {
        _basketService = basketService;
        _signInManager = signInManager;
        _orderService = orderService;
        _paymentService = paymentService;
    }

    public IActionResult Index()
    {
        var model = GetOrSetBasket();
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(int id, string checkInDate, string checkOutDate, int bedNumber, int discountPercent, int quantity = 1)
    {
        var basket = GetOrSetBasket();
        _basketService.AddRoomToBasket(basket.Id, id, checkInDate, checkOutDate, bedNumber, discountPercent, quantity);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteItem(int id)
    {
        var result = _basketService.DeleteItem(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error" });
        return new JsonResult(new { status = "success" });

    }

    [Authorize]
    public IActionResult ShippingPayment()
    {
        var model = new ShippingPaymentViewModel();
        var userId = ClaimUtility.GetUserId(User);
        model.Basket = _basketService.GetOrCreateBasketForUser(userId);
        return View(model);
    }

    [Authorize]
    public IActionResult ShippingPaymentPost()
    {
        var userId = ClaimUtility.GetUserId(User);
        var basket = _basketService.GetOrCreateBasketForUser(userId);
        var orderId = _orderService.Create(basket.Id);
        var payment = _paymentService.PayForReserve(orderId);

        return RedirectToAction("Index", "Pay", new { paymentId = payment.PaymentId });
    }

    private BasketDto GetOrSetBasket()
    {
        if (_signInManager.IsSignedIn(User))
        {
            UserId = ClaimUtility.GetUserId(User);
            return _basketService.GetOrCreateBasketForUser(UserId);
        }
        SetCookieForBasket();
        return _basketService.GetOrCreateBasketForUser(UserId);
    }

    private void SetCookieForBasket()
    {
        var basketCookieName = "basketId";
        if (Request.Cookies.ContainsKey(basketCookieName))
        {
            UserId = Request.Cookies[basketCookieName];
        }
        if (UserId != null) return;
        UserId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Today.AddYears(2) };
        Response.Cookies.Append(basketCookieName, UserId, cookieOptions);
    }
}

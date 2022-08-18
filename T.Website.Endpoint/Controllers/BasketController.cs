using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OS.Website.EndPoint.Utilities;
using T.Application.Dtos.Baskets;
using T.Application.Services.Baskets;
using T.Domain.Account;

namespace T.Website.Endpoint.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly SignInManager<User> _signInManager;
    private string UserId = null;

    public BasketController(IBasketService basketService, SignInManager<User> signInManager)
    {
        _basketService = basketService;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        var model = GetOrSetBasket();
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(int id, string checkInDate, string checkOutDate, int bedNumber, int quantity = 1)
    {
        var basket = GetOrSetBasket();
        _basketService.AddRoomToBasket(basket.Id, id, checkInDate, checkOutDate, bedNumber, quantity);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteItem(int id)
    {
        var result = _basketService.DeleteItem(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error" });
        return new JsonResult(new { status = "success" });

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

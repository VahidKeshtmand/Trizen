using Microsoft.AspNetCore.Mvc;

namespace T.Website.Endpoint.ViewComponents
{
    public class RegisterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

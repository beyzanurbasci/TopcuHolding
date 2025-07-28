using Microsoft.AspNetCore.Mvc;
using TopcuHolding.Route;



namespace TopcuHolding.Controllers
{  [Route(Routes.Contact.Index)]
    public class ContactController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}

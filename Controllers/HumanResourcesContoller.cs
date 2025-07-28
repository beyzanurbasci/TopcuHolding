using Microsoft.AspNetCore.Mvc;
using TopcuHolding.Route;

public class HumanResourcesController : Controller
{
    [Route(Routes.HumanResources.Index)]
    public IActionResult Index()
    {
        return View();
    }


}

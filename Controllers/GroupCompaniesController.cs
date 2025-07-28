using Microsoft.AspNetCore.Mvc;
using TopcuHolding.Route;

public class GroupCompaniesController : Controller
{

    [Route(Routes.GroupCompanies.ReisMakina)]
    public IActionResult ReisMakina()
    {
        return View();
    }
    [Route(Routes.GroupCompanies.TopcularEndustriyel)]
    public IActionResult TopcularEndustriyel()
    {
        return View();
    }
    [Route(Routes.GroupCompanies.RevoEndustriyel)]
    public IActionResult RevoEndustriyel()
    {
        return View();
    }
    [Route(Routes.GroupCompanies.Mar)]
    public IActionResult Mar()
    {
        return View();
    }

}

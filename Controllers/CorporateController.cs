using Microsoft.AspNetCore.Mvc;
using TopcuHolding.Route;

namespace TopcuHolding.Controllers
{
    public class CorporateController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route(Routes.Corporate.About)]
        public IActionResult About()
        {
            return View();
        }
        [Route(Routes.Corporate.BoardOfManagement)]
        public IActionResult BoardOfManagement()
        {
            return View();
        }
        [Route(Routes.Corporate.GeneralManagerMessage)]
        public IActionResult GeneralManagerMessage()
        {
            return View();
        }
        [Route(Routes.Corporate.History)]
        public IActionResult History()
        {
            return View();
        }
        [Route(Routes.Corporate.MissionandVision)]
        public IActionResult MissionandVision()
        {
            return View();
        }
        [Route(Routes.Corporate.OurValues)]
        public IActionResult OurValues()
        {
            return View();
        }
        [Route(Routes.Corporate.ManagerMessage)]
        public IActionResult ManagerMessage()
        {
            return View();
        }

    }
   
   

    
   

}

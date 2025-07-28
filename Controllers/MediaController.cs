using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using TopcuHolding.Route;

namespace TopcuHolding.Controllers
{
    public class MediaController : Controller
    {
        [HttpGet]
        [Route(Routes.Media.Index)]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail)]
        public IActionResult Detail()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail1)]
        public IActionResult Detail1()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail2)]
        public IActionResult Detail2()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail3)]
        public IActionResult Detail3()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail4)]
        public IActionResult Detail4()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail5)]
        public IActionResult Detail5()
        {
            return View();
        }
        [HttpGet]
        [Route(Routes.Media.Detail6)]
        public IActionResult Detail6()
        {
            return View();
        }
    }
}

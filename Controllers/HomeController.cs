using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EgyptTouristWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger,IHomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }
        public IActionResult Index()
        {
            HomeViewModel model = homeService.CreatHomeVM();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using EgyptTouristWebSite.Context;
using Microsoft.AspNetCore.Mvc;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace EgyptTouristWebSite.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly DataBaseContext _context;
        public DashBoardController(DataBaseContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.NumPlaces = _context.InterestingPlaces.Count();
            model.NumUserAccounts = _context.Users.Count();
            model.NumTravelAgencies = _context.TravelAgencies.Count();
            model.NumServices = _context.Services.Count();
            model.NumAccommodations = _context.Accommodations.Count();
            model.Users = _context.Users.ToList();
            return View(model);
        }
    }
}

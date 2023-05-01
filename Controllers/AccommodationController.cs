using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace EgyptTouristWebSite.Controllers
{
    public class AccommodationController : Controller
    {
      
        private readonly IAccommodationService accService;
        private readonly IAccommodationRepo accRepo;
        private readonly IUserService userService;

        public AccommodationController(IAccommodationService _accService,IAccommodationRepo _accRepo,IUserService userService)
        {
            accService = _accService;
            accRepo = _accRepo;
            this.userService = userService;
        }

        public IActionResult ShowAllPlaces()
        {
            AccommodationsViewModel accModel = accService.GetAccommodationVM();
            Console.WriteLine(accModel.accMotels.Count);
            Console.WriteLine(accModel.accHotels.Count);
            Console.WriteLine(accModel.accResorts.Count);
            Console.WriteLine(accModel.accsList.Count);

            return View(accModel);
        }
        public IActionResult ShowFilteredPlaces(string[] types, string[] prices, string[] ratings)
        {
            var places = accService.Filter(types, prices, ratings);
            return PartialView("FilteredAccommodationsPartial", places);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var acc = accRepo.GetById(id);
            if (acc == null) return NotFound();

            return View(acc);
        }
        public IActionResult SearchByName(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) { return Ok(); }
            var places = accRepo.GetByName(searchString);
            return PartialView("FilteredAccommodationsPartial", places);
        }
        public IActionResult ShowPlacesByCategory(string category)
        {
            dynamic places = accRepo.GetByCat(category);
            return View(places);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            accRepo.Delete(id);
            return View();
        }
        [Authorize]
        //[ValidateAntiForgeryToken]

        public async Task<IActionResult> Reserve(Accommodation acc)
        {
            Accommodation accToReserve = accRepo.GetById(acc.Id);
          bool res= await userService.AddAccommodation(accToReserve, User.Identity.Name);
            if (res)
            {
                return RedirectToAction("Profile", "Account", new {name=User.Identity.Name});
            }
            else
            {
                return BadRequest();
            }

        }
    }
}

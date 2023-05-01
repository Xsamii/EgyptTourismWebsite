using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class InterestingPlaceController : Controller
    {
        private readonly IInterPlaceService placeService;
        private readonly IPlaceRepo placeRepo;
        private readonly IprofileService profileService;

        public InterestingPlaceController(IInterPlaceService _placeService,IPlaceRepo _placeRepo,IprofileService profileService)
        {
            placeService = _placeService;
            placeRepo = _placeRepo;
            this.profileService = profileService;
        }



        public IActionResult ShowAllPlaces()
        {
            PlacesViewModel model = placeService.GetPlaceVM();
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public IActionResult ShowPlacesByCategory(string category)
        {
            dynamic places = placeRepo.GetByCat(category);
            return View(places);
        }
        //[ValidateAntiForgeryToken]
        [Authorize]
       // [Route("{id}")]
        public IActionResult Details(int id)
        {
            var place = placeRepo.GetById(id);
            return View(place);
        }
        public IActionResult SearchByName(string name)
        {
            var place = placeRepo.GetByName(name);
            return View(place);
        }
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Delete(int id)
        {
            placeRepo.Delete(id);
            return View();  // Redirect To Action of Admin List of places
        }
        [Authorize]
        public async Task<IActionResult> Reserve(InterestingPlace place)
        {
            InterestingPlace placeToReserve = placeRepo.GetById(place.Id);
            bool res = await profileService.AddPlace(placeToReserve, User.Identity.Name);
            if (res)
            {
                return RedirectToAction("Profile", "Account", new { name = User.Identity.Name });
            }
            else
            {
                return BadRequest();
            }

        }



    }
}

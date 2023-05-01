using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class TravelAgencyController : Controller
    {
        private readonly ITravelAgencyRepo _travelAgencyRepo;
        private readonly IprofileService _profileService;
        public TravelAgencyController(ITravelAgencyRepo travelAgencyRepo, IprofileService profileService)
        {
            _travelAgencyRepo = travelAgencyRepo;
            _profileService = profileService;
        }

        public IActionResult ShowAllPlaces()
        {
            var Allagency = _travelAgencyRepo.GetAll();
            return View(Allagency);
        }
       // [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(int id)
        {
            var agency = _travelAgencyRepo.GetById(id);
            return View(agency);
        }
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _travelAgencyRepo.Delete(id);
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Reserve(TravelAgency travelAgency)
        {
            TravelAgency travelToAdd = _travelAgencyRepo.GetById(travelAgency.Id);
            bool res = await _profileService.AddTravelAgency(travelToAdd, User.Identity.Name);
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

using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class TourGuideController : Controller
    {
        private readonly ITourGuidRepo tourRepo;

        public TourGuideController(ITourGuidRepo tourRepo)
        {
            this.tourRepo = tourRepo;
        }

        public IActionResult ShowAllPlaces()
        {
            var Alltourguide = tourRepo.GetAll();
            return View();
        }

        public IActionResult SearchById(int id)
        {
            var tourguide = tourRepo.GetById(id);
            return View();
        }

        public IActionResult Delete(int id)
        {
            tourRepo.Delete(id);
            return View();
        }
    }
}

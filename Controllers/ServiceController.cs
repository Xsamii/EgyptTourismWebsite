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
    public class ServiceController : Controller
    {

        private readonly IServicesService _servicesService;
        private readonly IServiceRepo _serviceRepo;
        private readonly IprofileService _profileService;
        public ServiceController(IServiceRepo serviceRepo,IServicesService servicesService, IprofileService profileService)
        {
            _serviceRepo = serviceRepo;
            _servicesService = servicesService;
            _profileService = profileService;

        }

        public IActionResult ShowAllServices()
        {
            var allServices = _servicesService.GetServiceVM();
            return View(allServices);
        }
        public IActionResult ShowServicesByCategory(string category)
        {
            var serviceCat = _serviceRepo.GetByCat(category);
            return View(serviceCat);
        }
        //[ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(int id)
        {
            var service = _serviceRepo.GetById(id);
            return View(service);
        }
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _serviceRepo.Delete(id);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Reserve(Service service)
        {
            Service serviceToAdd = _serviceRepo.GetById(service.Id);
            bool res = await _profileService.AddServices(serviceToAdd, User.Identity.Name);
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

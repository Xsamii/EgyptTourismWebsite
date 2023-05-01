using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;


namespace EgyptTouristWebSite.Services
{
    public class HomeService : IHomeService
    {
        private readonly IAccommodationRepo accRepo;
        private readonly IServiceRepo serviceRepo;
        private readonly IPlaceRepo placeRepo;

        public HomeService(IAccommodationRepo accRepo,IServiceRepo serviceRepo,IPlaceRepo placeRepo)
        {
            this.accRepo = accRepo;
            this.serviceRepo = serviceRepo;
            this.placeRepo = placeRepo;
        }
        public HomeViewModel CreatHomeVM()
        {
            HomeViewModel model = new HomeViewModel();
            model.accommodations = accRepo.GetAllWithType();
            model.services = serviceRepo.GetAll();
            model.places = placeRepo.GetAllWithCategory();
            return model;
        }
    }
}

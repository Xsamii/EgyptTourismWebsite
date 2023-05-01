using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;

namespace EgyptTouristWebSite.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepo _serviceRepo;
        public ServicesService(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        public List<Accommodation> Filter(string[] types, string[] prices, string[] ratings)
        {
            throw new NotImplementedException();
        }

       
        public ServicesViewModel GetServiceVM()
        {
            List<Service> allServices = _serviceRepo.GetAll();
            ServicesViewModel serviceVM = new ServicesViewModel();
            serviceVM.banks = allServices.Where(s => s.Type.Type =="Bank").ToList();
            serviceVM.restaurants = allServices.Where(s => s.Type.Type == "Restaurant").ToList();
            serviceVM.embassies = allServices.Where(s => s.Type.Type == "Embassy").ToList();
            serviceVM.malls = allServices.Where(s => s.Type.Type == "Mall").ToList();

            serviceVM.services.Add(serviceVM.banks);
            serviceVM.services.Add(serviceVM.restaurants);
            serviceVM.services.Add(serviceVM.embassies);
            serviceVM.services.Add(serviceVM.malls);

            return serviceVM;
        }

    }
}

using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Services
{
    public class InterPlaceService : IInterPlaceService
    {
        private readonly IPlaceRepo placeRepo;
            public InterPlaceService(IPlaceRepo _placeRepo)
        {
            placeRepo=_placeRepo;
        }
        public List<InterestingPlace> Filter(string[] types, string[] prices, string[] ratings)
        {
            throw new NotImplementedException();
        }

        public PlacesViewModel GetPlaceVM()
        {
            PlacesViewModel model = new PlacesViewModel();
            model.placesCultural= placeRepo.GetAllWithCategory().Where(p => p.Type.Type == "Cultural").ToList();
            model.placesReligious=placeRepo.GetAllWithCategory().Where(p => p.Type.Type == "Religious").ToList();
            model.placesLeisure=placeRepo.GetAllWithCategory().Where(p => p.Type.Type == "Leisure").ToList();
            model.placesMedical=placeRepo.GetAllWithCategory().Where(p => p.Type.Type == "Medical").ToList();

            model.placesList.Add(model.placesCultural);
            model.placesList.Add(model.placesReligious);
            model.placesList.Add(model.placesLeisure);
            model.placesList.Add(model.placesMedical);
            return model;
        }

       

      

       
    }
}

using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.ViewModel;

namespace EgyptTouristWebSite.Services.Interfaces
{
    public interface IInterPlaceService
    {
      
        PlacesViewModel GetPlaceVM();
        List<InterestingPlace> Filter(string[] types, string[] prices, string[] ratings);
    }
}

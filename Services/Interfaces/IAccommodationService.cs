using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.ViewModel;

namespace EgyptTouristWebSite.Services.Interfaces
{
    public interface IAccommodationService
    {
        List<Accommodation> GetHotels();
        List<Accommodation> GetResorts();
        List<Accommodation> GetMotels();
        AccommodationsViewModel GetAccommodationVM();
        List<Accommodation> Filter(string[] types, string[] prices, string[] ratings);
      
    }
}

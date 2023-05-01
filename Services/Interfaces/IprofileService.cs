using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.ViewModel;

namespace EgyptTouristWebSite.Services.Interfaces
{
    public interface IprofileService
    {
        ProfileVM CreateProfileVM(AppUser userModel);
        AppUser GetUser(string name);
        Task<bool> AddServices(Service service, string name);
        Task<bool> AddPlace(InterestingPlace place, string name);
        Task<bool> AddTravelAgency(TravelAgency travelAgency, string name);
        Task<bool> RemoveAcc(int accId, string userName);
        Task<bool> RemoveSevice(int serviceId, string userName);

    }
}

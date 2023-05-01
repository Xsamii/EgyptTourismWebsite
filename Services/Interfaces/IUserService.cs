using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace EgyptTouristWebSite.Services.Interfaces
{
    public interface IUserService
    {
        AppUser ConvertRegisterVMtoAppUser(RegisterVM newUserData);
         Task signout();
         Task<bool> chechSigninData(SigninVM userData);
         Task SignIn(AppUser user);
         Task<IdentityResult> CreateNewUSer(AppUser newUser, string password);
        Task<AppUser> GetByName(string name);
        Task<bool> UpdateUser(ProfileVM newUserdata);
        Task<bool> AddAccommodation(Accommodation acc, string name);
   /*     Task<bool> AddServices(Service service, string name);
        Task<bool> AddPlace(InterestingPlace place, string name);
        Task<bool> AddTravelAgency(TravelAgency travelAgency, string name);*/



    }
}

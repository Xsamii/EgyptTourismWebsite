using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Services
{
    public class ProfileService : IprofileService
    {
        private readonly DataBaseContext context;
        private readonly UserManager<AppUser> userManager;

        public ProfileService(DataBaseContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public ProfileVM CreateProfileVM(AppUser userModel)
        {

            ProfileVM profileModel = new ProfileVM();
            profileModel.Nationality = userModel.Nationality;
            profileModel.Services = userModel.Services;
            profileModel.Name = userModel.UserName;
            profileModel.Accommodation = userModel.Accommodation;
            profileModel.Age = userModel.age;
            profileModel.TravelAgency = userModel.TravelAgency;
            profileModel.InterestingPlaces = userModel.InterestingPlaces;
            profileModel.Id = userModel.Id;
            return profileModel;
        }
        public AppUser GetUser(string name)
        {
            AppUser user = context.Users.Include(u => u.Accommodation).Include(u => u.Services).
                Include(u => u.InterestingPlaces).FirstOrDefault(u => u.NormalizedUserName == name.ToUpper());
            return user;
        }

        public async Task<bool> AddServices(Service service, string name)
        {
            AppUser user =  GetUser(name);
            if (user == null) return false;
            user.Services.Add(service);
            await userManager.UpdateAsync(user);
            return true;
        }

        public async Task<bool> AddPlace(InterestingPlace place, string name)
        {
            AppUser user =  GetUser(name);
            if (user == null) return false;
            user.InterestingPlaces.Add(place);
            await userManager.UpdateAsync(user);
            return true;
        }

        public async Task<bool> AddTravelAgency(TravelAgency travelAgency, string name)
        {
            AppUser user =  GetUser(name);
            if (user == null) return false;
            user.TravelAgencyId = travelAgency.Id;
            await userManager.UpdateAsync(user);
            return true;
        }

        public async Task<bool> RemoveAcc(int accId, string userName)
        {
            AppUser user =await userManager.FindByNameAsync(userName);
            user.AccId = 0;
            await userManager.UpdateAsync(user);
            return true;

        }

        public async Task<bool> RemoveSevice(int serviceId, string userName)
        {
            AppUser user = GetUser(userName);
            Service service = user.Services.FirstOrDefault(s => s.Id == serviceId);
            if(user == null) return false;
            user.Services.Remove(service);
             await userManager.UpdateAsync(user);
            return true;
        }
    }
}

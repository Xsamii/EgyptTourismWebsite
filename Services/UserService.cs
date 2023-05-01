using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EgyptTouristWebSite.Services
{
	public class UserService:IUserService
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;

		public UserService(UserManager<AppUser> _userManager,SignInManager<AppUser> _signinMager)
        {
			userManager = _userManager;
			signInManager = _signinMager;
		}


		public AppUser ConvertRegisterVMtoAppUser (RegisterVM newUserData) {
			AppUser newUser = new AppUser();
			newUser.UserName = newUserData.UserName;
			newUser.PhoneNumber = newUserData.PhoneNumber;
			newUser.Nationality = newUserData.Nationality;
			newUser.Email = newUserData.Email;
			newUser.age = newUserData.Age;
			return newUser;
		}
		public async Task<IdentityResult> CreateNewUSer(AppUser newUser,string password)
		{
			var result =  await userManager.CreateAsync(newUser,password);
			return result;
		}
		public async Task SignIn(AppUser user)
		{
			  await signInManager.SignInAsync(user, false);
		}
		public async Task<bool> chechSigninData(SigninVM userData)
		{
			AppUser user = await userManager.FindByNameAsync(userData.UserName);
			if (user == null)
			{
				return false;
			}
			bool passwordCorrect = await userManager.CheckPasswordAsync(user, userData.Password);
			if (!passwordCorrect)
			{
				return false;
			}
            await signInManager.SignInAsync(user, userData.RememberMe);
            return true;
        }
		public async Task signout()
		{
			await signInManager.SignOutAsync();
		}
       public async Task<AppUser> GetByName(string name)
		{
			AppUser user = await userManager.FindByNameAsync(name);
		
			return user;
		}

        public async Task<bool> UpdateUser(ProfileVM newUserdata)
        {
			AppUser user = await userManager.FindByIdAsync(newUserdata.Id);
			if (user == null) { return false; }
			user.UserName = newUserdata.Name;
			user.age = newUserdata.Age;
			user.Nationality = newUserdata.Nationality;
			var result = await userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return true;
			}
			else
			{
				return false;
			}
        }

		public async Task<bool> AddAccommodation(Accommodation acc, string name)
		{
			AppUser user = await GetByName(name);
			if (user == null) return false;
			user.Accommodation = acc;
			await userManager.UpdateAsync(user);
			return true;
		}

		
    }
}

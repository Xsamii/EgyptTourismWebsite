using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Security.Claims;

namespace EgyptTouristWebSite.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService userService;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IprofileService _profileService;

		public AccountController(IUserService _userService, SignInManager<AppUser> signinManager,IprofileService profileService)
		{
			userService = _userService;
			_signInManager = signinManager;
			_profileService = profileService;
		}
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterVM newUSerData)
		{
			if (ModelState.IsValid)
			{
				AppUser newUser = userService.ConvertRegisterVMtoAppUser(newUSerData);

				IdentityResult result = await userService.CreateNewUSer(newUser, newUSerData.Password);
				if (result.Succeeded)
				{
					await userService.SignIn(newUser);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(newUSerData);
		}
		public async Task<IActionResult> Login()
		{

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(SigninVM user)
		{
			if (ModelState.IsValid)
			{
				if (await userService.chechSigninData(user))
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "username or password is not correct");
				}

			}

			return View(user);
		}

		public async Task<IActionResult> Signout()
		{
			await userService.signout();
			return RedirectToAction("Index", "Home");
		}
		[Authorize]
        [Route("Account/Profile/{name?}")]
        public  IActionResult Profile(string name)
		{
			if (name is null) return BadRequest();
			AppUser user =  _profileService.GetUser(name);
			ProfileVM model= _profileService.CreateProfileVM(user);
			return View(model);
		}
		[Authorize]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateUser (ProfileVM newUserData)
		{
			var res = await userService.UpdateUser(newUserData);
			if (res)
			{
				return Redirect($"Profile/{newUserData.Name}");
			}
			else { return BadRequest(); }
			
        }
		[Authorize]
		public	async Task<IActionResult> RemoveAcc(int id) {
			bool res = await _profileService.RemoveAcc(id, User.Identity.Name);
			if (res)
			{
				return RedirectToAction("Profile", "Account", new { User.Identity.Name });
			}
			else { return BadRequest(); }
		}
        [Authorize]
        public async Task<IActionResult> RemoveService(int id)
        {
            bool res = await _profileService.RemoveAcc(id, User.Identity.Name);
            if (res)
            {
                return RedirectToAction("Profile", "Account", new { User.Identity.Name });
            }
            else { return BadRequest(); }
        }

    }
}

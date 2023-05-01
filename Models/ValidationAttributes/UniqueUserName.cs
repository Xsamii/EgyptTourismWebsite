using EgyptTouristWebSite.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EgyptTouristWebSite.Models.ValidationAttributes
{
	public class UniqueUserNameAttribute : ValidationAttribute
	{
		//UserManager<AppUser> userManager;
		DataBaseContext dataBaseContext;
		public UniqueUserNameAttribute(DataBaseContext _context)
		{
			dataBaseContext = _context;
		}
		/*public UniqueUserNameAttribute(UserManager<AppUser> _userManager)
		{
			userManager = _userManager;
			//dataBaseContext = _databasContext;
		}*/

		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{

			string UserName = value.ToString();
			//AppUser user = await userManager.FindByNameAsync(UserName);
			AppUser user = dataBaseContext.Users.FirstOrDefault(x=> x.UserName == UserName);
			if (user == null)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("User Name Already Found!!");
		}
      
    }
}

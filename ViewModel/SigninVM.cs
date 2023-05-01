using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EgyptTouristWebSite.ViewModel
{
	public class SigninVM
	{
		
        public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public	bool RememberMe { get; set; }
   
    }
}

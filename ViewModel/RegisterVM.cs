using EgyptTouristWebSite.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace EgyptTouristWebSite.ViewModel
{
	public class RegisterVM 
	{
        [MinLength(5)]
        [MaxLength(20)]
       // [UniqueUserName]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailExpression]
        public string Email { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }


    }
}

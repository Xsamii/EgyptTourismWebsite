using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
	public class AppUser:IdentityUser
	{
		public int age { get; set; }
		public string Nationality { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		[ForeignKey("Accommodation")]
		public int? AccId { get; set; }

		public Accommodation? Accommodation { get; set; }
		[ForeignKey("TravelAgency")]
		public int? TravelAgencyId { get; set; }
		public TravelAgency? TravelAgency { get; set; }

		public List<Service>? Services { get; set; }
		public List<InterestingPlace>? InterestingPlaces { get; set; }
	}
}

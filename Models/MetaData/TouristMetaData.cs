using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EgyptTouristWebSite.Models.MetaData
{
	public class TouristMetaData
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[Range(18, 100)]
		public int age { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(100)]
		public string Nationality { get; set; }
		[Required]
		public double X { get; set; }
		[Required]
		public double Y { get; set; }
		[AllowNull]
		public int? AccId { get; set; }
		[AllowNull]
		public Accommodation? Accommodation { get; set; }
		[AllowNull]
		public int? TravelAgencyId { get; set; }
		[AllowNull]
		public TravelAgency? TravelAgency { get; set; }
		[AllowNull]

		public List<Service>? Services { get; set; }
		[AllowNull]

		public List<InterestingPlace>? InterestingPlaces { get; set; }

	}
}

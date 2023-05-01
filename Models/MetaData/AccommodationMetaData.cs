using EgyptTouristWebSite.Models.SubTypes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EgyptTouristWebSite.Models.MetaData
{
	public class AccommodationMetaData
	{
		
		[Required]
		public int Id { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(200)]
		public string Description { get; set; }
		[Required]

		public Acctype Type { get; set; }
		[Required]
		[Range(0, 100000)]
		public double Price { get; set; }
		[AllowNull]
		public List<AppUser>? Tourists { get; set; }
		[Required]
        public double X { get; set; }
		[Required]
        public double Y { get; set; }

	}
}

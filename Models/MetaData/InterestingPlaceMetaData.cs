using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EgyptTouristWebSite.Models.MetaData
{
    public class InterestingPlaceMetaData
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
	/*	[Column(TypeName = "time")]
        [AllowNull]
		public TimeSpan? ClosingTIme { get; set; }
		[Column(TypeName = "time")]
        [AllowNull]
		public TimeSpan? openingTIme { get; set; }*/
		public string Desciption { get; set; }
        [Required]
        public double x { get; set; }
        public double y { get; set; }

        [Range(0,5)]
        public int Rate { get; set; }
        [AllowNull]

		public List<AppUser>? Tourists { get; set; }
	}
}

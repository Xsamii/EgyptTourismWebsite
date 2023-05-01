using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EgyptTouristWebSite.Models.MetaData
{
    public class TravelAgencyMetaData
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public double x { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        [AllowNull]
		public List<TourGuide>? TourGuide { get; set; }
	}
}

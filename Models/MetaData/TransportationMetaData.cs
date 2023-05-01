using System.ComponentModel.DataAnnotations;

namespace EgyptTouristWebSite.Models.MetaData
{
    public class TransportationMetaData
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string NameOfcompany { get; set; }
        [Required]
        public string ContactInfo { get; set; }
        public string Desciption { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        public string RideType { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double x { get; set; }
        public double y { get; set; }
        [Range(0,5)]
        public int Rate { get; set; }
    }
}

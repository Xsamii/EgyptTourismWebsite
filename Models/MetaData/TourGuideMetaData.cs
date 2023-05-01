using System.ComponentModel.DataAnnotations;

namespace EgyptTouristWebSite.Models.MetaData
{

    public class TourGuideMetaData
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public string Phone { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
    }
}

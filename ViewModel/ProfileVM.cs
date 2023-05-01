using EgyptTouristWebSite.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.ViewModel
{
    public class ProfileVM
    {
        public string Id { get; set; }
        public string Name { get;set; }
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public Accommodation? Accommodation { get; set; }
        public TravelAgency? TravelAgency { get; set; }

        public List<Service>? Services { get; set; }
        public List<InterestingPlace>? InterestingPlaces { get; set; }

    }
}

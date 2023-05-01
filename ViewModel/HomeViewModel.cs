using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.ViewModel
{
    public class HomeViewModel
    {
        public List<Service> services { get; set; }
        public List<Accommodation> accommodations { get; set; }
        public List<InterestingPlace> places { get; set; }
    }
}

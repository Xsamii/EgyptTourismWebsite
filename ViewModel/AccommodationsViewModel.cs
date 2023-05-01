using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.ViewModel
{
	public class AccommodationsViewModel
	{

        public List<Accommodation> accHotels { get; set; }
        public  List<Accommodation> accResorts { get; set; }
        public List<Accommodation> accMotels { get; set; }
        public List<List<Accommodation>> accsList { get; set; } =new List<List<Accommodation>>();
     
    }
}

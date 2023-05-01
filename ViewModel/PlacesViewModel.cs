using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EgyptTouristWebSite.ViewModel
{
    public class PlacesViewModel
    {
        
        // Types are Cultural, Leisure, Religious and Medical
        public  List<InterestingPlace> placesCultural { get; set; }
        public  List<InterestingPlace> placesLeisure { get; set; }
        public  List<InterestingPlace> placesReligious { get; set; }
        public  List<InterestingPlace> placesMedical { get; set; }
        public List<List<InterestingPlace>> placesList { get; set; }=new List<List<InterestingPlace>>();
      
    }
}

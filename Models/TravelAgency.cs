using EgyptTouristWebSite.Models.MetaData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
	[ModelMetadataType(typeof(TravelAgencyMetaData))]
	public class TravelAgency
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Rate { get; set; } = 0;
        public string Image { get; set; }

        public List<TourGuide>? TourGuide { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using EgyptTouristWebSite.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EgyptTouristWebSite.Models
{
    [ModelMetadataType(typeof(TourGuideMetaData))]
    public class TourGuide
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Languages { get; set; }

        public string Phone { get; set; }
        public int Rate { get; set; } = 0;

        [ForeignKey("TravelAgency")]

        public int TravelAgencyId { get; set; }
        public TravelAgency TravelAgency { get; set; }




    }
}

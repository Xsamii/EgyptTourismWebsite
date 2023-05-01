using EgyptTouristWebSite.Models.MetaData;
using Microsoft.AspNetCore.Mvc;
using EgyptTouristWebSite.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EgyptTouristWebSite.Models.SubTypes;

namespace EgyptTouristWebSite.Models
{
    [ModelMetadataType(typeof(TransportationMetaData))]
    public class Transportation
    {
        public int Id { get; set; }
        public string NameOfcompany { get; set; }
        public string ContactInfo { get; set; }
        public string Desciption { get; set; }
        public string Payment { get; set; }
        [ForeignKey(nameof(TransportationType))]
        public int TypeId { get; set; }
        public TransportationType RideType { get; set; }
        public double Price { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int Rate { get; set; } = 0;


    }
}

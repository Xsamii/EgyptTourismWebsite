using EgyptTouristWebSite.Models.MetaData;
using EgyptTouristWebSite.Models.SubTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
    [ModelMetadataType(typeof(InterestingPlaceMetaData))]

    public class InterestingPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /*    [Column(TypeName = "time")]
            public TimeSpan? ClosingTIme { get; set; }
            [Column(TypeName = "time")]
            public TimeSpan? openingTIme { get; set; }*/
        [ForeignKey("InterestingPlaceType")]
        public int TypeId { get; set; }
        public InterestingPlaceType Type { get; set; }        
        public string Description { get; set; }
        public string Website { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int Rate { get; set; } = 0;
        // many to many m3 tourist
        public List<AppUser>? Tourist { get; set; }
        public string Image { get; set; }

    }
}

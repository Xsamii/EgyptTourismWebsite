using EgyptTouristWebSite.Models.SubTypes;
using EgyptTouristWebSite.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.ViewModel
{
    public class ToAddNewInterstingPlaceViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        /*    [Column(TypeName = "time")]
            public TimeSpan? ClosingTIme { get; set; }
            [Column(TypeName = "time")]
            public TimeSpan? openingTIme { get; set; }*/
        public string Type { get; set; }
        public string Desciption { get; set; }
        public string Website { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public int Rate { get; set; } = 0;
        public int typeID { get; set; }
        public List<AppUser>? Tourists { get; set; }

    }
}

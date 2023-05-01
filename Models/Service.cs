using EgyptTouristWebSite.Models.MetaData;
using EgyptTouristWebSite.Models.SubTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
	[ModelMetadataType(typeof(ServiceMetaData))]
	public class Service
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public int Rate { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		[ForeignKey(nameof(ServiceType))]
        public int TypeId { get; set; }
        public ServiceType Type { get; set; }
		public List<AppUser>? Tourists { get; set;}
		public string Image { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;

    }
}

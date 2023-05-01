using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EgyptTouristWebSite.ViewModel
{
    public class ServicesViewModel
    {


         public List<Service> banks { get; set; }
        public List<Service> embassies { get; set; }
        public List<Service> malls { get; set; }
        public List<Service> restaurants { get; set; }
        public List<List<Service>> services { get; set; } = new List<List<Service>>();
       
    }
}

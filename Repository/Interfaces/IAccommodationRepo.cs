using EgyptTouristWebSite.Models;

namespace EgyptTouristWebSite.Repository.Interfaces
{
    public interface IAccommodationRepo:IRepo<Accommodation>
    {
        List<Accommodation> GetAllWithType();
        public List<Accommodation> GetByName(string name);
        public List<Accommodation> GetByCat(string category);
        


    }
}

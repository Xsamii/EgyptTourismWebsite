using EgyptTouristWebSite.Models;

namespace EgyptTouristWebSite.Repository.Interfaces
{
    public interface IPlaceRepo:IRepo<InterestingPlace>
    {
        List<InterestingPlace> GetAllWithCategory();
        public List<InterestingPlace> GetByName(string name);
        public List<InterestingPlace> GetByCat(string category);
    }
}

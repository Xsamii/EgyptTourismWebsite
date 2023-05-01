using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Repository
{
    public class InterestingPlaceRepo:IPlaceRepo
    {
           private readonly DataBaseContext context;
            public InterestingPlaceRepo(DataBaseContext dbContext)
            {
                context = dbContext;
            }

            public void Add(InterestingPlace place)
            {
                context.InterestingPlaces.Add(place);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                InterestingPlace acc = GetById(id);
                context.InterestingPlaces.Remove(acc);
                context.SaveChanges();
            }

            public List<InterestingPlace> GetAll()
            {
                return context.InterestingPlaces.ToList();

            }

            public List<InterestingPlace> GetAllWithCategory()
            {
                return context.InterestingPlaces.Include(a => a.Type).ToList();
            }

            public InterestingPlace GetById(int id)
            {
                var acc = context.InterestingPlaces.Include(a => a.Type).FirstOrDefault(p => p.Id == id);
                return acc;
            }
            public List<InterestingPlace> GetByName(string name)
            {
                var place = context.InterestingPlaces.Include(a => a.Type).Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
                return place;
            }
            public List<InterestingPlace> GetByCat(string category)
            {
                var placeList = context.InterestingPlaces.Include(a => a.Type).Where(a => a.Type.Type == category).ToList();

                return placeList;
            }

    }
}

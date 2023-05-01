using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EgyptTouristWebSite.Services
{
	public class AccommodationService:IAccommodationService
	{
        private readonly IAccommodationRepo accRepo;

        public AccommodationService(IAccommodationRepo _accRepo)
        {
            accRepo = _accRepo;
        }

        public AccommodationsViewModel GetAccommodationVM()
        {
            AccommodationsViewModel accVM = new AccommodationsViewModel();
            accVM.accHotels = GetHotels();
            accVM.accMotels = GetMotels();
            accVM.accResorts = GetResorts();
            accVM.accsList.Add(accVM.accHotels);
            accVM.accsList.Add(accVM.accMotels);
            accVM.accsList.Add(accVM.accResorts);
            return accVM;
        }

        public List<Accommodation> GetAll()
        {
            return accRepo.GetAllWithType();
        }

        public List<Accommodation> GetHotels()
        {
            return accRepo.GetAllWithType().Where(a =>a.TypeId==1).ToList();
        }

        public List<Accommodation> GetMotels()
        {
          return  accRepo.GetAllWithType().Where(a => a.TypeId==3).ToList();
        }

        public List<Accommodation> GetResorts()
        {
            return accRepo.GetAllWithType().Where(a => a.TypeId==2).ToList();
        }
        public List<Accommodation> Filter(string[] types, string[] prices, string[] ratings)
        {
            var list = accRepo.GetAllWithType().AsEnumerable();

            if (types.Length != 0)
            {
                list = list.Where(a => types.Contains(a.Type.Type));
            }
            if (ratings.Length != 0)
            {
                list = list.Where(a => ratings.Contains(a.Rate.ToString()));
            }
            if (prices.Length != 0)
            {
                list = list.Where(a =>
                {
                    foreach (var priceRange in prices)
                    {
                        var pricesValues = priceRange.Split('-');
                        int minPrice = int.Parse(pricesValues[0]);
                        int maxPrice = pricesValues.Length == 2 ? int.Parse(pricesValues[1]) : int.MaxValue;
                        if (a.Price >= minPrice && a.Price <= maxPrice)
                        {
                            return true;
                        }
                    }
                    return false;

                });
            }
            return list.ToList();
        }
       
    }
}

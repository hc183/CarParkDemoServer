using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Domain.Interfaces;
using AbcCorp.CarPark.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AbcCorp.CarPark.Domain.Repositories
{
    public class ParkingRateRepository : IParkingRateRepository
    {
        private static CarParkDbContext _carParkDbContext;
        private static void SetDbContext()
        {
            var options = new DbContextOptionsBuilder<CarParkDbContext>()
                      .UseInMemoryDatabase("CarParkDb")
                      .Options;
            _carParkDbContext = new CarParkDbContext(options);
            
        }
        public ParkingRateRepository()
        {
            SetDbContext();
        }
        public ParkingRate GetParkingRate(RateType rateType)
        {
            var parkingRate = _carParkDbContext.ParkingRates.FirstOrDefault(pr => pr.RateCode == rateType.ToString());
            return parkingRate;
        }
    }
}

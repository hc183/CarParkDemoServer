using AbcCorp.CarPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbcCorp.CarPark.Infrastructure.Data
{
    public class CarParkDbContext:DbContext
    {

        public CarParkDbContext()
        {

        }
        public CarParkDbContext(DbContextOptions<CarParkDbContext> options)
            : base(options)
        {
            AddTestData();
        }

        public DbSet<ParkingRate> ParkingRates { get; set; }

        
        public void AddTestData()
        {
            ParkingRates.Add(new ParkingRate() { RateCode = "Standard1", RateDisplayName = "Standard Rate - Upto an hour", Rate = 5 });
            ParkingRates.Add(new ParkingRate() { RateCode = "Standard2", RateDisplayName = "Standard Rate - Upto two hours", Rate = 10 });
            ParkingRates.Add(new ParkingRate() { RateCode = "Standard3", RateDisplayName = "Standard Rate - Upto three hours", Rate = 15 });
            ParkingRates.Add(new ParkingRate() { RateCode = "StandardFlatPerDay", RateDisplayName = "Standard per day flat rate", Rate = 20 });
            ParkingRates.Add(new ParkingRate() { RateCode = "EarlyBird", RateDisplayName = "Early Bird Rate", Rate = 13 });
            ParkingRates.Add(new ParkingRate() { RateCode = "Night", RateDisplayName = "Night Rate", Rate = 6.5 });
            ParkingRates.Add(new ParkingRate() { RateCode = "Weekend", RateDisplayName = "Weekend Rate", Rate = 10 });

            SaveChanges();
        }

        
    }
}

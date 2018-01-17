using AbcCorp.CarPark.Domain.Entities;

namespace AbcCorp.CarPark.Domain.Interfaces
{
    public interface IParkingRateRepository
    {
        ParkingRate GetParkingRate(RateType rateType);
    }
}

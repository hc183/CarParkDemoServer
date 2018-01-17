using AbcCorp.CarPark.Common;
using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Domain.Interfaces;
using AbcCorp.CarPark.Domain.Repositories;
using AbcCorp.CarPark.Dto;
using System;

namespace AbcCorp.CarPark.Services
{
    public class StandardRateCalculator : RateCalculator
    {
        private readonly IParkingRateRepository _parkingRateRepository;

        public StandardRateCalculator(DateTime entryDateTime, DateTime exitDateTime) : base(entryDateTime, exitDateTime)
        {
            _parkingRateRepository = new ParkingRateRepository();
        }

        public double TotalParkedHours { get => (ExitDateTime - EntryDateTime).TotalHours; }
        public double TotalParkedDays { get => (ExitDateTime - EntryDateTime).TotalDays + 1; }


        public override ParkingRate GetRateInfo()
        {
            ParkingRate parkingRate = null;
            if (!IsWeekDay)
                return parkingRate;
            if (TotalParkedHours <= 1)
                return GetParkingRate(RateType.Standard1);
            else if (TotalParkedHours <= 2)
                return GetParkingRate(RateType.Standard2);
            else if (TotalParkedHours <= 3)
                return GetParkingRate(RateType.Standard3);
            else
                return GetParkingRate(RateType.StandardFlatPerDay);




        }
        private ParkingRate GetParkingRate(RateType rateType)
        {
            return _parkingRateRepository.GetParkingRate(rateType);
        }


    }
}

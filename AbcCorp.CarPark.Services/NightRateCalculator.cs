using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Domain.Interfaces;
using AbcCorp.CarPark.Domain.Repositories;
using System;

namespace AbcCorp.CarPark.Services
{
    public class NightRateCalculator:DiscountRateCalculator
    {
        private readonly IParkingRateRepository _parkingRateRepository;

        public NightRateCalculator(DateTime entryDateTime, DateTime exitDateTime)
                : base(entryDateTime, exitDateTime)
        {
            _parkingRateRepository = new ParkingRateRepository();
            SetEntryExitConditions();
        }

        public override ParkingRate GetRateInfo()
        {
            if (IsWeekDay && IsEntryExitConditionSatisfied())
                return _parkingRateRepository.GetParkingRate(RateType.Night);
            else
                return null;
        }

        private bool IsEntryExitConditionSatisfied()
        {
            return EntryDateTime >= validEntryStartTime && EntryDateTime <= validEntryEndTime
                    && ExitDateTime <= validExitEndTime;
        }

        protected override void SetEntryExitConditions()
        {
            var entryYear = EntryDateTime.Year;
            var entryMonth = EntryDateTime.Month;
            var entryDay = EntryDateTime.Day;
            validEntryStartTime = new DateTime(entryYear, entryMonth, entryDay, 18, 0, 0); //6 pm
            validEntryEndTime = new DateTime(entryYear, entryMonth, entryDay, 23, 59, 0); //11:59 pm
            var nextDay = EntryDateTime.AddDays(1);
            validExitEndTime = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 6, 0, 0); //6:00 am nextday
        }
    }
}

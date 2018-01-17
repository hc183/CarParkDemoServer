using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Domain.Interfaces;
using AbcCorp.CarPark.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcCorp.CarPark.Services
{
    class WeekendRateCalculator : DiscountRateCalculator
    {
        private readonly IParkingRateRepository _parkingRateRepository;

        public WeekendRateCalculator(DateTime entryDateTime, DateTime exitDateTime)
                : base(entryDateTime, exitDateTime)
        {
            _parkingRateRepository = new ParkingRateRepository();
            SetEntryExitConditions();
        }

        public override ParkingRate GetRateInfo()
        {
            if (!IsWeekDay && IsEntryExitConditionSatisfied())
                return _parkingRateRepository.GetParkingRate(RateType.Weekend);
            else
                return null;
        }

        private bool IsEntryExitConditionSatisfied()
        {
            return EntryDateTime >= validEntryStartTime && ExitDateTime <= validExitEndTime;
        }

        protected override void SetEntryExitConditions()
        {
            var validExitDate = EntryDayOfWeek == DayOfWeek.Saturday ? EntryDateTime.AddDays(1) : EntryDateTime;
            var entryYear = EntryDateTime.Year;
            var entryMonth = EntryDateTime.Month;
            var entryDay = EntryDateTime.Day;

            validEntryStartTime = new DateTime(entryYear, entryMonth, entryDay, 0, 0, 0); //midnight
            validExitEndTime = new DateTime(validExitDate.Year, validExitDate.Month, validExitDate.Day, 23, 59, 0); //midnight nextday
        }
    }
}

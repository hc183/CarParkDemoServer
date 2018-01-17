using System;
using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Domain.Interfaces;
using AbcCorp.CarPark.Domain.Repositories;

namespace AbcCorp.CarPark.Services
{
    public class EarlyBirdRateCalculator : DiscountRateCalculator
    {
        private readonly IParkingRateRepository _parkingRateRepository;

        public EarlyBirdRateCalculator(DateTime entryDateTime, DateTime exitDateTime)
                : base(entryDateTime, exitDateTime)
        {
            _parkingRateRepository = new ParkingRateRepository();
            SetEntryExitConditions();
        }
        public override ParkingRate GetRateInfo()
        {
            if (IsWeekDay && IsEntryExitConditionSatisfied())
                return _parkingRateRepository.GetParkingRate(RateType.EarlyBird);
            else
                return null;
        }
        private bool IsEntryExitConditionSatisfied()
        {
            return EntryDateTime >= validEntryStartTime && EntryDateTime <= validEntryEndTime
                    && ExitDateTime >= validExitStartTime && ExitDateTime <= validExitEndTime;
        }

        protected override void SetEntryExitConditions()
        {
            var entryYear = EntryDateTime.Year;
            var entryMonth = EntryDateTime.Month;
            var entryDay = EntryDateTime.Day;
            validEntryStartTime = new DateTime(entryYear, entryMonth, entryDay, 6, 0, 0); //6 am
            validEntryEndTime = new DateTime(entryYear, entryMonth, entryDay, 9, 0, 0); //9 am
            validExitStartTime = new DateTime(entryYear, entryMonth, entryDay, 15, 30, 0); //3:30 pm
            validExitEndTime = new DateTime(entryYear, entryMonth, entryDay, 23, 30, 0); //11:30 pm
        }
    }
}

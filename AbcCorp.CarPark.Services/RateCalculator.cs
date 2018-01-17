using AbcCorp.CarPark.Domain.Entities;
using System;

namespace AbcCorp.CarPark.Services
{
    public abstract class RateCalculator
    {
        public RateCalculator(DateTime entryDateTime,DateTime exitDateTime)
        {
            EntryDateTime = entryDateTime;
            ExitDateTime = exitDateTime;
        }

        protected DateTime EntryDateTime { get; }
        protected DateTime ExitDateTime { get; }
        protected DayOfWeek EntryDayOfWeek { get=>EntryDateTime.DayOfWeek; }
        protected bool IsWeekDay { get => EntryDayOfWeek != DayOfWeek.Saturday && EntryDayOfWeek != DayOfWeek.Sunday; }

        public abstract ParkingRate GetRateInfo();
    }
}

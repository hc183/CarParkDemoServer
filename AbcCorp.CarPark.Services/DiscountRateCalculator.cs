using System;
using System.Collections.Generic;
using System.Text;
using AbcCorp.CarPark.Domain.Entities;

namespace AbcCorp.CarPark.Services
{
    public abstract class DiscountRateCalculator : RateCalculator
    {
        protected DateTime validEntryStartTime, validEntryEndTime, validExitStartTime, validExitEndTime;
        public DiscountRateCalculator(DateTime entryDateTime, DateTime exitDateTime) : base(entryDateTime, exitDateTime)
        {
        }
        protected abstract void SetEntryExitConditions();
    }
}

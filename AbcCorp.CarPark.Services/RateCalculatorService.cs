using AbcCorp.CarPark.Domain.Entities;
using AbcCorp.CarPark.Dto;
using System;

namespace AbcCorp.CarPark.Services
{
    public class RateCalculatorService
    {
        protected DateTime EntryDateTime { get; }
        protected DateTime ExitDateTime { get; }
        protected bool IsWeekDay { get => (EntryDateTime.DayOfWeek != DayOfWeek.Saturday && EntryDateTime.DayOfWeek != DayOfWeek.Sunday); }

        public RateCalculatorService(DateTime entryDateTime, DateTime exitDateTime)
        {
            EntryDateTime = entryDateTime;
            ExitDateTime = exitDateTime;
        }

        public ParkingRateInfoDto GetParkingRateInfo()
        {
            var parkingRateInfoDto = new ParkingRateInfoDto();
            RateCalculator rateCalculator;
            ParkingRate parkingRate;
            if (IsWeekDay)
            {
                rateCalculator = new EarlyBirdRateCalculator(EntryDateTime, ExitDateTime);
                parkingRate = rateCalculator.GetRateInfo();
                if (parkingRate == null)
                {
                    rateCalculator = new NightRateCalculator(EntryDateTime, ExitDateTime);
                    parkingRate = rateCalculator.GetRateInfo();
                }
                if (parkingRate == null)
                {
                    rateCalculator = new StandardRateCalculator(EntryDateTime, ExitDateTime);
                    parkingRate = rateCalculator.GetRateInfo();
                }
            }
            else
            {
                rateCalculator = new WeekendRateCalculator(EntryDateTime, ExitDateTime);
                parkingRate = rateCalculator.GetRateInfo();
            }
            if (parkingRate == null)
                return parkingRateInfoDto;
            else
                return ConvertParkingRateInfoToDto(parkingRate);
        }

        private ParkingRateInfoDto ConvertParkingRateInfoToDto(ParkingRate parkingRate)
        {
            var parkingRateInfoDto = new ParkingRateInfoDto
            {
                RateTypeDisplayName = parkingRate.RateDisplayName,
                Rate = parkingRate.Rate
            };
            if (string.Equals(parkingRate.RateCode, RateType.StandardFlatPerDay.ToString(),
                StringComparison.CurrentCultureIgnoreCase))
            {
                int totalParkedDays = 1;
                if(ExitDateTime.Date.Equals(EntryDateTime.Date))
                {
                    totalParkedDays = 1;
                }
                else
                {
                    totalParkedDays = Convert.ToInt32(Math.Ceiling((ExitDateTime - EntryDateTime).TotalDays));
                }
                
                parkingRateInfoDto.Rate = parkingRate.Rate * totalParkedDays;
            }
            return parkingRateInfoDto;
        }
    }
}

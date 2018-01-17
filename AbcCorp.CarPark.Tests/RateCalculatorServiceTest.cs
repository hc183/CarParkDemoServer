using System;
using Xunit;
using AbcCorp.CarPark.Services;

namespace AbcCorp.CarPark.Tests
{
    public class RateCalculatorServiceTest
    {

        private RateCalculatorService _rateCalculatorService;
        private double earlyBirdRate = 13;
        private double nightRate = 6.50;
        private double weekendRate = 10;
        private double standardRateLessThanHour = 5;
        private double standardRateLessThanTwoHours = 10;
        private double standardRateLessThanThreeHours = 15;
        private double standardFlatRatePerDay = 20;


        public RateCalculatorServiceTest()
        {
            
        }
        [Fact]
        public void IsValidEarlyBirdRateTest()
        {
            DateTime entryDateTime = new DateTime(2013, 1, 1, 6, 0, 0);
            DateTime exitDateTime = new DateTime(2013, 1, 1, 15, 30, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(earlyBirdRate, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidNightRateTest()
        {
            DateTime entryDateTime = new DateTime(2012, 12, 31, 18, 0, 0);
            DateTime exitDateTime = new DateTime(2013, 1, 1, 6, 00, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(nightRate, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidWeekendRateTest()
        {
            DateTime entryDateTime = new DateTime(2018, 1, 20, 6, 0, 0);
            DateTime exitDateTime = new DateTime(2018, 1, 21, 23, 59, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(weekendRate, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidStandardRateLessThanHourTest()
        {
            DateTime entryDateTime = new DateTime(2018, 1, 22, 6, 0, 0);
            DateTime exitDateTime = new DateTime(2018, 1, 22, 7, 0, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(standardRateLessThanHour, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidStandardRateLessThanTwoHoursTest()
        {
            DateTime entryDateTime = new DateTime(2018, 1, 22, 6, 01, 0);
            DateTime exitDateTime = new DateTime(2018, 1, 22, 8, 01, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(standardRateLessThanTwoHours, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidStandardRateLessThanThreeHoursTest()
        {
            DateTime entryDateTime = new DateTime(2018, 1, 22, 8, 59, 0);
            DateTime exitDateTime = new DateTime(2018, 1, 22, 11, 57, 0);
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(standardRateLessThanThreeHours, parkingRateDto.Rate);
        }

        [Fact]
        public void IsValidStandardRateFlatPerDayTest()
        {
            DateTime entryDateTime = new DateTime(2018, 1, 24, 11, 59, 0);
            DateTime exitDateTime = new DateTime(2018, 1, 25, 23, 30, 0);
            int totalNumberOfDays = Convert.ToInt32(Math.Ceiling((exitDateTime - entryDateTime).TotalDays));
            _rateCalculatorService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateDto = _rateCalculatorService.GetParkingRateInfo();
            Assert.Equal(standardFlatRatePerDay*totalNumberOfDays, parkingRateDto.Rate);
        }
    }
}

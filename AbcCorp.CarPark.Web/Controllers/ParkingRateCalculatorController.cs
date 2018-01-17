using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbcCorp.CarPark.Services;

namespace AbcCorp.CarPark.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ParkingRateCalculator")]
    public class ParkingRateCalculatorController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Connected to Api!");
        }

        // GET api/values
        [HttpGet("CalculateRate")]
        public IActionResult CalculateRate(DateTime entryDateTime,DateTime exitDateTime)
        {
            //TO-DO: don't forget to standarized datetime format make sure date/time doesn't impact calculation
            //To-DO: Make sure exit date is later than entry date
            if (exitDateTime <= entryDateTime)
                return new JsonResult("you can't exit before you enter to parking!");
            var rateService = new RateCalculatorService(entryDateTime, exitDateTime);
            var parkingRateInfoDto = rateService.GetParkingRateInfo();
            return new JsonResult(parkingRateInfoDto);
        }

        private void FindRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            
        }
        private void CheckEntryDate(DateTime entryDateTime,DateTime exitDateTime)
        {
            
        }
    }
}
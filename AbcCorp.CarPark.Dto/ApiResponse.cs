using System;
using System.Net;

namespace AbcCorp.CarPark.Dto
{
    public class ApiResponse
    {
        public ApiResponseStatus StatusCode { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}

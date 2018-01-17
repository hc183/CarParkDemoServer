namespace AbcCorp.CarPark.Domain.Entities
{
    public class ParkingRate
    {
        public int Id { get; set; }
        public string RateCode { get; set; }
        public string RateDisplayName { get; set; }
        public double Rate { get; set; }
    }
}

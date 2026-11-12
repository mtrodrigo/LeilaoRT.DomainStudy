namespace LeilaoRT.DomainStudy.ValueObjects
{
    public class Location
    {
        public int Id { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }

        public Location() { }

        public Location (string stateCode, string cityName)
        {
            StateCode = stateCode;
            CityName = cityName;
        }
    }
}

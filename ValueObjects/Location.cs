namespace LeilaoRT.DomainStudy.ValueObjects
{
    public class Location
    {
        public string StateCode { get; set; }
        public string CityName { get; set; }

        public Location (string stateCode, string cityName)
        {
            StateCode = stateCode;
            CityName = cityName;
        }
    }
}

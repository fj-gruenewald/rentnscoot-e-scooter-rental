using System;

namespace RentNScoot
{
    public class Location
    {
        public string LocationID { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public int Postal { get; set; } = 0;
        public string State { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string StreetNr { get; set; } = String.Empty;

        //Create empty Location Object
        public Location()
        {
        }

        //Create an Location Object but generate the ID
        public Location(string city, int postal, string state, string street, string streetnr)
        {
            LocationID = Guid.NewGuid().ToString();
            City = city;
            Postal = postal;
            State = state;
            Street = street;
            StreetNr = streetnr;
        }

        //Create an Location Object
        public Location(string id, string city, int postal, string state, string street, string streetnr)
        {
            LocationID = id;
            City = city;
            Postal = postal;
            State = state;
            Street = street;
            StreetNr = streetnr;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Domain
{
    public class Location
    {
        public int LocationId { get; set; } = 0;

        public int CityId { get; set; } = 0;

        public string Adress { get; set; } = " ";

        public string AdressNr { get; set; } = " ";


        public Location(int locationId, int cityId, string adress, string adressNr)
        {
            LocationId = locationId;
            CityId = cityId;
            Adress = adress;
            AdressNr = adressNr;
        }

    }
}

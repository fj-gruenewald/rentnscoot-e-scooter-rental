using System;

namespace RentNScoot
{
    public class Rental
    {
        public string RentalID { get; set; } = String.Empty;
        public string CustomerID { get; set; } = String.Empty;
        public string LocationID { get; set; } = String.Empty;
        public int ScooterID { get; set; } = 0;
        public string RentalStart { get; set; } = String.Empty;
        public string RentalEnd { get; set; } = String.Empty;

        //Create an Rental Object
        public Rental(string customerid, string locationid, int scooterid, string start, string end)
        {
            //Rental Id
            Guid rentalguid = System.Guid.NewGuid();

            //Rental Fields
            RentalID = rentalguid.ToString();
            CustomerID = customerid;
            LocationID = locationid;
            ScooterID = scooterid;
            RentalStart = start;
            RentalEnd = end;
        }

        public Rental()
        { }
    }
}
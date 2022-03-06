using System;

namespace RentNScoot
{
    public class Scooter
    {
        public int ScooterID { get; set; } = 0;
        public int Location { get; set; } = 0;
        public int Rentable { get; set; } = 0;
        public string Manufacturer { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;

        //ctor
        public Scooter(int id, int location, int rentable, string manufacturer, string model)
        {
            ScooterID = id;
            Location = location;
            Rentable = rentable;
            Manufacturer = manufacturer;
            Model = model;
        }

        //ctor without attributes
        public Scooter()
        { }
    }
}
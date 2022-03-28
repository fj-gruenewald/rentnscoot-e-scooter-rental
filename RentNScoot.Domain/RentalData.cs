namespace RentNScoot
{
    public class RentalData
    {
        public Rental Rental { get; set; } = null;
        public Customer Customer { get; set; } = null;
        public Scooter Scooter { get; set; } = null;
        public Location Location { get; set; } = null;

        //ctor
        public RentalData(Rental rental, Customer customer, Scooter scooter, Location location)
        {
            Rental = rental;
            Customer = customer;
            Scooter = scooter;
            Location = location;
        }

        //ctor2
        public RentalData()
        { }
    }
}
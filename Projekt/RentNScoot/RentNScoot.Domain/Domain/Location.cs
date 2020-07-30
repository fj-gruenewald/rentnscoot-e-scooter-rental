namespace RentNScoot.Domain
{
    public class Location : IEntity
    {
        //Was für Attribute hat eine Location
        public string Id { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string Plz { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public double AdressNr { get; set; } = 0;

        //Aufruf Konstruktor
        public Location()
        { }

        //Konstruktor zum Lesen
        public Location(string id, string city, string plz, string adress, double adressNr)
        {
            Id = id;
            City = city;
            Plz = plz;
            Adress = adress;
            AdressNr = adressNr;
        }
    }
}
namespace RentNScoot.Domain
{
    public class Scooter : IEntity
    {
        //Was für Attribute hat ein Roller
        public string Id { get; set; } = string.Empty;

        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double Price { get; set; } = 0;

        //Aufruf Konstruktor
        public Scooter()
        { }

        //Konstruktor zum erstellen neuer Einträge
        public Scooter(string make, string model, int price)
        {
            Id = System.Guid.NewGuid().ToString();
            Make = make;
            Model = model;
            Price = price;
        }

        //Konstruktor zum lesen aus Datenbank (ID bekannt)
        public Scooter(string id, string make, string model, double price)
        {
            Id = id;
            Make = make;
            Model = model;
            Price = price;
        }
    }
}
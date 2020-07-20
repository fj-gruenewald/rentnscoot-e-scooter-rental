using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Domain
{
    public class Scooter : IEntity
    {
        //Was für Attribute hat ein Roller
        public string Id { get; private set; }
        public string Make { get; }
        public string Model { get; }
        public int Price { get; }


        //Konstruktor zum erstellen neuer Einträge
        public Scooter(string make, string model, int price)
        {
            Id = System.Guid.NewGuid().ToString();
            Make = make;
            Model = model;
            Price = price;
        }

        //Konstruktor zum lesen aus Datenbank (ID bekannt)
        public Scooter(string id, string make, string model, int price)
        {
            Id = id;
            Make = make;
            Model = model;
            Price = price;
        }
    }
}

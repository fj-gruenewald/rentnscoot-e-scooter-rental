using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Entities
{
    class Scooter : IEntity
    {
        //Was für Attribute hat ein Roller
        public string Id { get; private set; }
        public string Make { get; }
        public string Model { get; }


        //Konstruktor zum erstellen neuer Einträge
        public Scooter(string make, string model)
        {
            Id = System.Guid.NewGuid().ToString();
            Make = make;
            Model = model;
        }

        //Konstruktor zum lesen aus Datenbank (ID bekannt)
        public Scooter(string id, string make, string model)
        {
            Id = id;
            Make = make;
            Model = model;
        }
    }
}

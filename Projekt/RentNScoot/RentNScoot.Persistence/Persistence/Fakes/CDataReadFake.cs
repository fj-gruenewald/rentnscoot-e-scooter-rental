using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//
using RentNScoot.Domain;

namespace RentNScoot.Persistence.Fakes
{
    internal class CDataRead : IDataRead
    {
        //
        internal CDataRead()
        { }

        //
        public void InitDb()
        { }

        //
        public void CloseDb()
        { }

        //
        public int CountScooters()
        {
            int nScooters = 666;
            return nScooters;
        }

        //
        public IEnumerable<string> SelectMakes()
        {
            IEnumerable<string> makes = new string[]
            {
                "Moove",
                "Telefunken",
                "Segway",
                "Denver",
                "SXT",
                "Xiaomi"
            };
            return makes;
        }

        //
        public int CountScooters(string make)
        {
            int nScooters = 66;
            return nScooters;
        }

        //
        public IEnumerable<string> SelectModels(string make)
        {
            IEnumerable<string> models = new string[5]
            {
                "THOR",
                "Synergy S90",
                "Ninebot KickScooter",
                "SXT MAX",
                "SXT 500"
            };
            return models;
        }

        //
        public int CountScooters(ScootersToSearch scootersToSearch)
        {
            int nScooters = 100;
            return nScooters;
        }

        //
        public IEnumerable<Scooter> SelectScooter(ScootersToSearch scootersToSearch)
        {
            IEnumerable<Scooter> scooters = new List<Scooter>
            {
                new Scooter("SXT", "SXT 500"),
                new Scooter("SXT", "SXT Ultimate Pro")
            };

            return scooters;
        }

        public int CountScooters(string make, string model)
        {
            throw new NotImplementedException();
        }

        public ICollection<Scooter> SelectScooters(ScootersToSearch scootersToSearch)
        {
            throw new NotImplementedException();
        }

        //

        //
    }
}

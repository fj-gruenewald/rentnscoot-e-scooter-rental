using System;
using System.Collections.Generic;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Persistence
{
    internal class CDataRead : IDataRead
    {
        //
        internal CDataRead()
        {
        }

        //
        public void InitDb()
        {
            throw new System.NotImplementedException(); 
            
        }

        //
        public void CloseDb()
        {
            throw new System.NotImplementedException(); 

        }

        //
        public int CountScooters()
        {
           throw new System.NotImplementedException();
        }

        //
        public IEnumerable<string> SelectMakes()
        {
            throw new System.NotImplementedException(); 

        }

        //
        public int CountScooters(string make)
        {
            throw new System.NotImplementedException(); 

        }

        //
        public IEnumerable<string> SelectModels(string make)
        {
            throw new System.NotImplementedException(); 

        }

        //
        public int CountScooters(string make, string model)
        {
            throw new System.NotImplementedException(); 

        }

        //
        public int CountScooters(ScootersToSearch scootersToSearch)
        {
            throw new System.NotImplementedException(); 

        }

        //
        public ICollection<Scooter> SelectScooters(ScootersToSearch scootersToSelect)
        {
            throw new System.NotImplementedException(); 

        }



    }
}

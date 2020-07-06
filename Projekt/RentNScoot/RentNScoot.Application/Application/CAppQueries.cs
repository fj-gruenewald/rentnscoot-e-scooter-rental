using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//
using RentNScoot.Domain;

namespace RentNScoot.Application
{
    internal class CAppQueries : IAppQueries
    {
        //
        private IDataRead _dataRead;

        //
        internal CAppQueries(IDataRead dataRead)
        {
            _dataRead = dataRead;
        }

        //
        public int CountScooters()
        {
            int nScooters = _dataRead.CountScooters();
            return nScooters;
        }

        //
        public IEnumerable<string> GetMakes()
        {
            IEnumerable<string> makes = _dataRead.SelectMakes();
            return makes;
        }

        //
        public int CountScooters(string make)
        {
            int nScooters = _dataRead.CountScooters(make); 
            return nScooters; 

        }

        //
        public IEnumerable<string> GetModels(string make)
        {
            IEnumerable<string> models = _dataRead.SelectModels(make);  
            return models;
        }

        //
        public int CountScooters(string make, string model)
        {
            int nScooters = _dataRead.CountScooters(make, model);
            return nScooters; 

        }

        //
        public int CountScooters(ScootersToSearch scootersToSearch) 
        {
            int nScooters = _dataRead.CountScooters(scootersToSearch);
            return nScooters;
        }

        //
        public ICollection<Scooter> GetScooters(ScootersToSearch scootersToSearch)
        {
            ICollection<Scooter> scooter = _dataRead.SelectScooters(scootersToSearch);
            return scooter; 

        }

    }
}

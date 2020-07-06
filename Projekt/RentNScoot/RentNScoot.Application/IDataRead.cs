using System;
using System.Collections.Generic;
using System.Text;

//
using RentNScoot.Domain;

namespace RentNScoot
{
    public interface IDataRead
    {
        int CountScooters();
        IEnumerable<string> SelectMakes(); 
        int CountScooters(string make); 
        IEnumerable<string> SelectModels(string make); 
        int CountScooters(string make, string model); 
        int CountScooters(ScootersToSearch carsToSearch); 
        ICollection<Scooter> SelectScooters(ScootersToSearch scootersToSearch);

    }
}

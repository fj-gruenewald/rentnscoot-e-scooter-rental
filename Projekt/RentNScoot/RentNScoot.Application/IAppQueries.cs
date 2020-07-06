using System;
using System.Collections.Generic;
using System.Text;

//
using RentNScoot.Domain;

namespace RentNScoot
{
    public interface IAppQueries
    {
        int CountScooters();
        IEnumerable<string> GetMakes();
        int CountScooters(string make);
        IEnumerable<string> GetModels(string make);
        int CountScooters(string make, string model);
        int CountScooters(ScootersToSearch scootersToSearch);
        ICollection<Scooter> GetScooters(ScootersToSearch scootersToSearch);
    }
}

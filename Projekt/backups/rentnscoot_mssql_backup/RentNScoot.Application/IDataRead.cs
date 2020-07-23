using System;
using System.Collections.Generic;
using System.Text;

//
using RentNScoot.Domain;

namespace RentNScoot
{
    public interface IDataRead
    {
        void InitDb();
        void CloseDb();

        int CountScooters();

        ICollection<string> ReadLocations();


    }
}

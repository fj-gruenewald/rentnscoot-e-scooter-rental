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
        void DisposeDb();
        int CountScooters();

        ICollection<Scooter> SelectAllScooters();
    }
}

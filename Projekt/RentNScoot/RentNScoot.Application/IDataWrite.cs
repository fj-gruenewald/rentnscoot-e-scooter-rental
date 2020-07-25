using System;
using System.Collections.Generic;
using System.Text;

//
using RentNScoot.Domain;

namespace RentNScoot
{
    public interface IDataWrite
    {
        void InitDb();
        void DisposeDb();

        int InsertCustomer(Customer customer);
    }
}

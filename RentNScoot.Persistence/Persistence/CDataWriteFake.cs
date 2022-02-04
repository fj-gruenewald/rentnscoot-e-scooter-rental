using System;

namespace RentNScoot.Persistence
{
    internal class CDataWriteFake : IDataWrite
    {
        internal CDataWriteFake()
        { }

        public void InitDb()
        {
            throw new NotImplementedException();
        }

        public void DisposeDb()
        {
            throw new NotImplementedException();
        }

        public int InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int InsertRental(Rental rental)
        {
            throw new NotImplementedException();
        }

        public int UpdateRental(Rental rental)
        {
            throw new NotImplementedException();
        }

        public int DeleteRental(Rental rental)
        {
            throw new NotImplementedException();
        }

        public int UpdateScooter(Scooter scooter)
        {
            throw new NotImplementedException();
        }
    }
}
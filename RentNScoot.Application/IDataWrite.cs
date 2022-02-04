namespace RentNScoot
{
    public interface IDataWrite
    {
        void InitDb();

        void DisposeDb();

        int InsertCustomer(Customer customer);

        int InsertRental(Rental rental);

        int DeleteRental(Rental rental);

        int UpdateScooter(Scooter scooter);
    }
}
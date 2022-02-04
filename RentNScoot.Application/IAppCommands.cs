namespace RentNScoot
{
    public interface IAppCommands
    {
        int InsertCustomer(Customer customer);

        int InsertRental(Rental rental);

        int DeleteRental(Rental rental);

        int UpdateScooter(Scooter scooter);
    }
}
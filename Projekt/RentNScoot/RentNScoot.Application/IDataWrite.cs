//
using RentNScoot.Domain;

namespace RentNScoot
{
    public interface IDataWrite
    {
        //datenbank initialisieren
        void InitDb();

        //datenbank schließen
        void DisposeDb();

        //kunde einfügen
        int InsertCustomer(Customer customer);
    }
}
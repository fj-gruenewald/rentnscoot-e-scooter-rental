//

namespace RentNScoot.Persistence.Factories
{
    public class AFactoryData
    {
        //
        public static IDataRead CreateReadInstance(bool fake)
        {
            return new CDataScooterRead();
        }

        //
        public static IDataWrite CreateWriteInstance(bool fake)
        {
            //if (fake) return new CDataWriteFake();
            return new CDataWrite();
        }
    }
}
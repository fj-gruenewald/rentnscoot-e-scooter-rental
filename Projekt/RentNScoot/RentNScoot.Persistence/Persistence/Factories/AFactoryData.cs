using System;
using System.Collections.Generic;
using System.Text;

//


namespace RentNScoot.Persistence.Factories
{
    public class AFactoryData
    {
        //
        public static IDataRead CreateReadInstance(bool fake)
        {
            return new CDataRead();
        }

        //
        public static IDataWrite CreateWriteInstance(bool fake)
        {
            //if (fake) return new CDataWriteFake();
            return new CDataWrite();
        }
    }
}

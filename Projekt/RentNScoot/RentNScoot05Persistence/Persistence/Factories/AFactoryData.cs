using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Persistence.Factories
{
    public class AFactoryData
    {
        public static IDataRead CreateReadInstance()
        {
            return new CDataRead();
        }

        public static IDataWrite CreateWriteInstance()
        {
            return new CDataWrite();
        }

    }
}

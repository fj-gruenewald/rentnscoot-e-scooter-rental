using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//
using RentNScoot.Domain;

namespace RentNScoot.Application
{
    internal class CAppQueries : IAppQueries
    {
        //
        private IDataRead _dataRead;

        //
        internal CAppQueries(IDataRead dataRead)
        {
            _dataRead = dataRead;
        }

        //
        public int CountScooters()
        {
            int nScooters = _dataRead.CountScooters();
            return nScooters;
        }
    }
}

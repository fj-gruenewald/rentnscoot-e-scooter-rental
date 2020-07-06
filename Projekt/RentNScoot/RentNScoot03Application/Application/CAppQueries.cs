﻿using System;
using System.Collections.Generic;
using System.Text;

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
            int nScooter = _dataRead.CountScooters();
            return nScooter;
        }

    }
}
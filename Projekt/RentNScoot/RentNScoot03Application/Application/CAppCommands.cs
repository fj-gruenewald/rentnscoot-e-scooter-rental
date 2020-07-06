using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Application
{
    internal class CAppCommands : IAppCommands
    {       
        //
        private IDataWrite _dataWrite;

        //Konstruktor
        internal CAppCommands(IDataWrite dataWrite)
        {
            _dataWrite = dataWrite;
        }
    }
}

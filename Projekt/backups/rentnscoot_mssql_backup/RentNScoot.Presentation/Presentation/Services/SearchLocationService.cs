using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Presentation.Services
{
    internal class SearchLocationService
    {
        private readonly IAppQueries AppQueries;

        public SearchLocationService(IAppQueries appQueries)
        {
            this.AppQueries = appQueries;
        }
    }
}

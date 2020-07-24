using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Presentation.ViewModels
{
    class CvmSearchLocation
    {
        #region fields
        private readonly CvmMain _vmMain;
        #endregion

        #region properties(Data)
        //
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //
        private ICollection<Location> _searchResults = new List<Location>();

        //
        public ICollection<Location> SearchResults
        {
            get
            {
                return _searchResults;
            }
            set
            {
                _searchResults = value ?? new List<Location>();
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SearchResults"));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonText"));
            }
        }

        //
        private Location _selectedLocation = new Location();
        private ICollection<Location> _selectedCarsList = new List<Location>();

        //
        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
                _selectedCarsList.Add(_selectedLocation);
            }
        }
        #endregion

        #region ctor
        private static volatile CvmSearchLocation? instance = null;

        private static readonly object padlock = new object();

        private CvmSearchLocation(CvmMain vmMain)
        {
            _vmMain = vmMain;
        }

        internal static CvmSearchLocation CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new CvmSearchLocation(vmMain);
                }
                return instance;
            }
        }
        #endregion

        #region events
        #endregion
    }
}

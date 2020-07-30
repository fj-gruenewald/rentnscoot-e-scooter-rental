using RentNScoot.Domain;
using System.Collections.Generic;
using System.ComponentModel;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmSearchLocation : INotifyPropertyChanged
    {
        #region fields

        private readonly CvmMain _vmMain;

        #endregion fields

        #region properties(Data)

        //wenn eigenschaft verändert
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //liste mit locations
        private ICollection<Location> _searchResults = new List<Location>();

        //liste mit locations holen
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

        //ausgewählte location
        private Location _selectedLocation = new Location();

        private ICollection<Location> _selectedCarsList = new List<Location>();

        //ausgewählte location
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

        #endregion properties(Data)

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

        #endregion ctor
    }
}
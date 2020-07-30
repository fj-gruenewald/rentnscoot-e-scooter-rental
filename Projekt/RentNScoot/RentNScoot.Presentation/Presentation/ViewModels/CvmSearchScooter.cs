using RentNScoot.Domain;
using System.Collections.Generic;
using System.ComponentModel;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmSearchScooter
    {
        #region fields

        private readonly CvmMain _vmMain;

        #endregion fields

        #region properties(Data)

        //wenn eigenschaft verändert
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Liste alle Scooter
        private ICollection<Scooter> _searchResults = new List<Scooter>();

        //Liste aller Scooter holen
        public ICollection<Scooter> SearchResults
        {
            get
            {
                return _searchResults;
            }
            set
            {
                _searchResults = value ?? new List<Scooter>();
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SearchResults"));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ButtonText"));
            }
        }

        //Ausgewählten Scooter
        private Scooter _selectedScooter = new Scooter();

        private ICollection<Scooter> _selectedCarsList = new List<Scooter>();

        //Ausgewählter Scooter
        public Scooter SelectedScooter
        {
            get
            {
                return _selectedScooter;
            }
            set
            {
                _selectedScooter = value;
                _selectedCarsList.Add(_selectedScooter);
            }
        }

        #endregion properties(Data)



        #region ctor
        private static volatile CvmSearchScooter? instance = null;

        private static readonly object padlock = new object();

        private CvmSearchScooter(CvmMain vmMain)
        {
            _vmMain = vmMain;
        }

        internal static CvmSearchScooter CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new CvmSearchScooter(vmMain);
                }
                return instance;
            }
        }

        #endregion ctor
    }
}
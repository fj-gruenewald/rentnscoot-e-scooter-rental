using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RentNScoot.Presentation.ViewModels
{
    class CvmSearchMisc : CvmBase
    {

        private ObservableCollection<string> locations;
        private readonly CvmMain cvmMain;

        public ObservableCollection<string> Locations
        {
            get => locations = cvmMain.Results;
            set
            {
                locations = value;
                OnPropertyChanged();
            }
        }
    }
}

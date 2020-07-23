using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RentNScoot.Domain;
using RentNScoot.Presentation.Services;

namespace RentNScoot.Presentation.ViewModels
{
    public class CvmMain : CvmBase
    {
        private ObservableCollection<string> results = new ObservableCollection<string>();
        private LocationsToSearch search;
        private int scooterCount;

        public ObservableCollection<string> Results
        {
            get => results;
            set
            {
                results = value;
                OnPropertyChanged();
            }
        }

        public LocationsToSearch Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
            }
        }

        public bool SearchCancelled { get; set; }

        public int StudentCount
        {
            get => scooterCount;
            set
            {
                scooterCount = value;
                OnPropertyChanged();
            }
        }
        internal CvmMain(IAppCommands appcommands, IAppQueries appqueries)
        {
        }
    }
}

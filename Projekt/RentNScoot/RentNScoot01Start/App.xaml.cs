﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

//
using RentNScoot.Persistence.Factories;
using RentNScoot.Application.Factories;
using RentNScoot.Presentation.Factories;

namespace RentNScoot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        //Persistence
        private IDataRead _dataRead;
        private IDataWrite _dataWrite;

        //Application
        private IAppQueries _appQueries;
        private IAppCommands _appCommands;

        //Presentation
        private IDialog _dialog;


        //EventHandler for StartUp
        void App_StartUp(object sender, StartupEventArgs e)
        {
            //Dependency Injection Setup
            //Dependency Inversion Principle 

            //Persistence
            _dataRead = AFactoryData.CreateReadInstance();
            _dataWrite = AFactoryData.CreateWriteInstance();

            //Application
            _appQueries = AFactoryApp.CreateQueryInstance(_dataRead);
            _appCommands = AFactoryApp.CreateCommandInstance(_dataWrite);

            //Presentation
            _dialog = AFactoryDialog.CreateSingleton(_appQueries, _appCommands);
            _dialog.Show();

        }

    }
}

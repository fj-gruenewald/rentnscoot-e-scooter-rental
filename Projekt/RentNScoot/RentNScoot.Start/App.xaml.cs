using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

//
using RentNScoot.Persistence.Factories;
using RentNScoot.Application.Factories;
using RentNScoot.Presentation.Factories;

namespace RentNScoot.Start
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
        void AppStartUp(object sender, StartupEventArgs e)
        {
            //Dependency Injection Setup
            //Dependency Inversion Principle 

            //Persistence
            _dataRead = AFactoryData.CreateReadInstance(true);
            _dataWrite = AFactoryData.CreateWriteInstance(true);

            //Application
            _appQueries = AFactoryApp.CreateQueryInstance(_dataRead);
            _appCommands = AFactoryApp.CreateCommandInstance(_dataWrite);

            //Presentation
            _dialog = AFactoryDialog.CreateSingleton(_appCommands, _appQueries);
            _dialog.Show();

        }

        //
        protected override void OnStartup(StartupEventArgs e)
        {

            // Change cultureInfo in all XAML View, e.z. to de-DE
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
    }
}

using RentNScoot.Application.Factories;

//
using RentNScoot.Persistence.Factories;
using RentNScoot.Presentation.Factories;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

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
        private void AppStartUp(object sender, StartupEventArgs e)
        {
            //Dependency Injection Setup
            //Dependency Inversion Principle

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
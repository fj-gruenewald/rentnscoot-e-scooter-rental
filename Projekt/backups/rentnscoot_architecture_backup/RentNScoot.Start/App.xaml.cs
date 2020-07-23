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

            try
            {
                //
                string connectionString = string.Empty;
                
                connectionString = @"Server=localhost;Database=cardatabase;Uid=root;Pwd=geh1m_;";
                _dataRead        = AFactoryData.Create_ReadSql(connectionString);

                _dataRead.InitDb();

                //Persistence Write

                connectionString = @"Server=localhost;Database=cardatabase;Uid=root;Pwd=geh1m_;";
                _dataWrite       = AFactoryData.Create_CarWriteMySql(connectionString);

                //Application
                _appQueries = AFactoryApp.CreateQueryInstance(_dataRead);
                _appCommands = AFactoryApp.CreateCommandInstance(_dataWrite);

                //Presentation
                _dialog = AFactoryDialog.CreateSingleton(_appCommands, _appQueries);
                _dialog.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ABBRUCH", MessageBoxButton.OK,MessageBoxImage.Stop);
            }
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
using RentNScoot.Application.Factories;
using RentNScoot.Presentation.Factories;
using System;
using System.Configuration;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using RentNScoot.Persistence.Factories;
using RentNScoot.Utils;

namespace RentNScoot.Start
{
    public partial class App : System.Windows.Application
    {
        //Services

        private IDataRead _dataRead;
        private IDataWrite _dataWrite;
        private IAppQueries _appQueries;
        private IAppCommands _appCommands;
        private IDialog _dialog;

        //EventHandler for StartUp
        private void AppStartUp(object sender, StartupEventArgs e)
        {
            Log.D(this, "App_StartUp", "");
            Err.D(this, "Start", "");

            //Dependency Injection Setup
            //Dependency Inversion Principle

            string connectionString = @"Data Source=d:\database.db; Version=3;";

            try
            {
                /*Persistence Write
                connectionString = @"Server=localhost;Database=scooterdatabase;Uid=root;Pwd=geh1m_;";
                _dataWrite = AFactoryData.Create_WriteSql(connectionString);*/

                _dataRead = AFactoryData.Create_ReadInstanceSqlite(connectionString);
                _dataWrite = AFactoryData.Create_WriteInstanceSqlite(connectionString);

                _dataRead.InitDb();

                //Application
                _appQueries = AFactoryApp.CreateQueryInstance(_dataRead);
                _appCommands = AFactoryApp.CreateCommandInstance(_dataWrite);

                //Presentation
                _dialog = AFactoryDialog.CreateSingleton(_appQueries, _appCommands);
                _dialog.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An Error occured while launching the Instances", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

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
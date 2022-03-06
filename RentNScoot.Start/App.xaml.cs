using RentNScoot.Application.Factories;
using RentNScoot.Presentation.Factories;
using System;
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

            //relative Path for DB
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            string connectionString = $"Data Source={strWorkPath + "\\Database\\database.db"}; Version=3;";

            //Dependency Injection Setup
            try
            {
                //Persistence
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
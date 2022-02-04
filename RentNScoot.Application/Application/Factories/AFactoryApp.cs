using RentNScoot.Utils;

namespace RentNScoot.Application.Factories
{
    public abstract class AFactoryApp
    {
        public static IAppQueries CreateQueryInstance(IDataRead dataRead)
        {
            Log.D("AFactoryApp", "Create_Queries(IDataRead)", "");
            return new CAppQueries(dataRead);
        }

        public static IAppCommands CreateCommandInstance(IDataWrite dataWrite)
        {
            Log.D("AFactoryApp", "Create_Commands(IDataWrite)", "");
            return new CAppCommands(dataWrite);
        }
    }
}
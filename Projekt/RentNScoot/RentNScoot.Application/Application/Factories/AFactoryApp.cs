namespace RentNScoot.Application.Factories
{
    public abstract class AFactoryApp
    {
        public static IAppQueries CreateQueryInstance(IDataRead dataRead)
        {
            return new CAppQueries(dataRead);
        }

        public static IAppCommands CreateCommandInstance(IDataWrite dataWrite)
        {
            return new CAppCommands(dataWrite);
        }
    }
}
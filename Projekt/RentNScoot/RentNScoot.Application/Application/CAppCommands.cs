namespace RentNScoot.Application
{
    internal class CAppCommands : IAppCommands
    {
        //DataWrite initialisieren
        private IDataWrite _dataWrite;

        //Konstruktor
        internal CAppCommands(IDataWrite dataWrite)
        {
            _dataWrite = dataWrite;
        }
    }
}
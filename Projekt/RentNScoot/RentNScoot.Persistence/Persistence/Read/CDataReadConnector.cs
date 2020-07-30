using System.Data.Common;

namespace RentNScoot.Persistence.Read
{
    internal class CDataReadConnector : ADataRead
    {
        internal CDataReadConnector(DbProviderFactory dbProviderFactory, string connectionString)
            : base(dbProviderFactory, connectionString)
        {
        }
    }
}
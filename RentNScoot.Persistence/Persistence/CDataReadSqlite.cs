using System.Data.Common;

namespace RentNScoot.Persistence
{
    internal class CDataReadSqlite : ADataRead
    {
        public CDataReadSqlite(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory,
            connectionString)
        {
        }
    }
}
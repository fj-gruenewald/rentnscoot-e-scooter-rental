using System.Data.Common;

namespace RentNScoot.Persistence
{
    internal class CDataWriteSqlite : ADataWrite
    {
        internal CDataWriteSqlite(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        {
        }
    }
}
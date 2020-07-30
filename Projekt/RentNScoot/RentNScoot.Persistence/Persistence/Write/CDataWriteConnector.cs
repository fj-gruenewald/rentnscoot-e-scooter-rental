using System.Data.Common;

namespace RentNScoot.Persistence.Write
{
    internal class CDataWriteConnector : ADataWrite
    {
        internal CDataWriteConnector(DbProviderFactory dbProviderFactory, string connectionString)
            : base(dbProviderFactory, connectionString)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

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

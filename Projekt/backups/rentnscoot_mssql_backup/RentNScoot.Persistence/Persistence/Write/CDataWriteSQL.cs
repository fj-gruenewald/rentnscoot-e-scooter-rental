using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RentNScoot.Persistence.Write
{
    internal class CDataWriteSQL : ADataWrite
    {
        internal CDataWriteSQL(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RentNScoot.Persistence.Read
{
    internal class CDataReadSQL : ADataRead
    {
        internal CDataReadSQL(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }
    }
}

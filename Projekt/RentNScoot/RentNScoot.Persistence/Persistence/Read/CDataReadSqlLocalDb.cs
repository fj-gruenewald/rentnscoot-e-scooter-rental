using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RentNScoot.Persistence.Read
{
    internal class CDataReadSqlLocalDb :  ADataRead
    {
        internal CDataReadSqlLocalDb(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        {

        }
    }
}

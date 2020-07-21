using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RentNScoot.Persistence.Read
{
    class ADataRead : SQLConnector, IDataRead
    {

        //
        public ADataRead(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString)
        {
        }

        //
        public int CountScooters()
        {
            var count = 0;

            if (OpenConnection())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM ScootersTable;";
                command.Parameters.Clear();

                var result = command.ExecuteScalar();
                count = (int)result;
            }
            CloseConnection();

            return count;
        }

        //
        public ICollection<string> ReadLocations()
        {
            var locations = new List<string>();

            if (OpenConnection())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM ScooterLocationTable";
                command.Parameters.Clear();

                var reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        locations.Add(reader[0].ToString());
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
            CloseConnection();

            return locations;
        }
    }
}

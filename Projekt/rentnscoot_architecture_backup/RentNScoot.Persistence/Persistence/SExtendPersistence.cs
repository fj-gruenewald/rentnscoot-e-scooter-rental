using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot
{
    public static class SExtendPersistence
    {

        //  **********************************************************************
        //  Car Extension Methods                                                *
        //  **********************************************************************    
        public static void AddInsertParameters(this Scooter scooter, DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            AddParameter(dbCommand, "pk", scooter.Id);
            AddParameter(dbCommand, "make", scooter.Make);
            AddParameter(dbCommand, "model", scooter.Model);
            AddParameter(dbCommand, "price", scooter.Price);
        }
        
        public static void FromDbDataReader(this Scooter scooter, DbDataReader dbDataReader)
        {
            scooter.Id = Convert.ToString(dbDataReader[0]);
            scooter.Make = Convert.ToString(dbDataReader[1]);
            scooter.Model = Convert.ToString(dbDataReader[2]);
            scooter.Price = Convert.ToDouble(dbDataReader[3]);
        }

        //  **********************************************************************
        //  Customer Extension Methods
        //  **********************************************************************    

        private static void AddParameter(DbCommand dbCommand, string name, object value)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }
    }
}

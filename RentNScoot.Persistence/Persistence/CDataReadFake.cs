using System;
using System.Collections.Generic;
using RentNScoot.Utils;

namespace RentNScoot.Persistence
{
    internal class CDataReadFake : IDataRead
    {
        internal CDataReadFake()
        {
            Log.D(this, "Ctor()", "");
        }

        public void InitDb()
        {
            Log.D(this, "InitDb() =", "");
        }

        public void DisposeDb()
        {
            Log.D(this, "CloseDb() =", "");
        }

        //Read List of all Locations
        public List<Location> GetLocationListFromDB()
        {
            List<Location> ListOfLocations = new List<Location>();

            try
            {
                //Dummy Data
                Location testLocation = new Location("15", "Hamburg", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation1 = new Location("16", "Bremen", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation2 = new Location("17", "Berlin", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation3 = new Location("17", "Brunswick", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation4 = new Location("17", "Lüneburg", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation5 = new Location("17", "Stade", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation6 = new Location("17", "Düsseldorf", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation7 = new Location("17", "Mannheim", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation8 = new Location("17", "München", 1111, "Hamburg", "Schillerstraße", "1A");
                Location testLocation9 = new Location("17", "Stuttgard", 1111, "Hamburg", "Schillerstraße", "1A");
                ListOfLocations.Add(testLocation);
                ListOfLocations.Add(testLocation1);
                ListOfLocations.Add(testLocation2);
                ListOfLocations.Add(testLocation3);
                ListOfLocations.Add(testLocation4);
                ListOfLocations.Add(testLocation5);
                ListOfLocations.Add(testLocation6);
                ListOfLocations.Add(testLocation7);
                ListOfLocations.Add(testLocation8);
                ListOfLocations.Add(testLocation9);

                //Get Data from Database
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException("hello");
            }

            Log.D(this, "Locations() =", "GetLocations");
            return ListOfLocations;
        }

        //Read List of all Scooters that belongs to an Location
        public List<Scooter> GetScooterListFromDbById(string locationId)
        {
            throw new NotImplementedException();
            List<Scooter> ListOfScootersToLocation = new List<Scooter>();

            try
            {
                //Get Data from Database
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException("hello");
            }

            return ListOfScootersToLocation;
        }

        public List<Scooter> GetScooterListFromDbByObject(Location location)
        {
            List<Scooter> ListOfScootersToLocation = new List<Scooter>();

            try
            {
                //Get Data from Database
                Scooter scoot = new Scooter(1, 15, 1, "Xiaomi", "Mi Electric Scooter 1S");
                Scooter scoot1 = new Scooter(2, 15, 1, "Unagi", "The Model One");
                Scooter scoot2 = new Scooter(2, 15, 1, "xiamoi", "ts1002");
                Scooter scoot3 = new Scooter(2, 15, 1, "xiamoi", "ts1003");
                Scooter scoot4 = new Scooter(2, 15, 1, "xiamoi", "ts1004");
                Scooter scoot5 = new Scooter(2, 15, 1, "xiamoi", "ts1005");
                Scooter scoot6 = new Scooter(2, 15, 1, "xiamoi", "ts1006");
                Scooter scoot7 = new Scooter(2, 15, 1, "xiamoi", "ts1007");
                Scooter scoot8 = new Scooter(2, 15, 1, "xiamoi", "ts1008");
                Scooter scoot9 = new Scooter(2, 15, 1, "xiamoi", "ts1009");

                ListOfScootersToLocation.Add(scoot);
                ListOfScootersToLocation.Add(scoot1);
                ListOfScootersToLocation.Add(scoot2);
                ListOfScootersToLocation.Add(scoot3);
                ListOfScootersToLocation.Add(scoot4);
                ListOfScootersToLocation.Add(scoot5);
                ListOfScootersToLocation.Add(scoot6);
                ListOfScootersToLocation.Add(scoot7);
                ListOfScootersToLocation.Add(scoot8);
                ListOfScootersToLocation.Add(scoot9);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException("hello");
            }

            return ListOfScootersToLocation;
        }

        public Scooter GetScooterFromDbById(string locationId)
        {
            throw new NotImplementedException();
        }

        public Rental GetRentableFromDbById(string rentableId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerFromDbById(string customerId)
        {
            throw new NotImplementedException();
        }

        public Location GetLocationFromDbById(string locationId)
        {
            throw new NotImplementedException();
        }
    }
}
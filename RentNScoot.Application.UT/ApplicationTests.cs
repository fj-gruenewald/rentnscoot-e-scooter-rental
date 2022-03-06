using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RentNScoot.Persistence.Factories;

namespace RentNScoot.Application.UT
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void InitDataRead_CreateDataReadInstance()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();

            //Assert
            Assert.IsNotNull(dataRead);
        }

        [TestMethod]
        public void InitDataWrite_CreateDataWriteInstance()
        {
            //Arrange
            IDataWrite dataWrite = AFactoryData.Create_WriteInstanceFake();

            //Assert
            Assert.IsNotNull(dataWrite);
        }

        [TestMethod]
        public void CAppQueries_GetFilledObjectFromDatabase_LocationList()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();

            //Act
            var valueToTest = dataRead.GetLocationListFromDB();

            //Assert
            Assert.IsNotNull(valueToTest);
        }

        [TestMethod]
        public void CAppQueries_GetCorrectObjectFromDatabase_LocationList()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();

            //Act
            var valueToTest = dataRead.GetLocationListFromDB();

            //Assert
            Assert.IsInstanceOfType(valueToTest, typeof(List<Location>));
        }

        [TestMethod]
        public void CAppQueries_GetFilledObjectFromDatabase_ScooterToLocation()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();
            Location fakeLocation = new Location();

            //Act
            var valueToTest = dataRead.GetScooterListFromDbByObject(fakeLocation);

            //Assert
            Assert.IsNotNull(valueToTest);
        }

        [TestMethod]
        public void CAppQueries_GetCorrectObjectFromDatabase_ScooterToLocation()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();
            Location fakeLocation = new Location();

            //Act
            var valueToTest = dataRead.GetScooterListFromDbByObject(fakeLocation);

            //Assert
            Assert.IsInstanceOfType(valueToTest, typeof(List<Scooter>));
        }

        [TestMethod]
        public void CAppQueries_GetFilledObjectFromDatabase_CustomerById()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();

            //Act
            var valueToTest = dataRead.GetRentableFromDbById("1");

            //Assert
            Assert.IsNotNull(valueToTest);
        }

        [TestMethod]
        public void CAppQueries_GetCorrectObjectFromDatabase_CustomerById()
        {
            //Arrange
            IDataRead dataRead = AFactoryData.Create_ReadInstanceFake();

            //Act
            var valueToTest = dataRead.GetRentableFromDbById("1");

            //Assert
            Assert.IsInstanceOfType(valueToTest, typeof(Rental));
        }
    }
}
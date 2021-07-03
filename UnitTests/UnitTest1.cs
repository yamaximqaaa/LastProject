using Abstractions.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System;

namespace UnitTests
{
    [TestClass]
    public class WorkWithDbTests
    {
        [TestMethod]
        public void AddGetAirplaneTest()
        {
            // Arrange
            var expected = new Plane()
            {
                airline = Airline.UkraineInternationalAirlines,
                city = "Kyiv",
                gate = "BBC112",
                isPlaneInAirport = true,
                planeNum = "EWB2271",
                status = Status.CheckIn,
                terminal = Terminal.C,
                timeIn = DateTime.Now,
                timeOut = DateTime.Now.AddHours(2).AddMinutes(17).AddSeconds(8)
            };

            var addPlane = (Plane)expected.Clone();


            // Act
            Airport.AddPlane(addPlane);
            var getPlane = Airport.GetPlane(expected.planeNum);

            // Assert

            Assert.AreEqual<Plane>(expected, getPlane);


        }
    }
}

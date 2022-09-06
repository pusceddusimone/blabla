using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer.Library;
using Model.Library;
using System.Collections.Generic;
using System.Xml;

namespace LibraryTests
{
    [TestClass]
    public class ReservationDAOForXMLTests
    {
        XmlDocument xmlDoc, xmlBackup;
        ReservationDAOForXML reservationDAOForXML;
        private readonly string fileNameForTest = @"C:\Users\simone.pusceddu\source\repos\Solution.Library\ConsoleApp.Library\bin\Debug\Test.xml";
        [TestInitialize]
        public void SetUp()
        {
            xmlDoc = new XmlDocument();
            xmlBackup = new XmlDocument();
            xmlDoc.Load(fileNameForTest);
            xmlBackup.Load(fileNameForTest);
            reservationDAOForXML = new ReservationDAOForXML(fileNameForTest);
        }
        [TestMethod]
        public void ReadShouldReturnLegthOf2()
        {
            List<Reservation> reservations = reservationDAOForXML.Read();
            Assert.AreEqual(2, reservations.Count);
        }
        [TestMethod]
        public void ReadShouldReturnGivenReservationAtPosition1()
        {
            Reservation expectedReservation = new Reservation()
            {
                ReservationId = 0,
                BookId = 1,
                UserId = 1,
                StartDate = new DateTime(day: 21, month: 7, year: 2022),
                EndDate = new DateTime(day: 25, month: 7, year: 2022)
            };
            Reservation reservation = reservationDAOForXML.Read()[0];
            Assert.IsTrue(AreReservationEqual(expectedReservation, reservation));
        }

        [TestMethod]
        public void DeleteShouldRemoveTheElement()
        {
            try
            {
                reservationDAOForXML.Delete(0);
                Assert.IsNull(reservationDAOForXML.GetElementById(0));
            }
            finally
            {
                xmlBackup.Save(fileNameForTest);
            }
        }

        private bool AreReservationEqual(Reservation reservation1, Reservation reservation2)
        {
            if (reservation1 == null || reservation2 == null)
                return false;

            return reservation1.StartDate == reservation2.StartDate
                && reservation1.EndDate == reservation2.EndDate
                && reservation1.ReservationId == reservation2.ReservationId
                && reservation1.UserId == reservation2.UserId
                && reservation1.BookId == reservation2.BookId;
        }
    }
}

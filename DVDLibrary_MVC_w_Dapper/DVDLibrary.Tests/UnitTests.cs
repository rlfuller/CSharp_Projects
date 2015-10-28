using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data;
using DVDLibrary.Data.Mock_Repo;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void GetAllDVDsTest()
        {
            var repo = new DVDMockRepo();

            var result = repo.GetAllDVDs();

            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void GetAllActorsTest()
        {
            var repo = new DVDMockRepo();

            var result = repo.GetAllActors();

            Assert.AreEqual(result.Count, 5);
        }

        [Test]
        public void GetAllMPAATest()
        {
            var repo = new DVDMockRepo();

            var result = repo.GetAllMPAA();

            Assert.AreEqual(result.Count, 5);
        }

        [Test]
        public void GetAllStudiosTest()
        {
            var repo = new DVDMockRepo();

            var result = repo.GetAllStudios();

            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void GetActorDetailsTest()
        {
            var repo = new DVDMockRepo();

            int dvdID = 1;

            var result = repo.GetActorDetails(dvdID);

            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void GetDVDByIdTest()
        {
            var repo = new DVDMockRepo();

            int dvdID = 1;

            var result = repo.GetDVDById(dvdID);

            Assert.AreEqual(result.Title, "Talladega Nights");
        }

        [Test]
        public void GetDVDByTitleTest()
        {
            var repo = new DVDMockRepo();

            string title = "Happy Gilmore";

            var result = repo.GetDVDByTitle(title);

            Assert.AreEqual(result.Count, 1);
            Assert.AreNotEqual(result[0].Title, "Happy Days");
        }

        [Test]
        public void RemoveDVDTest()
        {
            var repo = new DVDMockRepo();

            int dvdId = 1;

            repo.RemoveDVD(dvdId);

            Assert.AreEqual(DVDMockRepo._dvds.Count, 2);
        }

        [Test]
        public void AddDVDTest()
        {
            var repo = new DVDMockRepo();

            var dvd = new DVD()
            {
                Title = "Test",
                ReleaseDate = new DateTime(2015, 10, 19),
                MPAA = "R",
                Director = "Mr. Test",
                StudioID = 1
            };

            int dvdId = repo.AddDVD(dvd);

            Assert.AreEqual(DVDMockRepo._dvds.Count, 4);
            Assert.AreEqual(DVDMockRepo._dvds[3].Title, "Test");
        }

        [Test]
        public void AddDVDTestProduction()
        {
            var repo = new DVDRepo();

            var dvd = new DVD()
            {
                Title = "Test",
                ReleaseDate = new DateTime(2015, 10, 19),
                MPAA = "R",
                Director = "Mr. Test",
                StudioID = 1
            };

            int dvdId = repo.AddDVD(dvd);

            //change depending on your database
            Assert.AreEqual(dvdId, 19);

        }

        [Test]
        public void RemoveDVDProduction()
        {
            var repo = new DVDRepo();

            repo.RemoveDVD(20);

            //change depending on your database
            //Assert.AreEqual(true, true);

        }
    }
}

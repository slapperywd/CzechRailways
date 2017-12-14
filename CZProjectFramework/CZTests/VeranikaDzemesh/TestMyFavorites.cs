using NUnit.Framework;

namespace CZTests.VeranikaDzemesh
{
    [TestFixture]
    public class TestMyFavorites : BaseTest
    {

        [Test]
        public void TestAddToFavoriteStation()
        {
            var homePage = HomePage.SetLanguage(settings.Language).LogIn(user.Email, user.Password);

            string addedStation = homePage.GoToStation().EnterStation().AddStationToFavorite().GetStationName();

            //Go to “My travel” menu option
            var checkFavorite = homePage.GoToMyTravel().GoToAdministerFavoriteStation().GoToFavoriteStations();
            string favoriteStation = checkFavorite.GetStationName();

            //“Favorite stations” section in My travel contains added station
            Assert.AreEqual(addedStation, favoriteStation);

            //Delete station from favorites
            var isDeleted = checkFavorite.DeleteFavoriteStation().IsFavoriteStationEmpty();

            //Verify that station is deleted
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void TestAddToFavoritePassenger()
        {
            var homePage = HomePage.SetLanguage(settings.Language).LogIn(user.Email, user.Password);

            //Go to “My travel” menu option
            var addPassanger = homePage.GoToMyTravel()
                .GoToAdministerFavoritePassenger()
                .AddFavoritePassenger(TestData.PassengerName);

            bool isTheSamePassenger = addPassanger.IsTheSamePassenger(TestData.PassengerName);

            //“Favorite passengers” section in My travel contains added passenger
            Assert.IsTrue(isTheSamePassenger);

            //Delete passenger from favorites
            bool isDeleted = addPassanger.DeleteFavoritePassenger().IsFavoritePassengerEmpty();

            //Verify that passenger is deleted
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void TestAddToFavoriteTrain()
        {
            var homePage = HomePage.SetLanguage(settings.Language).LogIn(user.Email, user.Password);
            //Go to “Train” menu option
            string addedTrain = homePage.GoToTrain().AddTrainToFavorite().GetTrainName();

            var checkFavorite = homePage.GoToMyTravel().GoToAdministerFavoriteTrain().GoToFavoriteTrains();
            string favoriteTrain = checkFavorite.GetTrainName();

            //“Favorite trains” section in My travel contains added train
            Assert.AreEqual(addedTrain, favoriteTrain);

            //Delete train from favorites
            bool isDeleted = checkFavorite.DeleteFavoriteTrain().IsFavoriteTrainEmpty();

            //Verify that train is deleted
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void TestAddToFavoriteConnection()
        {
            var homePage = HomePage.SetLanguage(settings.Language).LogIn(user.Email, user.Password);

            var addCon = homePage
                .GoToConnection().SetFromStationTown(TestData.Departure).SetToStationTown(TestData.Arrival)
                .Search()
                .AddConnectionToFavorite();
            string addedConnection = addCon.GetConnectionName();

            addCon.ClickGoBackOneStep();

            //Go to “My travel” menu option
            var fav = homePage.GoToMyTravel().GoToAdministerFavoriteConnection().GoToFavoriteConnections();
            string favoriteConnection = fav.GetConnectionName();

            //“Favorite connections” section in My travel equals to added connection
            Assert.AreEqual(addedConnection, favoriteConnection);

            //Delete connection from favorites
            bool isDeleted = fav.DeleteFavoriteConnection().IsFavoriteConnectionEmpty();

            //Verify that connection is deleted
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void TestAddToFavoriteLine()
        {
            var homePage = HomePage.SetLanguage(settings.Language).LogIn(user.Email, user.Password);

            //Go to “Stations” menu option
            var addLine = homePage.GoToStation().EnterStation().AddFavoriteLine();
            string addedLine = addLine.GetLineName();

            //Go to “My travel” menu option
            var checkLine = homePage.GoToMyTravel().GoToAdministerFavoriteLine().GoToFavoriteLine();
            string favoriteLine = checkLine.GetLineName();

            //“Favorite lines” section in My travel contains added line
            Assert.IsTrue(favoriteLine.Contains(addedLine));

            //Delete line from favorites
            bool isDeleted = checkLine.DeleteFavoriteLine().IsFavoriteLineEmpty();

            //Verify that line is deleted
            Assert.IsTrue(isDeleted);
        }

    }
}

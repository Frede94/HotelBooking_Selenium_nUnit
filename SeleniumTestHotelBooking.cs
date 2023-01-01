using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace HotelBooking_Selenium_nUnit
{
    [TestFixture]
    public class HotelBookingTests
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            //Driver = new FirefoxDriver();
            //Driver = new SafariDriver();
            //Driver = new EdgeDriver();
        }

        #region Hotelbooking
        [Test]
        public void HotelBookingTryCreateBookingTrue()
        {
            //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");

            Assert.Pass();
        }

        //[Test]
        //public void HotelBookingTryCreateBookingFalse()
        //{
        //    //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
        //    Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");

        //    Assert.Pass();
        //}

        //[Test]
        //public void HotelBookingTryCreatingMultipleBookings()
        //{
        //    //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
        //    Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");

        //    Assert.Pass();
        //}
        #endregion

    }
}
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
            //Port number varies from computer to computer, if this 404, check if port nr is correct.
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");
            Wait(0);

            Driver.FindElement(By.XPath("/html/body/div/main/p[1]/a")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='StartDate']")).SendKeys(DateTime.Today.AddDays(21).ToString());
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='EndDate']")).SendKeys(DateTime.Today.AddDays(22).ToString());
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='CustomerId']")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='CustomerId']/option[2]")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input")).Click();
            Wait(2000);
   
            var bookingTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table[2]/tbody/tr")).Count;
            Console.WriteLine(bookingTablerows);

            string startDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr["+ bookingTablerows +"]/td[1]")).Text;
            String endDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr["+ bookingTablerows +"]/td[2]")).Text;
            string customer = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[" + bookingTablerows + "]/td[4]")).Text;

            //Implement actions to delete created booking.
            //This is not implemented in Hotelbooking at the moment

            Driver.Quit();

            Assert.That(startDate, Is.EqualTo(DateTime.Today.AddDays(21).ToString()));
            Assert.That(endDate, Is.EqualTo(DateTime.Today.AddDays(22).ToString()));
            Assert.That(customer, Is.EqualTo("Jane Doe").IgnoreCase);
        }

        [Test]
        public void HotelBookingTryCreateBookingFalse()
        {
            //Port number varies from computer to computer, if this 404, check if port nr is correct.
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");
            Wait(0);

            Driver.FindElement(By.XPath("/html/body/div/main/p[1]/a")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='StartDate']")).SendKeys(DateTime.Today.AddDays(9).ToString());
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='EndDate']")).SendKeys(DateTime.Today.AddDays(9).ToString());
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='CustomerId']")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='CustomerId']/option[2]")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input")).Click();
            Wait(2000);

            string errorMessage = Driver.FindElement(By.XPath("/html/body/div/main/h4[1]")).Text;

            //Implement actions to delete created booking.
            //This is not implemented in Hotelbooking at the moment

            Driver.Quit();
            Assert.That(errorMessage, Is.EqualTo("The booking could not be created. There were no available room.").IgnoreCase);
        }

        [Test]
        public void HotelBookingTryCreatingMultipleBookings()
        {
            //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");

            Driver.Quit();
            Assert.Pass();
        }

        //[Test]
        //public void HotelBookingTryCreateRoomsTrue()
        //{
        //    //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
        //    Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");

        //    Assert.Pass();
        //}
        #endregion

        /// <summary>
        /// Method to make the execution of test wait, for a specified amount of time.
        /// Purely for the benefit of being able to se, the actions made, 
        /// since the window would close or action would be completed nearly instantly.
        /// Default wait is 500 ms.
        /// </summary>
        /// <param name="time"></param>
        public void Wait(int time)
        {
            if(time > 0)
            {
                Thread.Sleep(time);
            }
            else
            {
                Thread.Sleep(500);
            }
        }
    }
}
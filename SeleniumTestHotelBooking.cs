using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace HotelBooking_Selenium_nUnit
{
    [TestFixture]
    public class HotelBookingTests : DriverHelper
    {

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        #region Hotelbooking
        [Test, Order(1)]
        public void HotelBooking_TryCreateBooking_True()
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
            Wait(500);
   
            var bookingTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table[2]/tbody/tr")).Count;
            //Console.WriteLine(bookingTablerows);

            string startDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr["+ bookingTablerows +"]/td[1]")).Text;
            String endDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr["+ bookingTablerows +"]/td[2]")).Text;
            string customer = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[" + bookingTablerows + "]/td[4]")).Text;

            //Implement actions to delete created booking.
            //This is not implemented in Hotelbooking at the moment


            Assert.That(startDate, Is.EqualTo(DateTime.Today.AddDays(21).ToString()));
            Assert.That(endDate, Is.EqualTo(DateTime.Today.AddDays(22).ToString()));
            Assert.That(customer, Is.EqualTo("Jane Doe").IgnoreCase);
            Driver.Quit();
        }

        [Test, Order(2)]
        public void HotelBooking_TryCreateBooking_False()
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
            Wait(500);

            string errorMessage = Driver.FindElement(By.XPath("/html/body/div/main/h4[1]")).Text;

            //Implement actions to delete created booking.
            //This is not implemented in Hotelbooking at the moment

            Assert.That(errorMessage, Is.EqualTo("The booking could not be created. There were no available room.").IgnoreCase);
            Driver.Quit();
        }

        [Test, Order(3)]
        public void HotelBooking_TryCreatingMultipleBookings()
        {
            //Port number varies from computer to computer, if this 404, check if port nr is correct.
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");
            Wait(0);
            int dayStart = 30;
            int dayEnd = 32;

            for (int i = 1; i < 4; i++)
            {
                Driver.FindElement(By.XPath("/html/body/div/main/p[1]/a")).Click();
                Wait(0);
                Driver.FindElement(By.XPath("//*[@id='StartDate']")).SendKeys(DateTime.Today.AddDays(dayStart).ToString());
                Wait(0);
                Driver.FindElement(By.XPath("//*[@id='EndDate']")).SendKeys(DateTime.Today.AddDays(dayEnd).ToString());
                Wait(0);
                Driver.FindElement(By.XPath("//*[@id='CustomerId']")).Click();
                Wait(0);
                Driver.FindElement(By.XPath("//*[@id='CustomerId']/option[2]")).Click();
                Wait(0);
                Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input")).Click();
                Wait(0);
                
                var bookingTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table[2]/tbody/tr")).Count;
                //Console.WriteLine(bookingTablerows);

                string startDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[" + bookingTablerows + "]/td[1]")).Text;
                string endDate = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[" + bookingTablerows + "]/td[2]")).Text;
                string customer = Driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[" + bookingTablerows + "]/td[4]")).Text;

                Assert.That(startDate, Is.EqualTo(DateTime.Today.AddDays(dayStart).ToString()));
                Assert.That(endDate, Is.EqualTo(DateTime.Today.AddDays(dayEnd).ToString()));
                Assert.That(customer, Is.EqualTo("Jane Doe").IgnoreCase);

                dayStart = dayStart + 4;
                dayEnd = dayEnd + 4;
            }

            Wait(500);
            Driver.Quit();            
        }

        [Test, Order(4)]
        public void HotelBooking_TryCreateRooms_True()
        {
            //Port number varies from computer to computer, if this 404, check if port nr is correct.
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");
            Wait(0);
            Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();
            Wait(0);
            Driver.FindElement(By.XPath("//*[@id='Description']")).SendKeys("SeleniumRoom");
            Wait(0);
            Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[2]/input")).Click();
            Wait(0);

            var roomTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table/tbody/tr")).Count;

            var roomName = Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[" + roomTablerows + "]/td[1]")).Text;

            Assert.That(roomName, Is.EqualTo("SeleniumRoom").IgnoreCase);

            Wait(500);
            Driver.Quit();
        }

        [Test, Order(5)]
        public void HotelBooking_TryDeletingNewlyCreatedRoom()
        {
            //Port number varies from computer to computer, if this 404, check if port nr is correct.
            Driver.Navigate().GoToUrl("https://localhost:12918/Bookings");
            Wait(0);
            bool deleted = false;
            int i = 1;

            Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a")).Click();
            Wait(0);
            var roomTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table/tbody/tr")).Count;
            
            while(deleted == false)
            {
                var roomName = Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[" + i + "]/td[1]")).Text;

                Console.WriteLine(roomName);
                if(roomName == "SeleniumRoom")
                {
                    Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[" + i + "]/td[2]/a[3]")).Click();
                    Wait(0);
                    Driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]")).Click();
                    Wait(0);
                    deleted = true;
                }
                i++;
            }

            var newRoomTablerows = Driver.FindElements(By.XPath("/html/body/div/main/table/tbody/tr")).Count;

            Assert.That(roomTablerows-1, Is.EqualTo(newRoomTablerows));

            Wait(500);
            Driver.Quit();

        }
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
                Thread.Sleep(10);
            }
        }
    }
}
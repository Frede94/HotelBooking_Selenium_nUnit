using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace HotelBooking_Selenium_nUnit
{
    public class Tests
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            //Driver = new FirefoxDriver();
            //Driver = new SafariDriver();
            //Driver = new EdgeDriver();

            Console.WriteLine("Hello World");
        }


        [Test]
        public void OpenBrowser()
        {
            //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");

            Assert.Pass();
        }

        [Test]
        public void Aspnetawesome()
        {
            //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            Console.WriteLine("test1");
            Assert.Pass();
        }

        //[Test]
        //public void HotelBooking()
        //{
        //    //Driver.Navigate().GoToUrl("https://localhost:62964/Bookings");
        //    Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");

        //    Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

        //    Console.WriteLine("test1");
        //    Assert.Pass();
        //}

    }
}
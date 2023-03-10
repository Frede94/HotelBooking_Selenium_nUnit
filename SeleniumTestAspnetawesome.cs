using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace HotelBooking_Selenium_nUnit
{
    [TestFixture]
    public class AspnetAwesomeTests : DriverHelper
    {

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            //Driver = new FirefoxDriver();
            //Driver = new SafariDriver();
            //Driver = new EdgeDriver();
        }


        #region aspnetawesome
        [Test]
        public void Aspnetawesome()
        {
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");

            IWebElement autoCompleteControl = Driver.FindElement(By.Id("ContentPlaceHolder1_Meal"));
            autoCompleteControl.SendKeys("Almo");
            autoCompleteControl.SendKeys(Keys.Return);
            autoCompleteControl.SendKeys(Keys.Enter);
            Wait(2000);
            Driver.FindElement(By.XPath("//div[@id='ContentPlaceHolder1_Meal-dropmenu']//li[text()='Almonds']")).Click();

            //Select Celery AjaxCheckBoxList
            Driver.FindElement(By.CssSelector("#maincont > div:nth-child(3) > div:nth-child(5) > div:nth-child(2) > div.awe-ajaxcheckboxlist-field.awe-field > div > ul > li:nth-child(1) > label > div.o-con")).Click();

            CustomControl.ComboBoxControl("ContentPlaceHolder1_AllMealsCombo", "Almond");

            Assert.Pass();
        }

        /// <summary>
        /// Method to make the execution of test wait, for a specified amount of time.
        /// Purely for the benefit of being able to se, the actions made, 
        /// since the window would close or action would be completed nearly instantly.
        /// Default wait is 500 ms.
        /// </summary>
        /// <param name="time"></param>
        public void Wait(int time)
        {
            if (time > 0)
            {
                Thread.Sleep(time);
            }
            else
            {
                Thread.Sleep(10);
            }
        }

        #region multiple test methods, Opens new window for each test
        //[Test]
        //public void Aspnetawesome_OpenBrowserAndInputAlmondsIntoAutoCompleteField()
        //{
        //    Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");
        //    IWebElement autoCompleteControl = Driver.FindElement(By.Id("ContentPlaceHolder1_Meal"));
        //    autoCompleteControl.SendKeys("Almonds");
        //    autoCompleteControl.SendKeys(Keys.Return);
        //    autoCompleteControl.SendKeys(Keys.Enter);
        //    Assert.Pass();
        //}

        //[Test]
        //public void Aspnetawesome_OpenBrowserAndCheckTheCeleryCheckbox()
        //{
        //    Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");
        //    Driver.FindElement(By.CssSelector("#maincont > div:nth-child(3) > div:nth-child(5) > div:nth-child(2) > div.awe-ajaxcheckboxlist-field.awe-field > div > ul > li:nth-child(1) > label > div.o-con")).Click();

        //    Assert.Pass();
        //}

        //[Test]
        //public void Aspnetawesome_OpenBrowserAndWriteAndSelectAlmondInSearchableCombobox()
        //{
        //    Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");
        //    IWebElement comboControl = Driver.FindElement(By.XPath("//*[@id='ContentPlaceHolder1_AllMealsCombo-awed']"));
        //    comboControl.Clear();
        //    comboControl.SendKeys("Almond");

        //    Driver.FindElement(By.XPath("//div[@id='ContentPlaceHolder1_AllMealsCombo-dropmenu']//li[text()='Almond']")).Click();

        //    Assert.Pass();
        //}
        #endregion
        #endregion

    }
}
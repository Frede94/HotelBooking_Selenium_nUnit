using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking_Selenium_nUnit
{
    public class CustomControl : DriverHelper
    {

        public static void ComboBoxControl(string controlName, string value)
        {
            IWebElement comboControl = Driver.FindElement(By.XPath($"//*[@id='{controlName}-awed']"));
            comboControl.Clear();
            comboControl.SendKeys(value);

            Driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[text()='{value}']")).Click();
        }

    }
}

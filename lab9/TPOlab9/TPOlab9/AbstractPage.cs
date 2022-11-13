using OpenQA.Selenium;
using System;

namespace TPOlab9
{
    public class AbstractPage
    {
        protected WebDriver Driver { get; }
        protected TimeSpan WaitTimeOut = new TimeSpan(0, 0, 10);

        public AbstractPage(WebDriver driver)
        {
            Driver = driver;
        }
    }
}

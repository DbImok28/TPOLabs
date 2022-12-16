using log4net;
using OpenQA.Selenium;
using System;
using TPO_WebTestFramework.Driver;
using TPO_WebTestFramework.Util;

namespace TPO_WebTestFramework.Page
{
    public class AbstractPage
    {
        protected WebDriver Driver { get; }
        protected TimeSpan WaitTimeOut = new TimeSpan(0, 0, 10);
        protected static readonly ILog Log = Log4NetHelper.GetLogger(typeof(AbstractPage));

        public AbstractPage(WebDriver driver)
        {
            Driver = driver;
        }
    }
}

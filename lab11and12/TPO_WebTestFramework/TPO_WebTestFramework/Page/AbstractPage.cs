using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TPO_WebTestFramework.Util;

namespace TPO_WebTestFramework.Page
{
    public class AbstractPage
    {
        protected WebDriver Driver { get; }
        protected TimeSpan WaitTimeOut = new TimeSpan(0, 0, 10);
        protected TimeSpan TryFindWaitTimeOut = new TimeSpan(0, 0, 3);
        protected static readonly ILog Log = Log4NetHelper.GetLogger(typeof(AbstractPage));

        public IWebElement WaitedFind(Func<IWebDriver, IWebElement> condition)
        {
            return new WebDriverWait(Driver, WaitTimeOut).Until(condition);
        }

        public bool WaitedFind(Func<IWebDriver, bool> condition)
        {
            return new WebDriverWait(Driver, WaitTimeOut).Until(condition);
        }

        public IWebElement WaitedFindElement(By by)
        {
            Log.Info($"Find element by: {by}");
            return new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(by));
        }

        public IReadOnlyCollection<IWebElement> WaitedFindElements(By by)
        {
            Log.Info($"Find elements by: {by}");
            return new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElements(by));
        }

        public IWebElement? TryFindElement(Func<IWebDriver, IWebElement> condition)
        {
            try
            {
                return new WebDriverWait(Driver, TryFindWaitTimeOut).Until(condition);
            }
            catch (WebDriverTimeoutException) { }
            catch (NoSuchElementException) { }
            return null;
        }

        public bool? TryFindElement(Func<IWebDriver, bool> condition)
        {
            try
            {
                return new WebDriverWait(Driver, TryFindWaitTimeOut).Until(condition);
            }
            catch (WebDriverTimeoutException) { }
            catch (NoSuchElementException) { }
            return null;
        }

        public IWebElement? TryFindElement(By by)
        {
            Log.Info($"Try find element by: {by}");
            return TryFindElement(d => d.FindElement(by));
        }

        public AbstractPage(WebDriver driver)
        {
            Driver = driver;
        }
    }
}

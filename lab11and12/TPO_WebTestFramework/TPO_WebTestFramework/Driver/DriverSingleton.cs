using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using log4net;
using TPO_WebTestFramework.Util;

namespace TPO_WebTestFramework.Driver
{
    public class DriverSingleton
    {
        private static readonly ILog Log = Log4NetHelper.GetLogger(typeof(DriverSingleton));
        private static WebDriver? Driver;
        private DriverSingleton() { }
        public static WebDriver GetDriver()
        {
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",@"/path/to/where/you/ve/put/chromedriver.exe")
            if (Driver == null)
            {
                var browser = Environment.GetEnvironmentVariable("browser");
                switch (browser)
                {
                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        Driver = new EdgeDriver();
                        break;
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                        break;
                    default:
                        Driver = new ChromeDriver();
                        break;
                }
                Log.Info($"Created {(browser == "" ? "default chrome" : browser)} driver");
                Driver.Manage().Window.Maximize();
            }
            return Driver;
        }
        public static void CloseDriver()
        {
            Driver?.Quit();
            Driver = null;
        }
    }
}

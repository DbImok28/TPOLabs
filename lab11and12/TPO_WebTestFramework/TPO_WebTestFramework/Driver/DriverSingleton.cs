using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using log4net;
using TPO_WebTestFramework.Util;
using System.Drawing;

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

                Driver.Manage().Window.Position = new Point(0, 0);
                Driver.Manage().Window.Size = new Size(1080, 720);
                Driver.Manage().Window.Maximize();
                Log.Info($"Size:{Driver.Manage().Window.Size}");
                Log.Error($"Size:{Driver.Manage().Window.Size}");
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

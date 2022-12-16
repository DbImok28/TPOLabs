using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TPO_WebTestFramework.Driver;
using TPO_WebTestFramework.Util;

namespace TPO_WebTestFramework.Test
{
    public class CommonConditions
    {
        protected static readonly WebDriver Driver = DriverSingleton.GetDriver();
        private static readonly ILog Log = Log4NetHelper.GetLogger(typeof(CommonConditions));

        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                var screenshot = Driver.TakeScreenshot();
                var filePath = "Screenshot_" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ".png";
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                Log.Error($"Test failure, screenshot saved to '{filePath}'");
                throw;
            }
        }
    }
}

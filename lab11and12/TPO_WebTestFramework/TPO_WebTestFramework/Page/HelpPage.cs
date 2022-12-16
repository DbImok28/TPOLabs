using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class HelpPage : AbstractPage
    {
        #region WebElements

        public string HelpContent => WaitedFindElement(By.XPath("//*[@id=\"mainbar\"]/div[2]/div/p[1]")).Text;

        #endregion

        public HelpPage(WebDriver driver) : base(driver) { }
    }
}
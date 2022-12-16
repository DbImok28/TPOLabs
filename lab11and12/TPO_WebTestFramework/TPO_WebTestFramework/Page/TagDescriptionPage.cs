using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class TagDescriptionPage : AbstractPage
    {
        #region WebElements

        public string Description => new WebDriverWait(Driver, new TimeSpan(0, 0, 10)).Until(d => d.FindElement(By.XPath("//*[@id=\"wiki-excerpt\"]/p"))).Text;

        #endregion

        public TagDescriptionPage(WebDriver driver) : base(driver) { }
    }
}
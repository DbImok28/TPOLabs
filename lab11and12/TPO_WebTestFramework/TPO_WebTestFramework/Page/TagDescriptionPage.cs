using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class TagDescriptionPage : AbstractPage
    {
        #region WebElements

        public string Description => WaitedFindElement(By.XPath("//*[@id=\"wiki-excerpt\"]/p")).Text;

        #endregion

        public TagDescriptionPage(WebDriver driver) : base(driver)
        {
            Log.Info($"Opened TagDescriptionPage");
        }
    }
}
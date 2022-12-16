using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class HelpSearchPage : AbstractPage
    {
        #region WebElements

        public IWebElement SearchField => WaitedFindElement(By.XPath("//*[@id=\"bigsearch\"]//input"));

        public List<IWebElement> SearchResult => WaitedFindElements(By.XPath("//*[@id=\"help-index\"]//span/a")).ToList();

        #endregion

        public HelpSearchPage(WebDriver driver) : base(driver) { }

        public HelpSearchPage SearchBySearchTerm(string term)
        {
            SearchField.SendKeys(term);
            SearchField.Submit();
            return this;
        }

        public HelpPage OpenFirstResult()
        {
            SearchResult.First().Click();
            return new HelpPage(Driver);
        }
    }
}
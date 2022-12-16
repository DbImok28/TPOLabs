using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TPO_WebTestFramework.Page
{
    public class HelpSearchPage : AbstractPage
    {
        #region WebElements

        public IWebElement SearchField => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.XPath("//*[@id=\"bigsearch\"]//input")));

        public List<IWebElement> SearchResult => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElements(By.XPath("//*[@id=\"help-index\"]//span/a")))
            .ToList();

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
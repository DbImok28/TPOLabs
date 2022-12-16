using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TPO_WebTestFramework.Page
{
    public class SearchResultsPage : AbstractPage
    {
        public string SearchRequest { get; }

        #region WebElements

        public WebElement UnansweredButtonWebElement
        {
            get
            {
                try
                {
                    new WebDriverWait(Driver, new TimeSpan(0, 0, 10)).Until(d => d.FindElement(By.XPath("//*[@id=\"mainbar\"]/div[4]/div/div[2]/div/div[1]/button"))).Click();
                    return (WebElement)new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id='uql-more-popover']/ul/li[2]/a")));
                }
                catch (ElementNotInteractableException)
                {
                    return (WebElement)new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id=\"uql-form\"]/div/div/div[1]/div/div[3]/div/div/input")));
                }
            }
        }

        public IWebElement FilterByTagField => new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id=\"uql-form\"]/div/div/div[1]/div/div[3]/div/div/input")));

        public IWebElement ApllyFilterButton => new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id=\"uql-form\"]/div/div/div[2]/div/div[1]/button[1]")));

        public IWebElement OpenTagDescriptionPageButton => new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id=\"mainbar\"]/div[3]/div/div/ul/li[1]/a")));

        #endregion

        public SearchResultsPage(WebDriver driver, string searchRequest) : base(driver)
        {
            SearchRequest = searchRequest;
        }

        public SearchResultsPage Search(string request)
        {
            var findInput = new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.ClassName("s-input__search")));
            findInput.SendKeys(request);
            findInput.SendKeys(Keys.Return);
            return this;
        }

        public QuestionPage OpenFirstQuestion()
        {
            var firstQuestionElement = new WebDriverWait(Driver, WaitTimeOut).Until((d) => d.FindElement(By.ClassName("s-link")));
            firstQuestionElement.Click();
            return new QuestionPage(Driver);
        }

        public SearchResultsPage FilterByWithoutAnswer()
        {
            try
            {
                new WebDriverWait(Driver, new TimeSpan(0, 0, 10)).Until(d => d.FindElement(By.XPath("//*[@id=\"mainbar\"]/div[4]/div/div[2]/div/div[1]/button"))).Click();
                new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id='uql-more-popover']/ul/li[2]/a"))).Click();
            }
            catch (ElementNotInteractableException)
            {
                new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//a[@data-nav-value='Unanswered']"))).Click();
            }

            //UnansweredButtonWebElement.Click();
            return this;
        }

        public SearchResultsPage FilterByTag(string filterTag)
        {
            FilterByTagField.SendKeys(filterTag);
            ApllyFilterButton.Click();
            return this;
        }

        public TagDescriptionPage OpenDescriptionPage()
        {
            OpenTagDescriptionPageButton.Click();
            return new TagDescriptionPage(Driver);
        }
    }
}

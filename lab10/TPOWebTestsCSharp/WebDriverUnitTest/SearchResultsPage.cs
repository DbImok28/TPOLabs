using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverUnitTest
{
    public class SearchResultsPage : AbstractPage
    {
        public SearchResultsPage(WebDriver driver, string searchRequest) : base(driver)
        {
            SearchRequest = searchRequest;
        }

        public string SearchRequest { get; }

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
            return this;
        }
    }
}

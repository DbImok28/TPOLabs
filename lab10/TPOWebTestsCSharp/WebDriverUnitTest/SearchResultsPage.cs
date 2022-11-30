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
            new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//a[@data-nav-value='Unanswered']"))).Click();
            return this;
        }
    }
}

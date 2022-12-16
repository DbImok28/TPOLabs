using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TPO_WebTestFramework.Page
{
    public class SearchResultsPage : AbstractPage
    {
        public string SearchRequest { get; }

        #region WebElements

        public IWebElement FilterByTagField => WaitedFindElement(By.XPath("//*[@id=\"uql-form\"]/div/div/div[1]/div/div[3]/div/div/input"));

        public IWebElement ApllyFilterButton => WaitedFindElement(By.XPath("//*[@id=\"uql-form\"]/div/div/div[2]/div/div[1]/button[1]"));

        public IWebElement OpenTagDescriptionPageButton => WaitedFindElement(By.XPath("//*[@id=\"mainbar\"]/div[3]/div/div/ul/li[1]/a"));

        public IWebElement FilterByWithoutAnswerButton
        {
            get
            {
                IWebElement? UnansweredButton = TryFindElement(By.XPath("//a[@data-nav-value='Unanswered']"));
                if (UnansweredButton != null)
                {
                    return UnansweredButton;
                }
                else
                {
                    WaitedFindElement(By.XPath("//*[@id=\"mainbar\"]/div[4]/div/div[2]/div/div[1]/button")).Click();
                    return WaitedFindElement(By.XPath("//*[@id='uql-more-popover']/ul/li[2]/a"));
                }
            }
        }

        #endregion

        public SearchResultsPage(WebDriver driver, string searchRequest) : base(driver)
        {
            SearchRequest = searchRequest;
            Log.Info($"Opened SearchResultsPage");
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
            IWebElement? UnansweredButton = TryFindElement(By.XPath("//a[@data-nav-value='Unanswered']"));
            if (UnansweredButton != null)
            {
                try
                {
                    UnansweredButton.Click();
                    return this;
                }
                catch (Exception) { }
            }
            WaitedFindElement(By.XPath("//*[@id=\"mainbar\"]/div[4]/div/div[2]/div/div[1]/button")).Click();
            WaitedFindElement(By.XPath("//*[@id='uql-more-popover']/ul/li[2]/a")).Click();

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

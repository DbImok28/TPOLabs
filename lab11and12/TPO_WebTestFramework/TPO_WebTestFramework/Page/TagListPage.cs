using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TPO_WebTestFramework.Page
{
    public class TagListPage : AbstractPage
    {
        #region WebElements

        public IWebElement TagFilterInputElement => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("tagfilter")));

        public List<IWebElement> ListOfTagsWebElements => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("tags-browser")))
            .FindElements(By.ClassName("post-tag")).ToList();

        public List<string> ListOfTags => ListOfTagsWebElements
            .Select(x => x.Text)
            .ToList();

        public int PageNumber => Convert.ToInt32(new WebDriverWait(Driver, new TimeSpan(0, 0, 4)).Until(d => d.FindElement(By.XPath("//*[@id=\"tags_list\"]/div[2]/a[5]"))).Text);

        #endregion

        public TagListPage(WebDriver driver) : base(driver) { }

        public TagListPage FindTag(string condition)
        {
            var pageBefore = PageNumber;
            TagFilterInputElement.SendKeys(condition);
            try
            {
                new WebDriverWait(Driver, new TimeSpan(0, 0, 4)).Until(d => PageNumber < pageBefore);
            }
            catch (WebDriverTimeoutException) { }
            return this;
        }

        public SearchResultsPage OpenSearchPageByFirstFindedTag()
        {
            ListOfTagsWebElements.First().Click();
            return new SearchResultsPage(Driver, "");
        }
    }
}

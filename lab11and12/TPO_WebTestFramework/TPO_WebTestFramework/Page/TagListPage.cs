using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class TagListPage : AbstractPage
    {
        #region WebElements

        public IWebElement TagFilterInputElement => WaitedFindElement(By.Id("tagfilter"));

        public List<IWebElement> ListOfTagsWebElements =>
            WaitedFindElement(By.Id("tags-browser"))
            .FindElements(By.ClassName("post-tag")).ToList();

        public List<string> ListOfTags => ListOfTagsWebElements
            .Select(x => x.Text)
            .ToList();

        public int PageNumber => Convert.ToInt32((TryFindElement(By.XPath("//*[@id=\"tags_list\"]/div[2]/a[5]"))?.Text ?? "0"));

        #endregion

        public TagListPage(WebDriver driver) : base(driver) { }

        public TagListPage FindTag(string condition)
        {
            var pageBefore = PageNumber;
            TagFilterInputElement.SendKeys(condition);
            TryFindElement(d => PageNumber < pageBefore);
            return this;
        }

        public SearchResultsPage OpenSearchPageByFirstFindedTag()
        {
            ListOfTagsWebElements.First().Click();
            return new SearchResultsPage(Driver, "");
        }
    }
}

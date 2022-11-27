using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverUnitTest
{
    public class HomePage : AbstractPage
    {
        private readonly string HOMEPAGE_URL = @"https://ru.stackoverflow.com/";

        public HomePage(WebDriver driver) : base(driver) { }

        public HomePage OpenPage()
        {
            Driver.Url = HOMEPAGE_URL;
            return this;
        }

        public SearchResultsPage SearchBySearchTerm(string request)
        {
            return new SearchResultsPage(Driver, request).Search(request);
        }

        public List<IWebElement> ListOfTagWebElement => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("recent-tags-list")))
            .FindElements(By.TagName("a")).ToList();

        public SearchResultsPage SelectTag(string tag)
        {
            ListOfTagWebElement.Find(x => x.Text == tag.ToLower()).Click();
            return new SearchResultsPage(Driver, "[" + tag + "]");
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TPO_WebTestFramework.Page
{
    public class UserListPage : AbstractPage
    {
        #region WebElements

        public IWebElement UserFilterInputElement => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("userfilter")));

        public List<string> ListOfUsernames => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("user-browser")))
            .FindElements(By.XPath("//*[@class='user-details']/a"))
            .Select(x => x.Text)
            .ToList();

        //public string? PageNumber => new WebDriverWait(Driver, WaitTimeOut).Until(d => d.FindElement(By.XPath("//*[@id=\"user-browser\"]/div[2]/a[5]"))).Text;

        public int PageNumber => Convert.ToInt32(new WebDriverWait(Driver, new TimeSpan(0, 0, 4)).Until(d => d.FindElement(By.XPath("//*[@id=\"user-browser\"]/div[2]/a[5]"))).Text);

        #endregion

        public UserListPage(WebDriver driver) : base(driver) { }

        public UserListPage FindUser(string condition)
        {
            var pageBefore = PageNumber;
            UserFilterInputElement.SendKeys(condition);
            try
            {
                new WebDriverWait(Driver, new TimeSpan(0, 0, 4)).Until(d => PageNumber < pageBefore);
            }
            catch (WebDriverTimeoutException) { }
            return this;
        }
    }
}
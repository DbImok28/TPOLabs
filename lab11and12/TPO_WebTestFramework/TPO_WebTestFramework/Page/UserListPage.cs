using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class UserListPage : AbstractPage
    {
        #region WebElements

        public IWebElement UserFilterInputElement => WaitedFindElement(By.Id("userfilter"));

        public List<string> ListOfUsernames =>
            WaitedFindElement(By.Id("user-browser"))
            .FindElements(By.XPath("//*[@class='user-details']/a"))
            .Select(x => x.Text)
            .ToList();

        public int PageNumber => Convert.ToInt32((TryFindElement(By.XPath("//*[@id=\"user-browser\"]/div[2]/a[5]"))?.Text ?? "0"));

        #endregion

        public UserListPage(WebDriver driver) : base(driver)
        {
            Log.Info($"Opened UserListPage");
        }

        public UserListPage FindUser(string condition)
        {
            var pageBefore = PageNumber;
            UserFilterInputElement.SendKeys(condition);
            TryFindElement(d => PageNumber < pageBefore);
            Log.Info($"Finding user: {condition}");

            return this;
        }
    }
}
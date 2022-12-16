using OpenQA.Selenium;

namespace TPO_WebTestFramework.Page
{
    public class HomePage : AbstractPage
    {
        private readonly string HOMEPAGE_URL = @"https://ru.stackoverflow.com/";

        #region WebElements

        public IWebElement RightMenuButtonElement => WaitedFindElement(By.ClassName("js-left-sidebar-toggle"));

        public IWebElement OpenTagPageButtonElement => WaitedFindElement(By.Id("nav-tags"));

        public IWebElement OpenUserPageButtonElement => WaitedFindElement(By.Id("nav-users"));

        public IWebElement LoginButton => WaitedFindElement(By.XPath("/html/body/header/div/nav/ol/li[5]/a"));

        public IWebElement CreateUserFilterButtonElement => WaitedFindElement(By.XPath("//*[@id=\"sidebar\"]/div[2]/ul/li/a"));

        public IWebElement OpenHelpPageButton => WaitedFindElement(By.XPath("//*[@id=\"footer\"]/div/nav/div[1]/ul/li[2]/a"));

        public List<IWebElement> ListOfTagWebElement =>
            WaitedFindElement(By.Id("recent-tags-list"))
            .FindElements(By.TagName("a"))
            .ToList();

        #endregion

        #region Methods

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

        public SearchResultsPage SelectTag(string tag)
        {
            ListOfTagWebElement.Find(x => x.Text == tag.ToLower())?.Click();
            return new SearchResultsPage(Driver, "[" + tag + "]");
        }

        public void OpenRightMenu()
        {
            try
            {
                RightMenuButtonElement.Click();
            }
            catch (Exception) { }
        }

        public TagListPage OpenTagListPage()
        {
            OpenRightMenu();
            OpenTagPageButtonElement.Click();
            return new TagListPage(Driver);
        }

        public UserListPage OpenUserListPage()
        {
            OpenRightMenu();
            OpenUserPageButtonElement.Click();

            return new UserListPage(Driver);
        }

        public LoginPage OpenLoginPage()
        {
            LoginButton.Click();
            return new LoginPage(Driver);
        }

        public SearchResultsPage CreateUserFilter()
        {
            CreateUserFilterButtonElement.Click();
            return new SearchResultsPage(Driver, "");
        }

        public HelpSearchPage OpenHelpPage()
        {
            OpenHelpPageButton.Click();
            return new HelpSearchPage(Driver);
        }

        #endregion
    }
}

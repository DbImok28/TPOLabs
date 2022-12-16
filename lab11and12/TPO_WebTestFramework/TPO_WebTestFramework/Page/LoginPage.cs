using OpenQA.Selenium;
using TPO_WebTestFramework.Model;

namespace TPO_WebTestFramework.Page
{
    public class LoginPage : AbstractPage
    {
        #region WebElements

        public IWebElement EmailTextField => WaitedFindElement(By.Id("email"));

        public IWebElement PasswordTextField => WaitedFindElement(By.Id("password"));

        public IWebElement SubmitLoginButton => WaitedFindElement(By.Id("submit-button"));

        #endregion

        public LoginPage(WebDriver driver) : base(driver)
        {
            Log.Info($"Opened LoginPage");
        }

        public LoginPage EnterCredentials(User user)
        {
            EmailTextField.SendKeys(user.UserName);
            PasswordTextField.SendKeys(user.Password);
            return this;
        }

        public HomePage Login()
        {
            SubmitLoginButton.Click();
            return new HomePage(Driver);
        }
    }
}
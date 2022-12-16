using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TPO_WebTestFramework.Model;

namespace TPO_WebTestFramework.Page
{
    public class LoginPage : AbstractPage
    {
        #region WebElements

        public IWebElement EmailTextField => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("email")));

        public IWebElement PasswordTextField => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("password")));

        public IWebElement SubmitLoginButton => new WebDriverWait(Driver, WaitTimeOut)
           .Until(d => d.FindElement(By.Id("submit-button")));

        #endregion

        public LoginPage(WebDriver driver) : base(driver) { }

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
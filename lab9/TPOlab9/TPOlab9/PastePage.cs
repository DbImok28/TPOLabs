using OpenQA.Selenium;
using System.Threading;

namespace TPOlab9
{
    public class PastePage : AbstractPage
    {
        public PastePage(WebDriver driver) : base(driver) { }

        public string PageTitle => Driver.FindElement(By.TagName("title")).Text;

        public void WritePasteCode(string code)
        {
            Driver.FindElement(By.Id("postform-text")).SendKeys(code);
        }
        public void WritePasteNameAndTitle(string name)
        {
            Driver.FindElement(By.Id("postform-name")).SendKeys(name);
        }
        public void SetPasteExpiration(string expiration)
        {
            Driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[4]/div/span/span[1]/span")).Click();
            Driver.FindElement(By.XPath($"//*[@id=\"select2-postform-expiration-results\"]/*[text()='{expiration}']")).Click();
        }
        public void SetHighlighting(string highlighting)
        {
            Driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[3]/div/span")).Click();
            Driver.FindElement(By.ClassName("select2-search__field")).SendKeys(highlighting);
        }
        public void CreateNewPaste()
        {
            Driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[10]/button")).Click();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TPO_WebTestFramework.Page
{
    public class QuestionPage : AbstractPage
    {
        #region WebElements

        public string Header => new WebDriverWait(Driver, WaitTimeOut).Until((d) => d.FindElement(By.ClassName("question-hyperlink"))).Text;

        public List<IWebElement>? Answers => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("answers")))
            .FindElements(By.ClassName("answer"))
            .ToList();

        public List<int>? AnswersUproveList => Answers?.Select(x => Convert.ToInt32(x.FindElement(By.XPath("//div[@itemprop='upvoteCount']")).Text)).ToList();

        public List<string> Tags => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElements(By.ClassName("post-tag")))
            .Select(x => x.Text)
            .ToList();

        #endregion

        public QuestionPage(WebDriver driver) : base(driver) { }

        public bool IsAnswered()
        {
            if (Answers == null || Answers.Count == 0) return false;
            return AnswersUproveList?.Find(x => x != 0) != null;
        }
    }
}

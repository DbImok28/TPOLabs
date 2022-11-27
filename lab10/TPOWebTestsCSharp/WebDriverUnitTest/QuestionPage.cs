using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverUnitTest
{
    public class QuestionPage : AbstractPage
    {
        public QuestionPage(WebDriver driver) : base(driver) { }

        public string Header => new WebDriverWait(Driver, WaitTimeOut).Until((d) => d.FindElement(By.ClassName("question-hyperlink"))).Text;

        public List<IWebElement> Answers => new WebDriverWait(Driver, WaitTimeOut)
            .Until(d => d.FindElement(By.Id("answers")))
            ?.FindElements(By.ClassName("answer")).ToList();

        public bool IsAnswered()
        {
            if (Answers.Count == 0) return false;
            return Answers.Find(x => x.FindElement(By.XPath("//div[@itemprop='upvoteCount']")).Text != "0") != null;
        }
    }
}

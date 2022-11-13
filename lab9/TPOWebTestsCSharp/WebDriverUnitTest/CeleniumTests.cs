using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverUnitTest
{
    [TestClass]
    public class CeleniumTests
    {
        [TestMethod]
        public void QuestionSearchTest()
        {
            WebDriver driver = new ChromeDriver
            {
                Url = @"https://ru.stackoverflow.com/"
            };

            var findInput = driver.FindElement(By.ClassName("s-input__search"));
            findInput.SendKeys("C++ emplace_back");
            findInput.SendKeys(Keys.Return);

            var firstQuestion = new WebDriverWait(driver, new TimeSpan(0,0,10))
                .Until((d) => d.FindElement(By.ClassName("s-link")));
            firstQuestion.Click();

            var questionHeader = new WebDriverWait(driver, new TimeSpan(0, 0, 10))
                .Until((d) => d.FindElement(By.ClassName("question-hyperlink")));
            string questionHeaderText = questionHeader.Text;
            driver.Quit();

            Assert.IsTrue(questionHeaderText == "emplace_back для шаблонного конструктора");
        }
    }
}

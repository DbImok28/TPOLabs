using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverUnitTest
{
    [TestClass]
    public class CeleniumTests
    {
        public static WebDriver driver;

        [TestInitialize()]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
        }

        [TestMethod]
        public void QuestionSearchTest()
        {
            // 1
            var questionHeader = new HomePage(driver).OpenPage().SearchBySearchTerm("C++ emplace_back").OpenFirstQuestion().Header;
            Assert.AreEqual("emplace_back для шаблонного конструктора", questionHeader);
        }

        [TestMethod]
        public void FindQuestionWithoutAnswerTest()
        {
            // 2
            var isAnswered = new HomePage(driver).OpenPage().SelectTag("Java").FilterByWithoutAnswer().OpenFirstQuestion().IsAnswered();
            Assert.IsFalse(isAnswered);
        }
    }
}

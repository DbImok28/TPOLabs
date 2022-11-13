using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using System;
using System.Threading;

namespace TPOlab9
{
    [TestClass]
    public class PastebinTests
    {
        public static WebDriver driver;

        [TestInitialize()]
        public void Initialize()
        {
            driver = new ChromeDriver()
            {
                Url = "https://pastebin.com"
            };
        }

        [TestCleanup()]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
        }
        [TestMethod]
        public void ICanWin()
        {
            PastePage pastePage = new PastePage(driver);
            pastePage.WritePasteCode("Hello from WebDriver");
            pastePage.SetPasteExpiration("10 Minutes");
            pastePage.WritePasteNameAndTitle("helloweb");
            Assert.IsTrue(true);
        }

        /*
        3. Сохранить paste и проверить следующее:
        * Заголовок страницы браузера соответствует Paste Name / Title
        * Синтаксис подвечен для bash
        * Проверить что код соответствует введенному в пункте 2*/

        [TestMethod]
        public void BringItOn()
        {
            PastePage pastePage = new PastePage(driver);
            pastePage.WritePasteCode("git config --global user.name \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\ngit push origin master --force");
            pastePage.SetHighlighting("Bash");
            pastePage.SetPasteExpiration("10 Minutes");
            pastePage.WritePasteNameAndTitle("how to gain dominance among developers");
            pastePage.CreateNewPaste();

            Assert.AreEqual("how to gain dominance among developers", pastePage.PageTitle);
        }
    }
}

using TPO_WebTestFramework.Driver;
using TPO_WebTestFramework.Page;
using TPO_WebTestFramework.Service;

namespace TPO_WebTestFramework.Test
{
    [TestClass]
    public class CeleniumTests : CommonConditions
    {
        [ClassCleanup()]
        public static void Cleanup()
        {
            DriverSingleton.CloseDriver();
        }

        // 1
        [TestMethod]
        public void QuestionSearchTest()
        {
            UITest(() =>
            {
                var questionHeader = new HomePage(Driver)
                    .OpenPage()
                    .SearchBySearchTerm("C++ emplace_back")
                    .OpenFirstQuestion()
                    .Header;
                Assert.AreEqual("emplace_back для шаблонного конструктора", questionHeader);
            });
        }

        // 2
        [TestMethod]
        public void FindQuestionWithoutAnswerTest()
        {
            UITest(() =>
            {
                var isAnswered = new HomePage(Driver)
                .OpenPage()
                .SelectTag("Java")
                .FilterByWithoutAnswer()
                .OpenFirstQuestion()
                .IsAnswered();
                Assert.IsFalse(isAnswered);
            });
        }

        // 3
        [TestMethod]
        public void FindTagByNameTest()
        {
            string expected = "mysql";
            UITest(() =>
            {
                var Tags = new HomePage(Driver)
                .OpenPage()
                .OpenTagListPage()
                .FindTag(expected)
                .ListOfTags;
                Assert.IsTrue(Tags.Contains(expected));
            });
        }

        // 4
        [TestMethod]
        public void FindUserByNameTest()
        {
            string expected = "DbImok";
            UITest(() =>
            {
                var Usernames = new HomePage(Driver)
                .OpenPage()
                .OpenUserListPage()
                .FindUser(expected)
                .ListOfUsernames;
                Assert.IsTrue(Usernames.Contains(expected));
            });
        }

        // 5
        [TestMethod]
        public void FindQuestionUsingUserFilterTest()
        {
            var user = UserCreator.WithCredentialsFromProperty();
            string expected = "python";

            UITest(() =>
            {
                var QuestionTagList = new HomePage(Driver)
                .OpenPage()
                .OpenLoginPage()
                .EnterCredentials(user)
                .Login()
                .CreateUserFilter()
                .FilterByTag(expected)
                .OpenFirstQuestion()
                .Tags;
                Assert.IsTrue(QuestionTagList.Contains(expected));
            });
        }

        // 6
        [TestMethod]
        public void FindTagDescriptionTest()
        {
            UITest(() =>
            {
                string description = new HomePage(Driver)
                .OpenPage()
                .OpenTagListPage()
                .FindTag("javascript")
                .OpenSearchPageByFirstFindedTag()
                .OpenDescriptionPage()
                .Description;
                Assert.IsTrue(description.Contains("динамический, интерпретируемый язык"));
            });
        }

        // 7
        [TestMethod]
        public void FindHelpAboutTagsTest()
        {
            UITest(() =>
            {
                string HelpContent = new HomePage(Driver)
                .OpenPage()
                .OpenHelpPage()
                .SearchBySearchTerm("Что такое метки и как их использовать?")
                .OpenFirstResult()
                .HelpContent;
                Assert.IsTrue(HelpContent.Contains("Метка – это"));
            });
        }
    }
}

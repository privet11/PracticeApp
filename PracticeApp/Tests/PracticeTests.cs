using NUnit.Framework;
using PracticeApp.Assembly;
using PracticeApp.Pages;
using System;

namespace PracticeApp
{
    [TestFixture]
    public class PracticeTests: PagesGet
    {

        [TestCase(4,1,3)]
        public void AddsTest(int expectedSumResult, int firstValue, int secondValue)
        {
            Assert.AreEqual(expectedSumResult, Actions.Sum(firstValue, secondValue));
        }

        [TestCase("Cat","German","Katze")]
        [TestCase("Dog", "German", "Hund")]
        [TestCase("Cat", "French", "Chatte")]
        public void TranslationTest(string translationWord, string language,string expectedTranslation)
        {
            GetPages<GoogleTranslatePage>().OutputMoreLanguagesButtonClick();
            GetPages<GoogleTranslatePage>().SelectLanguage(language);
            GetPages<GoogleTranslatePage>().InputTranslationWord(translationWord);
            Assert.AreEqual(expectedTranslation, GetPages<GoogleTranslatePage>().GetTranslation());
        }

        [TearDown]
        public void TearDownMethod()
        {
            Driver.WebDriver.Close();
            Driver.WebDriver = null;
        }
    }
}

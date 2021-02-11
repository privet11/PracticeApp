using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticeApp.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeApp.Pages
{
    public class GoogleTranslatePage:Driver
    {
        private readonly IWebElement inputField = WebDriver.FindElement(By.XPath("//textarea[@aria-label='Source text']"));
        private IWebElement outputField;
        private readonly IWebElement inputMoreLanguagesButton = WebDriver.FindElement(By.XPath("//button[@jsname='RCbdJd']"));
        private readonly IWebElement outputMoreLanguagesButton = WebDriver.FindElement(By.XPath("//button[@jsname='zumM6d']"));
        private readonly IList<IWebElement> languagesList = WebDriver.FindElements(By.XPath("//div[contains(@class,'PxXj2d')]"));

        public void InputMoreLanguagesButtonClick() => inputMoreLanguagesButton.Click();
        public void OutputMoreLanguagesButtonClick() => outputMoreLanguagesButton.Click();
        public void SelectLanguage(string language) => languagesList.Where
                                (element => element.Text == language).FirstOrDefault().Click();
        public void InputTranslationWord(string translationWord) => 
                                                     inputField.SendKeys(translationWord);

        public string GetTranslation()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.XPath("//span[@jsname='jqKxS']")));
            return WebDriver.FindElement(By.XPath("//span[@jsname='jqKxS']")).Text;
        }
    }
}

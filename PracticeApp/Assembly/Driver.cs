using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Assembly
{
    public class Driver
    {
        private static IWebDriver webDriver = null;
        private static string baseUrl = "https://translate.google.com/";

        public static IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    webDriver.Navigate().GoToUrl(baseUrl);
                }
                return webDriver;
            }
            set 
            {
                webDriver = value;
            }
        
        }

    }
}

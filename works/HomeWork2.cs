using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works
{
  class HomeWork2
  {

    private static IWebDriver chrome;
    private static IWebDriver firefox;

    [OneTimeSetUp]

    public static void OneTimeSetUp()
    {
      chrome = new ChromeDriver();
      chrome.Manage().Window.Maximize();
      chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      chrome.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";

      firefox = new FirefoxDriver();
      firefox.Manage().Window.Maximize();
      firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      firefox.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";

    }

    [OneTimeTearDown]

    public static void OneTimeTearDown()
    {
      chrome.Quit();
      firefox.Quit();
    }

    [TestCase("Chrome 92 on Windows 10", "Firefox 91 on Windows 10")]

    public static void ChromeBrowserAndLocalOS(string ChromeBrowser, string FireFoxBrowser) 
    {
      IWebElement ChromeAndOS = chrome.FindElement(By.CssSelector("#primary-detection > div"));
      IWebElement firefoxAndOS = firefox.FindElement(By.CssSelector(".simple-major"));
     
      Assert.AreEqual(ChromeBrowser, ChromeAndOS.Text, "Chrome browser and Operation system do not match!");
      Assert.AreEqual(FireFoxBrowser, firefoxAndOS.Text, "FireFox browser and Operation system do not match!");
      
    }

  }
}

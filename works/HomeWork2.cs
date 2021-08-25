using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using System;

namespace works
{
  class HomeWork2
  {
    private static IWebDriver Browser;

    [TestCase("Chrome", "Chrome 92", TestName = "Chrome Browser")]
    [TestCase("Firefox", "Firefox 91", TestName = "FireFox Browser")]
   

    public static void BrowserAndLocalOS(string compare, string browserName)
    {

      if ("Chrome".Equals(compare))
      {
        Browser = new ChromeDriver();
      }
      else if ("Firefox".Equals(compare))
      {
        Browser = new FirefoxDriver();
      }
      


      Browser.Manage().Window.Maximize();
      Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      Browser.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");

      IWebElement BrowserAndOS = Browser.FindElement(By.CssSelector("#primary-detection > div"));


      Assert.IsTrue(BrowserAndOS.Text.Contains(browserName), $"Browser is not {compare}");
      Browser.Quit();
    }

  }
}

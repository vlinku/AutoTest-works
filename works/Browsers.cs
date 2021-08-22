using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works
{
  class Browsers
  {
    [Test]
    public static void TestChrome()
    {
      IWebDriver chrome = new ChromeDriver();
      chrome.Url = "https://login.yahoo.com/";
      chrome.Quit();
    }

    [Test]
    public static void TestFirefox()
    {
      IWebDriver firefox = new FirefoxDriver();
      firefox.Url = "https://login.yahoo.com/";
      firefox.Quit();
    }

    [Test]
    public static void TestYahooPage()
    {
      IWebDriver chrome = new ChromeDriver();
      chrome.Url = "https://login.yahoo.com/";
      //IWebElement usernameInputField = chrome.FindElement(By.Id("login-username"));
      //IWebElement usernameInputField = chrome.FindElement(By.Id("login-username"));
      IWebElement usernameInputField = chrome.FindElement(By.XPath("//*[@id='login-username']"));
      usernameInputField.SendKeys("test");
      IWebElement nextButton = chrome.FindElement(By.CssSelector("#login-signin"));
      nextButton.Click();
      //chrome.FindElement(By.CssSelector("#login-signin")).Click();
    }

    [Test]
    public static void TestSingleInputField()
    {
      IWebDriver chrome = new ChromeDriver();
      chrome.Manage().Window.Maximize();
      chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

      chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";


      WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
      wait.Until(driver => driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
      chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();


      String myText = "katinukai";
      IWebElement inputField = chrome.FindElement(By.XPath("//input[@id='user-message']"));
      //IWebElement inputField = chrome.FindElement(By.Id("user-message"));         
      inputField.SendKeys(myText);


      //IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
      IWebElement button = chrome.FindElement(By.CssSelector(".btn.btn-default"));
      button.Click();


      IWebElement resultElement = chrome.FindElement(By.Id("display"));
      Assert.AreEqual(myText, resultElement.Text, "Text was wrong");
    }

  }
}

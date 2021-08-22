using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works
{
  class HomeWork1
  {
    private static IWebDriver chrome;

    [OneTimeSetUp]

     public static void OneTimeSetUp() 
    { 
     chrome = new ChromeDriver();
      chrome.Manage().Window.Maximize();
      chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
      chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
      WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
      wait.Until(driver => driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
      chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();
    }
    
    [OneTimeTearDown]

    public static void OneTimeTearDown() 
    {
      
      chrome.Quit();
    }

    // --------------------------  Namu darbai 1 ------- 2 + 2 -----------------------
    [Test]
    public static void TestTwoPlusTwo()
    {

      
      String EnterA = "2";
      IWebElement inputA = chrome.FindElement(By.Id("sum1"));
      inputA.SendKeys(EnterA);
      

      String EnterB = "2";
      IWebElement inputB = chrome.FindElement(By.Id("sum2"));
      inputB.SendKeys(EnterB);

      IWebElement button = chrome.FindElement(By.XPath("//*[@id='gettotal']/button"));
      button.Click();

      IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
      Assert.AreEqual("4", resultElement.Text, "Text was wrong");
    }

    // --------------------------  Namu darbai 1 ------- -5 + 3 -----------------------
    [Test]
    public static void TestMinusFivePlusThree()
    {
     

      String EnterA = "-5";
      IWebElement inputA = chrome.FindElement(By.Id("sum1"));
      inputA.SendKeys(EnterA);

      String EnterB = "3";
      IWebElement inputB = chrome.FindElement(By.Id("sum2"));
      inputB.SendKeys(EnterB);

      IWebElement button = chrome.FindElement(By.XPath("//*[@id='gettotal']/button"));
      button.Click();

      IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
      Assert.AreEqual("-2", resultElement.Text, "Text was wrong");
    }

    // --------------------------  Namu darbai 1 ------- a + b -----------------------
    [Test]
    public static void TestAPlusB()
    {
    

      String EnterA = "a";
      IWebElement inputA = chrome.FindElement(By.Id("sum1"));
      inputA.SendKeys(EnterA);

      String EnterB = "b";
      IWebElement inputB = chrome.FindElement(By.Id("sum2"));
      inputB.SendKeys(EnterB);

      IWebElement button = chrome.FindElement(By.XPath("//*[@id='gettotal']/button"));
      button.Click();

      IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
      Assert.AreEqual("NaN", resultElement.Text, "Text was wrong!");
    }

  }
}

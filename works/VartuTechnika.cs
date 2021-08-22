using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works
{
  class VartuTechnika
  {
    private static IWebDriver chrome;


    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
      chrome = new ChromeDriver();
      chrome.Manage().Window.Maximize();
      chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      chrome.Url = "http://vartutechnika.lt/";

      chrome.FindElement(By.Id("cookiescript_accept")).Click();
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
      chrome.Quit();
    }

    [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
    [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
    [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 x 2000 = 692.35€")]
    [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]
    public static void TestVartuTechnika(string width, string height, bool auto, bool works, string result)
    {
      IWebElement widthInputField = chrome.FindElement(By.Id("doors_width"));
      IWebElement heightInputField = chrome.FindElement(By.Id("doors_height"));

      IWebElement autoCheckbox = chrome.FindElement(By.Id("automatika"));
      IWebElement workCheckbox = chrome.FindElement(By.Id("darbai"));


      IWebElement calculateButton = chrome.FindElement(By.Id("calc_submit"));

      widthInputField.Clear();
      widthInputField.SendKeys(width);

      heightInputField.Clear();
      heightInputField.SendKeys(height);

      if (autoCheckbox.Selected != auto)
      {
        autoCheckbox.Click();
      }
      if (workCheckbox.Selected != works)
      {
        workCheckbox.Click();
      }

      calculateButton.Click();

      string resultText = chrome.FindElement(By.CssSelector("#calc_result > div > strong")).Text;

      Assert.IsTrue(resultText.Contains(result), "Result is wrong");
    }
  }
}

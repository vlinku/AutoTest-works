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
  class CheckBoxDemo
  {
    private static IWebDriver chrome;

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
      chrome = new ChromeDriver();
      chrome.Manage().Window.Maximize();
      chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      chrome.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
      chrome.Quit();
    }

    [Test]
    public static void FirstCheckbox()
    {
      PrepareCheckbox(true);
      string resultText = chrome.FindElement(By.Id("txtAge")).Text;
      Assert.AreEqual("Success - Check box is checked", resultText, "Text is wrong");
    }

    [Test]
    public static void MultipleCheckboxTest()
    {
      PrepareCheckbox(false);
      PrepareMultipleCheckbxes();

      IWebElement button = chrome.FindElement(By.Id("check1"));
      //Assert.IsTrue("Uncheck AllX".Equals(button.GetAttribute("value")), "Value is not correct");

      Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")),
          $"Value is not correct, expected 'Uncheck All', but was {button.GetAttribute("value")}");

    }

    [Test]
    public static void UncheckboxAllCheckbox()
    {
      PrepareCheckbox(false);
      PrepareMultipleCheckbxes();

      IWebElement button = chrome.FindElement(By.Id("check1"));
      button.Click();

      foreach (IWebElement checkbox in GetCheckboxCollection())
      {
        Assert.IsFalse(checkbox.Selected);
      }
      Assert.IsTrue("Check All".Equals(button.GetAttribute("value")),
         $"Value is not correct, expected 'Check All', but was {button.GetAttribute("value")}");
    }

    private static IReadOnlyCollection<IWebElement> GetCheckboxCollection()
    {
      return chrome.FindElements(By.CssSelector(".cb1-element"));
    }

    private static void PrepareCheckbox(bool shouldBeChecked)
    {
      IWebElement firstCheckbox = chrome.FindElement(By.Id("isAgeSelected"));

      if (shouldBeChecked != firstCheckbox.Selected)
      {
        firstCheckbox.Click();
      }
    }

    private static void PrepareMultipleCheckbxes()
    {
      IReadOnlyCollection<IWebElement> checkboxCollection = GetCheckboxCollection();
      foreach (IWebElement checkbox in checkboxCollection)
      {
        if (!checkbox.Selected)
        {
          checkbox.Click();
        }
      }
    }

    private static bool Exists(By locatorName)
    {
      return chrome.FindElements(locatorName).Count > 0;
    }
  }
}

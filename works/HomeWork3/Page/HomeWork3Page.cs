using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using works.HomeWork3.Page;

namespace works.Page
{
  public class HomeWork3Page : BasePage
  {

    private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
    private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));
    private IWebElement resultFromPage => Driver.FindElement(By.Id("displayvalue"));

    public HomeWork3Page(IWebDriver webdriver) : base(webdriver) { }

    public void LightBoxClose()
    {
      WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
      wait.Until(Driver => Driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
      Driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
    }

    public void FirstInputField(string firstInput)
    {
      firstInputField.Clear();
      firstInputField.SendKeys(firstInput);
    }

    public void SecondInputField(string secondInput)
    {
      secondInputField.Clear();
      secondInputField.SendKeys(secondInput);
    }

    public void ClickGetTotal(string result)
    {
      Driver.FindElement(By.CssSelector("#gettotal > button")).Click();
    }

    public void VerifyResult(string result)
    {
      Assert.IsTrue(resultFromPage.Text.Contains(result), "Result is wrong");
    }

  }
}

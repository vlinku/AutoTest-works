using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.HomeWork4.Page
{
  class HW4Page : HW4Base
  {
    private const string AddressUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";
    private SelectElement carsDropdown => new SelectElement(Driver.FindElement(By.Id("cars")));
    private IWebElement submitButton => Driver.FindElement(By.CssSelector("body > form > input[type=submit]"));
    private IWebElement acceptCookiesButton => Driver.FindElement(By.Id("accept-choices"));
    private IWebElement resultField => Driver.FindElement(By.CssSelector(".w3-container.w3-large.w3-border"));
    private IWebElement runButton => Driver.FindElement(By.CssSelector(".w3-button.w3-bar-item.w3-hover-white.w3-hover-text-green"));
    public HW4Page(IWebDriver webdriver) : base(webdriver) { }

    public void NavigateToPage()
    {
      if (Driver.Url != AddressUrl)
      {
        Driver.Url = AddressUrl;
      }
    }

    public void AcceptCookies()
    {
      acceptCookiesButton.Click();
    }

    public void SelectFromDropDownByValue(List<string> cars)
    {
      Driver.SwitchTo().Frame("iframeResult");
      carsDropdown.DeselectAll();
      Actions action = new Actions(Driver);
      action.KeyDown(Keys.Control);
      foreach (IWebElement option in carsDropdown.Options)
      {
        if (cars.Contains(option.Text) && !option.Selected)
        {
          option.Click();
        }
      }
      action.KeyUp(Keys.Control);
      action.Build().Perform();
    }

    public void ClickSubmitButton()
    {
      submitButton.Click();
    }

    public void VerifyResult(List<string> cars)
    {
      WaitForResult();
      foreach (string car in cars)
      {
        Assert.IsTrue(resultField.Text.Contains(car.ToLower()),
            $"Result is wrong, was {resultField.Text}, but expected to contain {car}");
      }
    }

    public void RerunPageScript()
    {
      Driver.SwitchTo().DefaultContent();
      runButton.Click();
    }
    private void WaitForResult()
    {
      Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
  }
}

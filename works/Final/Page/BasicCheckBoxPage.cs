using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.Final.Page
{
 public  class BasicCheckBoxPage : BasePage
  {
    private const string PageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

    private IWebElement _singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));

    private IWebElement _singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));

    private const string SingleCheckBoxMessageText = "Success - Check box is checked";

    private IReadOnlyCollection<IWebElement> _multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));

    private IWebElement _checkAllButton => Driver.FindElement(By.Id("check1"));


    public BasicCheckBoxPage(IWebDriver webdriver) : base(webdriver)
    { }

    public BasicCheckBoxPage NavigateToPage()
    {
      if (Driver.Url != PageAddress)
        Driver.Url = PageAddress;
      return this;
    }

    public BasicCheckBoxPage CheckSingleCheckBox()
    {
      if (!_singleCheckBox.Selected)
        _singleCheckBox.Click();
      return this;
    }

    public BasicCheckBoxPage UnCheckSingleCheckBox()
    {
      if (_singleCheckBox.Selected)
        _singleCheckBox.Click();
      return this;
    }

    public BasicCheckBoxPage AssertSingleCheckBoxDemoSuccessMessage()
    {

      Assert.AreEqual(SingleCheckBoxMessageText, _singleCheckBoxMessage.Text, "tekstas nesutampa!");

      return this;
    }

    public BasicCheckBoxPage AssertSingleCheckBoxDemoSuccessMessageWithWait()
    {
      Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      Assert.AreEqual(SingleCheckBoxMessageText, _singleCheckBoxMessage.Text, "tekstas nesutampa!");

      return this;
    }


    public BasicCheckBoxPage CheckAllMultipleCheckBoxes()
    {
      foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
      {
        if (!singleCheckbox.Selected)
          singleCheckbox.Click();
      }
      return this;
    }

    public BasicCheckBoxPage AssertButtonName(string expectedName)
    {

      Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      Assert.AreEqual(expectedName, _checkAllButton.GetAttribute("value"), "Wrong button label");
      return this;
    }


    public BasicCheckBoxPage ClickGroupButton()
    {
      _checkAllButton.Click();
      return this;
    }

    public BasicCheckBoxPage AssertMultipleCheckBoxesUnchecked()
    {
      foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
      {
        Assert.False(singleCheckbox.Selected, "One of checkboxes is still checked!");
      }

      return this;
    }

  }
}

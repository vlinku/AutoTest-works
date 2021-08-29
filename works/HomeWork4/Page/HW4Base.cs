using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace works.HomeWork4.Page
{
  class HW4Base
  {
    protected IWebDriver Driver;

    public HW4Base(IWebDriver webdriver)
    {
      Driver = webdriver;

    }

    public void CloseBrowser()
    {
      Driver.Quit();
    }
    public WebDriverWait GetWait(int seconds = 10)
    {
      return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
    }
  }
}

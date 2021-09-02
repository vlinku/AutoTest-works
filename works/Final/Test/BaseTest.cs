using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using works.Final.Page;
using works.Final.Test;
using works.Final.Tools;

namespace works.Final.Test
{
  public class BaseTest
  {
    public static IWebDriver driver;
    public static BasicCheckBoxPage _page;


    [OneTimeSetUp]
    public static void SetUp()
    {
      driver = CustomDriver.GetChromeDriver();

      _page = new BasicCheckBoxPage(driver);
    }

    [TearDown]
    public static void TakeScreeshot()
    {
      if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        MyScreenshot.MakeScreeshot(driver);
    }

    [OneTimeTearDown]
    public static void TearDown()
    {
      driver.Quit();
    }
  }
}

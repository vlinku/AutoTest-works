using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using works.Page;

namespace works.Test
{
  public class HomeWork3Test
  {

    private static HomeWork3Page page;

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
      IWebDriver Driver = new ChromeDriver();
      page = new HomeWork3Page(Driver);
      Driver.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
      Driver.Manage().Window.Maximize();
      page.LightBoxClose();

    }

    [OneTimeTearDown]
    public static void CloseBrowser()
    {
      page.CloseBrowser();
    }

    [TestCase("2", "2", "4", TestName = "2 plus 2 = 4")]
    [TestCase("-5", "3", "-2", TestName = "-5 plus 3 = -2")]
    [TestCase("a", "b", "NaN", TestName = "a plus b = NaN")]
    public static void TestSumCalculation(string firstInput, string secondInput, string result)
    {

      page.FirstInputField(firstInput);
      page.SecondInputField(secondInput);
      page.ClickGetTotal(result);
      page.VerifyResult(result);

    }


  }
}

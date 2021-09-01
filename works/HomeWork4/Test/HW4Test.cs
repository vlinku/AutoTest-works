using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using works.HomeWork4.Page;

namespace works.HomeWork4.Test
{
  class HW4Test
  {

    private static HW4Page page;

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
      IWebDriver Driver = new ChromeDriver();
      page = new HW4Page(Driver);
      
      
    }

    [OneTimeTearDown]
    public static void CloseBrowser()
    {
      page.CloseBrowser();
    }

    [TestCase("Opel", "Volvo", "Saab", "Audi", TestName = "Select Opel, Volvo, Saab and Audi")]
    [TestCase("Saab", "Opel", "Audi", TestName = "Select Saab, Opel and Audi")]
    [TestCase("Volvo", "Audi", TestName = "Select Volvo and Audi")]
    public static void FirstCheckbox(params string[] cars)
    {
      page.NavigateToPage();
      page.AcceptCookies();
      page.SelectFromDropDownByValue(cars.ToList());
      page.ClickSubmitButton();
      page.VerifyResult(cars.ToList());
      page.RerunPageScript();
    }
  }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace works
{
    public class Class1
    {
    [Test]
    public static void Test4IsEven()
    {
      int reminder = 4 % 2;
      Assert.AreEqual(0, reminder, "4 is not even number");
    }

    [Test]
    public static void NowIs20h()
    {
      //Assert.AreEqual(19, DateTime.Now.Hour, "Now is not 20 hour");
      Assert.IsTrue(20 == DateTime.Now.Hour, "Now is not 20 hour");
    }

    [Test]
    public static void TestEvenNumberBetween1And10()
    {
      int counter = 0;
      for (int i = 1; i < 10; i++)
      {
        if (i % 2 == 0)
        {
          counter++;
        }
      }
      Assert.AreEqual(4, counter, "We not have 4 even numbers between 1 and 10");
    }

    [Test]
    public static void TestWait()
    {
      Thread.Sleep(5000);
      Assert.Pass();
    }


    [Test]
    public static void PrimeNumbers()
    {
      int primeNumbers = 0;
      for (int num = 1; num <= 20; num++)
      {
        int ctr = 0;

        for (int i = 2; i <= num / 2; i++)
        {
          if (num % i == 0)
          {
            ctr++;
            break;
          }
        }

        if (ctr == 0 && num != 1)
        {
          primeNumbers++;
        }

      }
      Assert.AreEqual(8, primeNumbers, "Nope");
    }
  }
}

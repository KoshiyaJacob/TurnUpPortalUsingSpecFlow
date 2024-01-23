using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TurnUpPortalUsingSpecFlow.ClassesFolder
{
    public class TimeAndMaterial
    {
        public void Click_TM(IWebDriver driver)
        {
            IWebElement clickadministration = driver.FindElement(By.XPath("//div/div/ul/li/a[@href='#']"));
            clickadministration.Click();

            IWebElement clickTM = driver.FindElement(By.LinkText("Time & Materials"));
            clickTM.Click();
            Console.WriteLine("User clicked on Time and Materials");
            Thread.Sleep(1000);





        }
    }
}

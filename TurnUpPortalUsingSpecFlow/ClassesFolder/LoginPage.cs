using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortalUsingSpecFlow.Utilities;

namespace TurnUpPortalUsingSpecFlow.ClassesFolder
{
    public class LoginPage : Commondriver
    {
        public void Login_HomePage_Verification(IWebDriver driver)
        {
            
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            //Entering name, password and click on login
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("Hari");


            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");


            IWebElement clicklogin = driver.FindElement(By.XPath("//input[@type='submit']"));
            clicklogin.Click();

                   //Verify logged in or nor 

            IWebElement verificationText = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            Assert.That(verificationText.Text.Equals("Hello hari!"), "TurnUp Potal Logged in Successfully");
        }

    }
}

    


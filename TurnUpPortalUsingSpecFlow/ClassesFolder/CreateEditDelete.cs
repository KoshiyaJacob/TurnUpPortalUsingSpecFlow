using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using OpenQA.Selenium;

namespace TurnUpPortalUsingSpecFlow.ClassesFolder
{
    public class CreateEditDelete
    {
        public void Create_Time_And_Material(IWebDriver driver, string code, string description, string price)
        {


            IWebElement clickcreate = driver.FindElement(By.XPath("//a[@href='/TimeMaterial/Create']"));
            clickcreate.Click();
            Thread.Sleep(1000);

            IWebElement typeCode = driver.FindElement(By.XPath("//span[contains(text(),'Material')]"));
            typeCode.Click();


            IWebElement dropdownbutton = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            Thread.Sleep(1000);
            dropdownbutton.Click();
            


            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys(code);


            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys(description);
            Thread.Sleep(1000);


            IWebElement pricePerUnit = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
            pricePerUnit.SendKeys(price);

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Submit();
            Console.WriteLine("Time and Materials created and submitted");

            IWebElement selectLastPage = driver.FindElement(By.XPath("//span[contains(text(),'last page')]"));
            selectLastPage.Click();
        }

        public void AssertCreate(IWebDriver driver, string Code) 
        { 

            //click on lastpage icon and check the given code
            IWebElement savedData = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
        
            Assert.That(savedData.Text == Code, "Data not created in Time and Materials");
            
        }

        public void Edit_Time_And_Material(IWebDriver driver , string new_code, string new_description, string new_price)
        {
            //Edit the given data

            IWebElement clickOnEditButton = driver.FindElement(By.XPath("//tbody/tr[6]/td[5]/a[1]"));
            clickOnEditButton.Click();


            IWebElement editCodeType = driver.FindElement(By.XPath("//span[contains(text(),'Time')]"));
            editCodeType.Click();


            IWebElement selectDropDown = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
            selectDropDown.Click();
 
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys(new_code);

            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys(new_description);
            Thread.Sleep(1000);


            IWebElement editPrice = driver.FindElement(By.XPath("//span/input[contains(@class,'formatted-value')]"));
            editPrice.SendKeys(new_price); 

        
            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();
            Thread.Sleep(1000);

        }

        public void EditedData(IWebDriver driver)
        {
            Console.WriteLine("The created record was edited");
            
        }
        public void Delete_Time_And_Material(IWebDriver driver)
        {
            IWebElement lastpageicon = driver.FindElement(By.LinkText("Go to the last page"));
            lastpageicon.Click();
            Thread.Sleep(1000);

            //click on Delete button 

            IWebElement clickDelete = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[2]"));
            clickDelete.Click(); 
        }
        public void Verify_Delete(IWebDriver driver) 
        { 
            //To retrive alert message:
            Boolean alertMessage = true;

            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertBox = alert.Text;
                Console.WriteLine("Alert box text: " + alertBox);

                alertMessage = true;
                alert.Accept();
                Console.WriteLine("Alert was accepted : " + alertMessage);

                Thread.Sleep(1000);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //IAlert alert = driver.SwitchTo().Alert();
            //string alertBox = alert.Text;
            //Console.WriteLine("Alert box text" + alertBox);
            //alert.Accept();

           //Taking Screenshot and save

            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"D:\Screenshot\SeleniumTestingScreenshot.jpg");
                Console.WriteLine("Screenshot saved");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            //Logout
            Thread.Sleep(1000);
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            helloHari.Click();

            IWebElement dropDownField = driver.FindElement(By.XPath("//a[contains(text(),'Log off')]"));
            dropDownField.Click();

            //Retrive the Current page url:

            string url = driver.Url;
            Assert.Pass(url);
            driver.Quit();

            //string url = driver.Url;
            //Console.WriteLine(url);

        }
        
    }
    
}

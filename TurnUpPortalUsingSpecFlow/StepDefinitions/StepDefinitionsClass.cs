using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TurnUpPortalUsingSpecFlow.ClassesFolder;

namespace TurnUpPortalUsingSpecFlow.StepDefinitions
{
    [Binding]
    public class StepDefinitionsClass 
    {
        IWebDriver driver = new ChromeDriver();

        LoginPage loginPage_Obj = new LoginPage();
        TimeAndMaterial timeAndMaterial_Obj = new TimeAndMaterial();
        CreateEditDelete createEditDelete_Obj = new CreateEditDelete();



        [Given(@"I navigate to TurnUp portal with valid credentials")]
        public void GivenINavigateToTurnUpPortalWithValidCredentials()
        {
            loginPage_Obj.Login_HomePage_Verification(driver);
        }

        [When(@"I navigate to Time and Material Page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            timeAndMaterial_Obj.Click_TM(driver);
            
        }


        [When(@"Record in Time and material ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" should be created")]
        public void WhenRecordInTimeAndMaterialShouldBeCreated(string code, string description, string price)
        {
            createEditDelete_Obj.Create_Time_And_Material(driver, code, description, price);
        }


        [Then(@"the record should be saved ""([^""]*)""")]
        public void ThenTheRecordShouldBeSaved(string code)
        {
            createEditDelete_Obj.AssertCreate(driver, code);
            

        }



        [When(@"I edit the record ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenIEditTheRecord(string new_code, string new_description, string new_price)
        {
            createEditDelete_Obj.Edit_Time_And_Material(driver, new_code, new_description, new_price);

        }

        [Then(@"the record should be updated")]
        public void ThenTheRecordShouldBeUpdated()
        {
            createEditDelete_Obj.EditedData(driver);
           

        }

        [When(@"I delete the record from the Time and Material sheet")]
        public void WhenIDeleteTheRecordFromTheTimeAndMaterialSheet()
        {
            createEditDelete_Obj.Delete_Time_And_Material(driver);
        }

        [Then(@"the record should be deleted and receive the alert message")]
        public void ThenTheRecordShouldBeDeletedAndReceiveTheAlertMessage()
        {
            createEditDelete_Obj.Verify_Delete(driver);
            
        }
        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

using SpecFlowProjectMarsLanguagesSkills.Utilities;
using SpecFlowProjectMarsLanguagesSkills.Pages;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.CacheStorage;

namespace SpecFlowProjectMarsLanguagesSkills.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        HomePage homePageObj = new HomePage();
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();
        LanguagePage languagePageObj = new LanguagePage();

        [BeforeScenario]

        public void BeforeScenario()
        {
            Initialize();
            homePageObj.SignInActions();
            loginPageObj.LoginActions();
            profilePageObj.ClickLanguageTab();

        }
                           
        //Delete language    
      
        [When(@"User deletes all the records")]
        public void WhenUserDeletesAllTheRecords()
        {
            languagePageObj.deleteLanguageRecord();
        }

        [Then(@"User should not be able to view the deleted language record")]
        public void ThenUserShouldNotBeAbleToViewTheDeletedLanguageRecord()
        {
            languagePageObj.assertDeleteLanguage();
        }


     //Add language   
        [When(@"User adds a new language record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageRecord(string language, string level)

        {

            languagePageObj.AddNewLanguage(language, level);
        }



        [Then(@"Mars portal should save the new language record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheNewLanguageRecord(string language)
        {
            languagePageObj.assertAddNewLanguage(language);
        }

        //Update language

        [When(@"User edits an existing language record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingLanguageRecord(string oldlanguage, string oldlevel, string newlanguage, string newlevel)
        {
            languagePageObj.updateLanguage(oldlanguage, oldlevel, newlanguage, newlevel);
        }


        [Then(@"Mars portal should save the updated language record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedLanguageRecord(string newlanguage, string newlevel)
        {
            languagePageObj.assertUpdateLanguage(newlanguage, newlevel);
        }
        //Cancel Update language

        [When(@"USer try to update data and discard the changes '([^']*)' '([^']*)'")]
        public void WhenUSerTryToUpdateDataAndDiscardTheChanges(string oldlanguage, string newlanguage)
        {
            languagePageObj.cancelEditLanguageData(oldlanguage ,newlanguage);
        }


        [Then(@"Mars portal should not save the updates '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldNotSaveTheUpdates(string oldlanguage, string newlanguage)
        {
            languagePageObj.assertCancelEditLanguage(oldlanguage,newlanguage);
        }

        //update language without editing both of the values 

        [When(@"USer try to update language record without editing both values  '([^']*)' '([^']*)'")]
        public void WhenUSerTryToUpdateLanguageRecordWithoutEditingBothValues(string language, string level)
        {
            languagePageObj.updateLanguageWithoutEditValues(language,level);
        }


        //[Then(@"Mars portal should display an alert message <language> <level>")]
        //public void ThenMarsPortalShouldDisplayAnAlertMessageLanguageLevel(string language,string level)
        //{
        //    languagePageObj.assertupdateLanguageWithoutEditValues(language,level);
        //}



        [When(@"User try to add an existing language with different level '([^']*)' '([^']*)'")]
        public void WhenUserTryToAddAnExistingLanguageWithDifferentLevel(string language, string level)
        {
            languagePageObj.AddexistingLanguageWithDiffLevel(language,level);
        }


        [Then(@"Mars portal should display an alert message and should not add the record")]
        public void ThenMarsPortalShouldDisplayAnAlertMessageAndShouldNotAddTheRecord()
        {
            languagePageObj.assertAddexistingLanguageWithDiffLevel();
        }


        [When(@"User adds a new language without entering the data '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageWithoutEnteringTheData(string language, string level)
        {
            languagePageObj.AddNewLanguageWithoutData(language,level);
        }


        [Then(@"Mars portal should display an alert message and should not save the record")]
        public void ThenMarsPortalShouldDisplayAnAlertMessageAndShouldNotSaveTheRecord()
        {
            languagePageObj.AssertAddNewLanguageWithouthoutData();
        }



        [When(@"User enter the language details '([^']*)' '([^']*)'")]
        public void WhenUserEnterTheLanguageDetails(string language, string level)
        {
            languagePageObj.cancelAddNewLanguage(language,level);
        }


        [Then(@"Mars portal should be able to discard the entered details without saving the record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldBeAbleToDiscardTheEnteredDetailsWithoutSavingTheRecord(string language, string level)
        {
            languagePageObj.assertcancelAddNewLanguage(language,level);
        }

        //Add language with invalid input

        [When(@"User try to add a language with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserTryToAddALanguageWithInvalidData(string language, string level)
        {
            languagePageObj.AddNewLanguageWithInvalidData(language,level);
        }

        [Then(@"Mars portal should display an alert mesage and should not save the record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldDisplayAnAlertMesageAndShouldNotSaveTheRecord(string language, string level)
        {
            languagePageObj.assertAddNewLanguageWithInvalidData(language,level);
        }

        [When(@"User try to add a fifth record '([^']*)' '([^']*)'")]
        public void WhenUserTryToAddAFifthRecord(string language, string level)
        {
            languagePageObj.addingfifthlanguage(language,level);
        }

        [Then(@"Mars portal should not allow to add the fifth record")]
        public void ThenMarsPortalShouldNotAllowToAddTheFifthRecord()
        {
            languagePageObj.assertaddingfifthlanguage(); 
        }







        [AfterScenario]
        public void Closedriver()
        {
            Close();
        }

    }
}

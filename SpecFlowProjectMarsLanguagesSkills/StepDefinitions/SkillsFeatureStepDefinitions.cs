using SpecFlowProjectMarsLanguagesSkills.Pages;
using SpecFlowProjectMarsLanguagesSkills.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMarsLanguagesSkills.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions :CommonDriver

    {
        HomePage homePageObj = new HomePage();
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();
        SkillsPage skillsPageObj = new SkillsPage();
       

        [Given(@"User navigates to skills tab")]
        public void GivenUserNavigatesToSkillsTab()
        {
            profilePageObj.clickSkillsTab();
        }

        [When(@"User adds a new skill record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewSkillRecord(string skill, string level)
        {
            skillsPageObj.addingNewSkill( skill, level);
        }

        [Then(@"Mars portal should save the new skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheNewSkillRecord(string skill)
        {
            skillsPageObj.assertAddingNewSkills(skill);
        }


        
        [When(@"User enter the skill details '([^']*)' '([^']*)'")]
        public void WhenUserEnterTheSkillDetails(string skill, string level)
        {
           skillsPageObj.cancelAddNewSkill(skill,level);
        }

        [Then(@"Mars portal should be able to discard the entered details without saving the skill record '([^']*)'")]
        public void ThenMarsPortalShouldBeAbleToDiscardTheEnteredDetailsWithoutSavingTheSkillRecord(string skill)
        {
            skillsPageObj.assertcancelAddNewLanguage(skill);
        }



        [When(@"User adds a new skill without entering the data '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewSkillWithoutEnteringTheData(string skill, string level)
        {
            skillsPageObj.addingNewSkillwithoutData(skill,level);
        }

        [Then(@"Mars portal should display an alert message and should not save the skill record")]
        public void ThenMarsPortalShouldDisplayAnAlertMessageAndShouldNotSaveTheSkillRecord()
        {
            skillsPageObj.assertaddingNewSkillwithoutData();
        }


        [When(@"User try to add a new skill with invalid input '([^']*)' '([^']*)'")]
        public void WhenUserTryToAddANewSkillWithInvalidInput(string skill, string level)
        {
            skillsPageObj.addingNewSkillWithInvalidData(skill,level);
        }

        [Then(@"Mars portal should display an alert mesage and should not save the skill record '([^']*)'")]
        public void ThenMarsPortalShouldDisplayAnAlertMesageAndShouldNotSaveTheSkillRecord(string skill)
        {
            skillsPageObj.assertaddingNewSkillWithInvalidData(skill);
        }


        [When(@"User try to add an existing skill with different level '([^']*)' '([^']*)'")]
        public void WhenUserTryToAddAnExistingSkillWithDifferentLevel(string skill, string level)
        {
            skillsPageObj.addexistingSkillWithDiffLevel(skill,level);
        }

        [Then(@"Mars portal should display an alert message and should not add the skill record")]
        public void ThenMarsPortalShouldDisplayAnAlertMessageAndShouldNotAddTheSkillRecord()
        {
            skillsPageObj.assertaddexistingSkillWithDiffLevel();
        }


        [When(@"User try to duplicate data '([^']*)' '([^']*)'")]
        public void WhenUserTryToDuplicateData(string skill, string level)
        {
            skillsPageObj.addingDuplicateSkill(skill,level);
        }

        [Then(@"Mars portal should display  alert message and should not save the skill record")]
        public void ThenMarsPortalShouldDisplayAlertMessageAndShouldNotSaveTheSkillRecord()
        {
            skillsPageObj.assertaddingDuplicateSkill();
        }


        [When(@"User edit an existing skill record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditAnExistingSkillRecord(string oldskill, string oldlevel, string newlevel, string newskill)
        {
            skillsPageObj.updatExistingSkills(oldskill, oldlevel, newskill, newlevel);
        }

        [Then(@"Mars portal should save the updated skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedSkillRecord(string newskill)
        {
            skillsPageObj.assertupdatExistingSkills(newskill);
        }


        

        [When(@"USer try to update skill record without editing both values '([^']*)' '([^']*)'")]
        public void WhenUSerTryToUpdateSkillRecordWithoutEditingBothValues(string skill, string level)
        {
            skillsPageObj.updateSkillsWithoutEditValues(skill,level);
        }


        [Then(@"Mars portal should display an alert message")]
        public void ThenMarsPortalShouldDisplayAnAlertMessage()
        {
            skillsPageObj.assertupdateSkillsWithoutEditValues();
        }



        [When(@"User edit the skill details '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditTheSkillDetails(string oldskill, string oldlevel, string newskill, string newlevel)
        {
            skillsPageObj.cancelEditExistingSkills(oldskill,oldlevel,newskill,newlevel);
        }


        [Then(@"Mars portal should be able to discard the changes without saving the skill record '([^']*)'")]
        public void ThenMarsPortalShouldBeAbleToDiscardTheChangesWithoutSavingTheSkillRecord(string oldskill)
        {
            skillsPageObj.assertcancelEditExistingSkills(oldskill);
        }


        [When(@"User try to delete a skill record '([^']*)' '([^']*)'")]
        public void WhenUserTryToDeleteASkillRecord(string skill, string level)
        {
            skillsPageObj.deleteSkill(skill);
        }

        [Then(@"Mars portal should displays the message '([^']*)'")]
        public void ThenMarsPortalShouldDisplaysTheMessage(string skill)
        {
            skillsPageObj.assertdeleteSkill(skill);
        }

















    }
}

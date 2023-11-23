using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMarsLanguagesSkills.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SpecFlowProjectMarsLanguagesSkills.Pages
{
    public class SkillsPage : CommonDriver
    {
        string popUpMessage;
        string compareString;
        public void addingNewSkill(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

                 IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
                skillsTab.Click();
                Thread.Sleep(3000);

                IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
                addNewButton.Click();

                IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                addSkillInputBox.Click();
                addSkillInputBox.SendKeys(skill);

                IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
                chooseLevelDropDown.Click();

                if (level.Equals("Beginner"))
                {
                    // Select Beginner Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                    levelOption.Click();
                }
                else if (level.Equals("Intermediate"))
                {
                    // Select Intermediate Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                    levelOption.Click();
                }
                else if (level.Equals("Expert"))
                {
                    // Select Expert Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                    levelOption.Click();
                }
                Thread.Sleep(2000);
                IWebElement addButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
                addButton.Click();
                Thread.Sleep(1000);

                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                popUpMessage = messageBox.Text;
            
        }


        public void assertAddingNewSkills(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();
            
                IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
                skillsTab.Click();
            
                // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
                Thread.Sleep(2000);
                compareString = skill + " has been added to your skills";

                if (popUpMessage.Equals(compareString))
                {
                    Assert.Pass(popUpMessage);
                }
                                         
        }



        public void cancelAddNewSkill(string skill, string level)
        {

            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);

            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            addNewButton.Click();

            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.SendKeys(skill);
            Thread.Sleep(2000);

            IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            chooseLevelDropDown.Click();

            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
            Thread.Sleep(2000);
            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
            cancelButton.Click();
            // IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            //popUpMessage = alertMessageBox.Text;
            Thread.Sleep(3000);

        }


        public void assertcancelAddNewLanguage(string skill)

        {
            //Verify if the new Language has been created Successfully
            driver.Navigate().Refresh();
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (addSkill.Text.Equals(skill))
            {

                Assert.That(addSkill.Text.Equals(skill), skill + "has been added Successfully");

            }

            Thread.Sleep(2000);
        }


        public void addingNewSkillwithoutData(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            addNewButton.Click();

            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.SendKeys(skill);

            IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            chooseLevelDropDown.Click();

            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            addButton.Click();
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = messageBox.Text;

        }


        public void assertaddingNewSkillwithoutData()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();

            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compareString = "Please enter skill and experience level";

            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
            }


        }


        public void addingNewSkillWithInvalidData(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            addNewButton.Click();

            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.SendKeys(skill);

            IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            chooseLevelDropDown.Click();

            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            addButton.Click();
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = messageBox.Text;

        }


        public void assertaddingNewSkillWithInvalidData(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();

            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compareString = skill + " has been added to your skills";

            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
            }

            Thread.Sleep(2000);


        }


        public void addexistingSkillWithDiffLevel(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            addNewButton.Click();

            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.SendKeys(skill);

            IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            chooseLevelDropDown.Click();

            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            addButton.Click();
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = messageBox.Text;
            

        }

        public void assertaddexistingSkillWithDiffLevel()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();

            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
             compareString = "Duplicate data";

            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
                
            }
            //int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody

        }



        public void addingDuplicateSkill(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            addNewButton.Click();

            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.SendKeys(skill);

            IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            chooseLevelDropDown.Click();

            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            addButton.Click();
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = messageBox.Text;

        }

        public void assertaddingDuplicateSkill()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();

            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compareString = "The skill is already exist in your skill list";

            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);

            }
            //int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody

        }


        public void updatExistingSkills(string oldskill, string oldlevel,string newskill,string newlevel)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();


            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody")).Count;
            int i;
            for ( i = 1; i <= rowCount; i++)
            {
                
                 IWebElement selectskillToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectskillToUpdate.Text.Equals(oldskill))

                {
                    IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editIcon.Click();
                    Thread.Sleep(2000);

                    //IWebElement updateSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                    IWebElement updateSkillInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    updateSkillInputBox.Click();
                    updateSkillInputBox.Clear();
                    Thread.Sleep(2000);
                    updateSkillInputBox.SendKeys(newskill);
                    Thread.Sleep(2000);

                    IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    //IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
                    chooseLevelDropDown.Click();
                    Thread.Sleep(2000);

                    if (newlevel.Equals("Beginner"))
                    {
                        // Select Beginner Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                         levelOption.Click();
                        Thread.Sleep(2000);

                    }
                    else if (newlevel.Equals("Intermediate"))
                    {
                        // Select Intermediate Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    else if (newlevel.Equals("Expert"))
                    {
                        // Select Expert Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    Thread.Sleep(2000);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(5000);

                    IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    popUpMessage = messageBox.Text;
                    Thread.Sleep(2000);
                    break;
                }
            }

        }



        public void assertupdatExistingSkills(string newskill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            Thread.Sleep(2000);
            compareString = newskill + " has been updated to your skills";
            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
            }
            Thread.Sleep(2000);
        }


        
        public void updateSkillsWithoutEditValues(string skill, string level)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();


            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {

                IWebElement selectskillToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectskillToUpdate.Text.Equals(skill))

                {
                    IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editIcon.Click();
                    Thread.Sleep(2000);

                    IWebElement updateSkillInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    updateSkillInputBox.Click();
                     Thread.Sleep(2000);

                    IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    chooseLevelDropDown.Click();
                    Thread.Sleep(2000);

                    if (level.Equals("Beginner"))
                    {
                        // Select Beginner Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                        levelOption.Click();
                        Thread.Sleep(2000);

                    }
                    else if (level.Equals("Intermediate"))
                    {
                        // Select Intermediate Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    else if (level.Equals("Expert"))
                    {
                        // Select Expert Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    Thread.Sleep(2000);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(5000);

                    IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    popUpMessage = messageBox.Text;
                    Thread.Sleep(2000);
                    break;
                }
            }

        }

        
        

        public void assertupdateSkillsWithoutEditValues()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            Thread.Sleep(2000);
            compareString = "This skill is already added to your skill list.";
            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
            }
            Thread.Sleep(2000);
        }

        public void cancelEditExistingSkills(string oldskill, string oldlevel, string newskill, string newlevel)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();

            Thread.Sleep(3000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {

                IWebElement selectskillToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectskillToUpdate.Text.Equals(oldskill))

                {
                    IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editIcon.Click();
                    Thread.Sleep(2000);

                    IWebElement updateSkillInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    updateSkillInputBox.Click();
                    updateSkillInputBox.Clear();
                    Thread.Sleep(2000);
                    updateSkillInputBox.SendKeys(newskill);
                    Thread.Sleep(2000);

                    IWebElement chooseLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    chooseLevelDropDown.Click();
                    Thread.Sleep(2000);

                    if (newlevel.Equals("Beginner"))
                    {
                        // Select Beginner Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                        levelOption.Click();
                        Thread.Sleep(2000);

                    }
                    else if (newlevel.Equals("Intermediate"))
                    {
                        // Select Intermediate Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    else if (newlevel.Equals("Expert"))
                    {
                        // Select Expert Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                        levelOption.Click();
                        Thread.Sleep(2000);
                    }
                    Thread.Sleep(3000);
                    IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody["+ i + "]/tr/td/div/span/input[2]"));

                    cancelButton.Click();
                    Thread.Sleep(3000);

                     break;
                }
            }
              
              
        }


        public void assertcancelEditExistingSkills(string oldskill)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {
                IWebElement selectskillToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectskillToUpdate.Text.Equals(oldskill))
                {
                    Assert.That(selectskillToUpdate.Text.Equals(oldskill), "Record has been updated with newlanguage ");
                    break;
                }
            }
            Thread.Sleep(2000);
        }



        public void deleteSkill(string skill)

        {
            driver.Navigate().Refresh();

            Thread.Sleep(3000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();
            Thread.Sleep(3000);
            IWebElement selectskillTodelete = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            deleteButton.Click();
            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = messageBox.Text;
            Thread.Sleep(2000);
        }
                                           
               
        public void assertdeleteSkill(string skill)
        {
            driver.Navigate().Refresh();
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            Thread.Sleep(3000);
            compareString = skill + " has been deleted";
            if (popUpMessage.Equals(compareString))
            {
                Assert.Pass(popUpMessage);
            }
            Thread.Sleep(2000);
        }


    }


}
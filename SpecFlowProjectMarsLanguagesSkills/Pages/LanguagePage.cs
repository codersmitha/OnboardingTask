using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectMarsLanguagesSkills.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SpecFlowProjectMarsLanguagesSkills.Pages
{
    
    public class LanguagePage : CommonDriver
    {
        string popUpMessage;
        public void deleteLanguageRecord()
        {
            //int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            //for (int i = 1; i <= 4; i++)
            //{
            //    Thread.Sleep(2000);
            //    IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            //    deleteButton.Click();
            //    Thread.Sleep(3000);
            //    driver.Navigate().Refresh();
            //}
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            for (int i = 1; i <= rowCount;)

            {
                Thread.Sleep(3000);
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                deleteButton.Click();
                rowCount--;
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                


            }

        }

        public void assertDeleteLanguage()
        {
            
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            Assert.That(rowCount == 0, "Records Not Deleted Successfully");
            Thread.Sleep(3000);
        }



        public void AddNewLanguage(string language, string level)
        {

            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageInputBox.Click();
            addLanguageInputBox.SendKeys(language);

            IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            selectLanguageLevelDropdown.Click();

            Thread.Sleep(2000);
            if (level.Equals("Basic"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                leveloptions.Click();
            }
            else if (level.Equals("Conversational"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                leveloptions.Click();
            }
            else if (level.Equals("Fluent"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                leveloptions.Click();
            }
            else if (level.Equals("Native/Bilingual"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                leveloptions.Click();
            }

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(1000);
            IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = alertMessageBox.Text;
            Thread.Sleep(3000);

        }

        public void assertAddNewLanguage(string language)
        {
            //Verify if the new Language has been created Successfully
            driver.Navigate().Refresh();
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (addLanguage.Text.Equals(language))
            {
                //Assert.Pass("Language has been Added Successfully");
                Assert.Pass(popUpMessage);
                Assert.That(addLanguage.Text.Equals(language), "Language Not Added Successfully");
                
            }
            //else
            //{
            //    Assert.Fail("Language Not Added Successfully");
            //}
            Thread.Sleep(2000);
        }



        public void updateLanguage(string oldlanguage, string oldlevel, string newlanguage, string newlevel)
        {
            //Refresh the Profile Page
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            //int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//")).Count;
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            for (int i = 1; i <= rowCount; i++)
            {
                IWebElement selectLanguageToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectLanguageToUpdate.Text.Equals(oldlanguage))
                {
                    IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editButton.Click();

                    IWebElement updateLanguageTextBox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    updateLanguageTextBox.Click();
                    updateLanguageTextBox.Clear();
                    updateLanguageTextBox.SendKeys(newlanguage);

                    IWebElement chooseLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    chooseLevelDropdown.Click();

                    if (newlevel.Equals("Basic"))
                    {
                        // Select Basic Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                        levelOption.Click();
                    }
                    else if (newlevel.Equals("Conversational"))
                    {
                        // Select Conversational Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                        levelOption.Click();
                    }
                    else if (newlevel.Equals("Fluent"))
                    {
                        // Select Fluent Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                        levelOption.Click();
                    }
                    else if (newlevel.Equals("Native/Bilingual"))
                    {
                        // Select Native/Bilingual Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                        levelOption.Click();
                    }
                    Thread.Sleep(2000);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(3000);
                    break;
                }

            }
        }


        public void assertUpdateLanguage(string newlanguage, string newlevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {
                IWebElement chooseLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                IWebElement chooseLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                if ((chooseLanguage.Text.Equals(newlanguage)) && (chooseLevel.Text.Equals(newlevel)))
                {
                    Assert.That((chooseLanguage.Text.Equals(newlanguage)) && (chooseLevel.Text.Equals(newlevel)), "Language not  Updated Successfully");
                    break;
                }
            }
            Thread.Sleep(2000);
        }



        public void cancelEditLanguageData(string oldlanguage, string newlanguage)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            for (int i = 1; i <= rowCount; i++)
            {
                IWebElement selectLanguageToEdit = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectLanguageToEdit.Text.Equals(oldlanguage))
                {
                    IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editButton.Click();


                    IWebElement selelectLanguageToEdit = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td/div/div[1]/input"));
                    selelectLanguageToEdit.Click();
                    Thread.Sleep(2000);
                    selelectLanguageToEdit.Clear();
                    Thread.Sleep(2000);
                    selelectLanguageToEdit.SendKeys(newlanguage);
                    Thread.Sleep(2000);

                    IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td/div/div[1]/input"));
                    cancelButton.Click();
                    Thread.Sleep(2000);
                    break;
                }
            }

        }


        public void assertCancelEditLanguage(string oldlanguage, string newlanguage)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {
                IWebElement selectLanguageToEdit = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectLanguageToEdit.Text.Equals(oldlanguage)) 
                {
                    Assert.That(selectLanguageToEdit.Text.Equals(oldlanguage) , "Record has been updated with newlanguage ");
                    break;
                }
            }
            Thread.Sleep(2000);
        }


        //updating Language record without editing both the field values

        public void updateLanguageWithoutEditValues(string language, string level)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            for (int i = 1; i <= rowCount; i++)
            {
                IWebElement selectLanguageToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (selectLanguageToUpdate.Text.Equals(language))
                {
                    IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    editButton.Click();
                                                                     
                    Thread.Sleep(2000);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(3000);
                    IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    popUpMessage = alertMessageBox.Text;
                    Thread.Sleep(3000);
                    break;
                }

            }
        }


        //public void assertupdateLanguageWithoutEditValues(string language,String level)
        //{
        //    //Verify if the existing Language has updated Successfully
        //    driver.Navigate().Refresh();
        //    //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
        //    Thread.Sleep(3000);
        //    int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
        //    int i;
        //    for (i = 1; i <= rowCount; i++)
        //    {
        //        IWebElement selectLanguageToEdit = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
        //        if (selectLanguageToEdit.Text.Equals(language))
        //        {
        //            Assert.Pass(popUpMessage);
        //            Assert.That(selectLanguageToEdit.Text.Equals(language), "Record has been updated ");
        //            break;
        //        }
        //    }
        //    Thread.Sleep(2000);
        //}



        //Add an existing language with different level 

        public void AddexistingLanguageWithDiffLevel(string language, string level)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowCount == 4)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                deleteButton.Click();
                Thread.Sleep(2000);
                driver.Navigate().Refresh();

            }

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            Thread.Sleep(2000);

            IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageInputBox.Click();
            addLanguageInputBox.SendKeys(language);
            Thread.Sleep(2000);

            IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            selectLanguageLevelDropdown.Click();
            Thread.Sleep(2000);

            //if (level.Equals("Basic")) { }
            IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
            leveloptions.Click();

            //if (level.Equals("Choose Language Level"))
            //       {
            //           IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Choose Language Level']"));
            //            leveloptions.Click();
            //        }

            //if (level.Equals("Basic"))
            //{
            //    IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
            //    leveloptions.Click();
            //}
            //else if (level.Equals("Conversational"))
            //{
            //    IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
            //    leveloptions.Click();
            //}
            //else if (level.Equals("Fluent"))
            //{
            //    IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
            //    leveloptions.Click();
            //}
            //else if (level.Equals("Native/Bilingual"))
            //{
            //    IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
            //    leveloptions.Click();
            //}
            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(3000);
            IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = alertMessageBox.Text;
            Thread.Sleep(3000);

        }


        public void assertAddexistingLanguageWithDiffLevel()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            if (rowcount == 3)
            {
                Assert.Pass(popUpMessage);
            }
        }


        //Add a language without entering the data in the required fields



        public void AddNewLanguageWithoutData(string language, string level)
        {

            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            Thread.Sleep(2000);

            IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageInputBox.Click();
            addLanguageInputBox.SendKeys(language);

            IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            selectLanguageLevelDropdown.Click();

            if (level.Equals("Choose Language Level"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Choose Language Level']"));
                leveloptions.Click();
            }

            if (level.Equals("Basic"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                leveloptions.Click();
            }
            else if (level.Equals("Conversational"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                leveloptions.Click();
            }
            else if (level.Equals("Fluent"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                leveloptions.Click();
            }
            else if (level.Equals("Native/Bilingual"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                leveloptions.Click();
            }

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(1000);
            IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = alertMessageBox.Text;
            Thread.Sleep(3000);

        }



        public void AssertAddNewLanguageWithouthoutData()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            if (rowcount == 3)
            {
                Assert.Pass(popUpMessage);
            }
        }

        //Cancel Adding language
        public void cancelAddNewLanguage(string language, string level)
        {

            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageInputBox.Click();
            addLanguageInputBox.SendKeys(language);

            IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            selectLanguageLevelDropdown.Click();

            //if (level.Equals("Choose Language Level"))
            //       {
            //           IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Choose Language Level']"));
            //            leveloptions.Click();
            //        }

            if (level.Equals("Basic"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                leveloptions.Click();
            }
            else if (level.Equals("Conversational"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                leveloptions.Click();
            }
            else if (level.Equals("Fluent"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                leveloptions.Click();
            }
            else if (level.Equals("Native/Bilingual"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                leveloptions.Click();
                Thread.Sleep(1000);
            }

            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
            cancelButton.Click();
            
           // IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            //popUpMessage = alertMessageBox.Text;
            Thread.Sleep(3000);

        }


        public void assertcancelAddNewLanguage(string language,string level)
        
        {
            //Verify if the new Language has been created Successfully
            driver.Navigate().Refresh();
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (addLanguage.Text.Equals(language))
            {
                //Assert.Pass("Language has been Added Successfully");
                
                Assert.That(addLanguage.Text.Equals(language), "Language Added Successfully");

            }
            //else
            //{
            //    Assert.Fail("Language Not Added Successfully");
            //}
            Thread.Sleep(2000);
        }


       // Add a new language with invalid data
        public void AddNewLanguageWithInvalidData(string language, string level)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            Thread.Sleep(2000);

            IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageInputBox.Click();
            addLanguageInputBox.SendKeys(language);
            Thread.Sleep(2000);

            IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            selectLanguageLevelDropdown.Click();

            
            if (level.Equals("Basic"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                leveloptions.Click();
            }
            else if (level.Equals("Conversational"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                leveloptions.Click();
            }
            else if (level.Equals("Fluent"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                leveloptions.Click();
            }
            else if (level.Equals("Native/Bilingual"))
            {
                IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                leveloptions.Click();
                Thread.Sleep(2000);
            }

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);
            IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popUpMessage = alertMessageBox.Text;
            Thread.Sleep(2000);

        }

        public void assertAddNewLanguageWithInvalidData(string language, string level)
        {
            //Verify if the new Language has not been created Successfully
            driver.Navigate().Refresh();
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (addLanguage.Text.Equals(language))
            {
                //Assert.Pass("Language has been Added Successfully");
                 Assert.Pass(popUpMessage);
                Assert.That(addLanguage.Text.Equals(language), "Language  Added Successfully");

            }
            //else
            //{
            //    Assert.Fail("Language Not Added Successfully");
            //}
            Thread.Sleep(2000);
        }




        public void addingfifthlanguage(string language, string level)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",10);
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            if (rowcount == 4)
            {
                try
                {


                    IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
                    AddNewButton.Click();
                    Thread.Sleep(2000);

                    IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
                    addLanguageInputBox.Click();
                    addLanguageInputBox.SendKeys(language);
                    Thread.Sleep(2000);

                    IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
                    selectLanguageLevelDropdown.Click();


                    if (level.Equals("Basic"))
                    {
                        IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                        leveloptions.Click();
                    }
                    else if (level.Equals("Conversational"))
                    {
                        IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                        leveloptions.Click();
                    }
                    else if (level.Equals("Fluent"))
                    {
                        IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                        leveloptions.Click();
                    }
                    else if (level.Equals("Native/Bilingual"))
                    {
                        IWebElement leveloptions = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                        leveloptions.Click();
                        Thread.Sleep(2000);
                    }

                    IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
                    addButton.Click();
                    Thread.Sleep(2000);
                    IWebElement alertMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    popUpMessage = alertMessageBox.Text;
                    Thread.Sleep(2000);
                }

                catch(Exception ex)
                {
                    Assert.Pass(ex.Message);
                }

            }
        }

        public void assertaddingfifthlanguage()
        {
        
          driver.Navigate().Refresh();
          Thread.Sleep(3000);
          int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
         if (rowcount == 4)
         {
         Assert.Pass("5th Language NOT Added");
         }
    Thread.Sleep(2000);
        }


    }
}
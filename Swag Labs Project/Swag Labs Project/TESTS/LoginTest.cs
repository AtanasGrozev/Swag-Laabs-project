using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SeleniumExtras.WaitHelpers;

namespace Swag_Labs_Project.TESTS
{
    public  class LoginTest :BaseTest
    {
        public object ExpectedConditions { get; private set; }

        [Test]
        public void Test_Access_Web_App_from_its_URL()
        {
            loginPage.OpenBasePage();

            driver.Navigate().GoToUrl(basePage.BaseUrl);

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

        }

        [Test]
        public void Test_Verify_Contains_Login_Form_With_Username_And_Password()
        {
            loginPage.OpenBasePage();
            bool isUsernameFiledVisible = loginPage.userNameField.Displayed;
            bool isPasswordFiledVisible = loginPage.passwrodFiled.Displayed;
            bool isLoginButtonVisible = loginPage.loginButton.Displayed;

            Assert.IsTrue(isPasswordFiledVisible && isUsernameFiledVisible && isLoginButtonVisible);

        }

        [Test]
        public void Test_Login_With_Correct_Username_And_Password()
        {

            loginPage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo(addToCardPage.inventoryUrl));
        }

        [Test]
        public void Test_Login_With_Empty_Username_Field()
        {
            loginPage.OpenBasePage();
            loginPage.userNameField.Clear();
            loginPage.passwrodFiled.SendKeys("secret_sauce");
            loginPage.loginButton.Click();

            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username is required"));

        }

        [Test]
        public void Test_Login_With_Empty_Password_Field()
        {
            loginPage.OpenBasePage();
            loginPage.userNameField.SendKeys("standard_user");
            loginPage.passwrodFiled.Clear();
            loginPage.loginButton.Click();

            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Password is required"));

        }

        [Test]
        public void Test_Login_With_Empty_Username_And_Password_Fields()
        {
            loginPage.OpenBasePage();
            loginPage.userNameField.Clear();
            loginPage.passwrodFiled.Clear();
            loginPage.loginButton.Click();

            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username is required"));

        }

        [Test]
        public void Test_Login_With_Wrong_Username_And_Or_Password()
        {
            loginPage.OpenBasePage();
            loginPage.userNameField.SendKeys("Test1");
            loginPage.passwrodFiled.SendKeys("Test1");
            loginPage.loginButton.Click();

            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));

        }

        [Test]
        public void Test_Click_On_Red_X_Icons_In_Username_Password_Fields()
        {
            loginPage.OpenBasePage();
            loginPage.userNameField.SendKeys("Test1");
            loginPage.passwrodFiled.SendKeys("Test1");
            loginPage.loginButton.Click();

            loginPage.XiconButtonPassword.Click();
            loginPage.XiconButtonUsername.Click();  

            Assert.That(loginPage.userNameField.Text,Is.Empty);
            Assert.That(loginPage.passwrodFiled.Text, Is.Empty);
            Assert.That(loginPage.ErrorMessage.Text, Is.Empty);

        }

        [Test]
        public void Test_Click_On_Red_X_Icons_In_Error_Message_Field()
        {          

            loginPage.OpenBasePage();
            loginPage.userNameField.SendKeys("Test1");
            loginPage.passwrodFiled.SendKeys("Test1");
            loginPage.loginButton.Click();

            Assert.IsTrue(ElementExists(By.XPath("//div[@class='error-message-container error']")));
        

     
            loginPage.XiconButtonErrorMessage.Click();

       
            Assert.IsFalse(ElementExists(By.XPath("//div[@class='error-message-container error']")));
        }
        public bool ElementExists(By by)
        {
            return driver.FindElements(by).Count > 0;
        }








    }
}

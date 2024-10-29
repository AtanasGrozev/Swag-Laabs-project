using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{
    public class LogoutTest : BaseTest
    {
        [Test]
        public void Test_Logout_User_From_The_System()
        {
            basePage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            logoutPage.HamburgerMenu.Click();
            logoutPage.LogoutButton.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

        }

        [Test]
        public void Test_Refresh_System_After_Logout_To_Ensure_Session_Is_Closed()
        {
            basePage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            logoutPage.HamburgerMenu.Click();
            logoutPage.LogoutButton.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

            driver.Navigate().Refresh();

            var loginButtonVisible = driver.FindElement(By.XPath("//input[@id='login-button']")).Displayed;

            Assert.IsTrue(loginButtonVisible, "Login button should be visible after logout.");
            Assert.That(loginPage.userNameField.Text, Is.Empty);
            Assert.That(loginPage.passwrodFiled.Text, Is.Empty);

        }




    }
}

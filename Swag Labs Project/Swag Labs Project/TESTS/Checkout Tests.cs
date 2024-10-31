using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{
    public class Checkout_Tests : BaseTest
    {
        [SetUp] 
        public void Setup()
        {
            loginPage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");
        }

        [Test]
        public void Test_Verify_Buttons_Continue_Cancel_Cart_Button_And_Hamburger_Menu_Appear_On_Page()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            Assert.IsTrue(checkOutPage.continueCheckout.Displayed);
            Assert.IsTrue(checkOutPage.cancelCheckout.Displayed);
            Assert.IsTrue(checkOutPage.HamburgerButtonCheckout.Displayed);

        }

        [Test]
        public void Test_Verify_Fields_First_Name_Last_Name_And_Zip_Post_Code_Are_Visible()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            Assert.IsTrue(checkOutPage.firstNameCheckout.Displayed);
            Assert.IsTrue(checkOutPage.lastNameCheckout.Displayed);
            Assert.IsTrue(checkOutPage.postalCodeCheckout.Displayed);
        }

        [Test]
        public void Test_Verify_Buttons_Facebook_Twitter_And_LinkedIn_Are_Visible()
        {
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            Assert.IsTrue(checkOutPage.facebookLinkCheckout.Displayed);
            Assert.IsTrue(checkOutPage.twitterLinkCheckout.Displayed);
            Assert.IsTrue(checkOutPage.LinkedInLinkCheckout.Displayed);

        }

        [Test]
        public void Test_Verify_Function_Of_Cancel_Button()
        {
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.cancelCheckout.Click();

            Assert.That(driver.Url, Is.EqualTo(viewInTourCartPage.cartUrl));
        }

        [Test]
        public void Test_Verify_Function_Of_Cart_Button()
        {
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.shoppingCartLink.Click();

            Assert.That(driver.Url, Is.EqualTo(viewInTourCartPage.cartUrl));

        }

        [Test]
        public void Test_Verify_Function_Of_Continue_Button_With_Correct_First_Name_Last_Name_Zip_Code()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            checkOutPage.EnterCheckoutInformation("Test", "User", "96523");
            checkOutPage.continueCheckout.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Test]
        public void Test_Check_To_Continue_With_Empty_First_Name()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            checkOutPage.EnterCheckoutInformation("", "User", "96523");

            checkOutPage.continueCheckout.Click();

            Assert.That(checkOutPage.errorMessage.Text, Is.EqualTo("Error: First Name is required"));
        }

        [Test]
        public void Test_Check_To_Continue_With_Empty_Last_Name()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            checkOutPage.EnterCheckoutInformation("Test", "", "96523");

            checkOutPage.continueCheckout.Click();

            Assert.That(checkOutPage.errorMessage.Text, Is.EqualTo("Error: Last Name is required"));
        }

        [Test]
        public void Test_Check_To_Continue_With_Empty_Zip_Code()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            checkOutPage.EnterCheckoutInformation("Test", "User", "");

            checkOutPage.continueCheckout.Click();

            Assert.That(checkOutPage.errorMessage.Text, Is.EqualTo("Error: Postal Code is required"));
        }

        [Test]
        public void Test_Fill_Fields_First_Name_And_Last_Name_With_Numbers_Only()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            checkOutPage.EnterCheckoutInformation("11111111", "2222222", "96523");

            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(checkOutPage.errorMessage.Displayed, "No error when typing symbols.");
        }

        [Test]
        public void Test_Fill_Fields_First_Name_Last_Name_And_Zip_Code_With_156_Chars_Text()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            string longText = new string('Y', 156);

            checkOutPage.EnterCheckoutInformation(longText, longText, longText);
            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(checkOutPage.errorMessage.Displayed, "No error when typing 156 symbols.");
            Assert.AreEqual("Error: First Name is too long", checkOutPage.errorMessage.Text);
        }

        [Test]
        public void Test_Verify_Message_Checkout_Your_Information()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            Assert.IsTrue(checkOutPage.yourInformation.Displayed);
        }

    }
}

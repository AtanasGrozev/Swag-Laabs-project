using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{
    public  class View_In_Your_Cart : BaseTest
    {

        [SetUp]
        public void SetUpForAddToCartTests()
        {
            basePage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");
        }
        [Test]
        public void Test_Verify_Buttons_Remove_Continue_Shopping_Checkout_And_Hamburger_Appear_On_View_Cart_Page()
        {
           addToCardPage.OpenInvetoryPage();    
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            bool IsVisibleRemoveButton = viewInTourCartPage.RemoveButton.Displayed;
            bool IsVisibleContinueShoppingButton = viewInTourCartPage.ContinueShoppingButton.Displayed;
            bool IsVisibleCheckoutButton = viewInTourCartPage.CheckoutButton.Displayed;
            bool isVisibleHamburgerButton = viewInTourCartPage.HamburgerButton.Displayed;

            Assert.IsTrue(IsVisibleRemoveButton &&  IsVisibleContinueShoppingButton && IsVisibleCheckoutButton && isVisibleHamburgerButton);

        }

        [Test]
        public void Test_Verify_QTY_And_Description_Are_Visible_On_View_Cart_Page()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();


            Assert.That(addToCardPage.DescriptionFirstElement.Text, Is.EqualTo(viewInTourCartPage.DescriptionFirstElement.Text));
            Assert.That(addToCardPage.QTY.Text, Is.EqualTo(viewInTourCartPage.QTY.Text));


        }

        [Test]
        public void Test_Verify_Function_Of_Remove_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.RemoveButton.Click();
            
            Assert.That(viewInTourCartPage.AllProductsInCart, Is.Empty);
        }

        [Test]
        public void Test_Verify_Function_Of_Continue_Shopping_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.ContinueShoppingButton.Click();

            Assert.That(driver.Url, Is.EqualTo ("https://www.saucedemo.com/inventory.html"));
        }

        [Test]
        public void Test_Verify_Function_Of_Checkout_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            viewInTourCartPage.OpenCartUrl();
            viewInTourCartPage.CheckoutButton.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }

        [Test]
        public void Test_Verify_Buttons_Facebook_Twitter_And_LinkedIn_Are_Visible_And_Redirect_To_Correct_Page()
        {
            viewInTourCartPage.OpenCartUrl();
            Assert.True(basePage.AreSocialLinksVisible());

        }

        [Test]
        public void Test_Verify_Link_For_Terms_Of_Service()
        {

            viewInTourCartPage.OpenCartUrl();
            basePage.TermsOfServiceLink.Click();
            Assert.That(driver.Url, Is.EqualTo("https://saucelabs.com/doc/terms-of-service"), "The link for Terms of Service is not clickable.");            

        }

        [Test]
        public void Test_Verify_Link_For_Privacy_Policy()
        {

            viewInTourCartPage.OpenCartUrl();
            basePage.TermsOfServiceLink.Click();
            Assert.That(driver.Url, Is.EqualTo("https://saucelabs.com/doc/privacy-policy"), "The link for Privacy Policy is not clickable.");

        }

        [Test]
        public void Test_View_Empty_Cart()
        {
            viewInTourCartPage.OpenCartUrl();
          

            Assert.That(viewInTourCartPage.AllProductsInCart.Count(), Is.EqualTo(0));
            Assert.That(driver.Url, Is.EqualTo(viewInTourCartPage.cartUrl));


        }

    }
}

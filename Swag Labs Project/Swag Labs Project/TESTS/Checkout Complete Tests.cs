using Swag_Labs_Project.PAGES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{

    public class Checkout_Complete_Tests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            loginPage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");
        }

        [Test]
        public void Test_Verify_Function_Of_Back_Home_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.FinishButton.Click();

            Checkout_Complete checkoutCompletePage = new Checkout_Complete(driver);
            checkoutCompletePage.BackHomeButton.Click();

            
            Assert.AreEqual(checkoutCompletePage.BaseUrl + "inventory.html", driver.Url);
        }

        [Test]
        public void Test_Verify_Message_Thank_You_For_Your_Order_Dispatch_Details()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.FinishButton.Click();

            Assert.That(paymentOverviewPage.ThankYouOrder.Text, Is.EqualTo("Thank you for your order!"));
        }

        [Test]
        public void Test_Verify_Message_Checkout_Complete()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.FinishButton.Click();

            Assert.That(checkOutCompletePage.CheckoutComplete.Text, Is.EqualTo("Checkout: Complete!"));
        }

        [Test]
        public void Test_Verify_Cart_Is_Empty_After_Completion_Of_An_Order()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.FinishButton.Click();

            addToCardPage.shopingCartLinl.Click();

            Assert.That(viewInTourCartPage.AllProductsInCart, Is.Empty);
        }



    }
}

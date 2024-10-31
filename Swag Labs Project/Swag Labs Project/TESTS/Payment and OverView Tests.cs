using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{
    public class Payment_and_OverView_Tests : BaseTest
    {

        [SetUp]
        public void Setup()
        {
            loginPage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce");
        }

        [Test]
        public void Test_Verify_Products_Are_Visible_And_Check_Parameters_QTY_Description_Name_And_Price()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(paymentOverviewPage.CartItem.Any());
            Assert.IsTrue(paymentOverviewPage.ItemName.Displayed);
            Assert.IsTrue(paymentOverviewPage.Description.Displayed);
            Assert.IsTrue(paymentOverviewPage.Quantity.Displayed);
            Assert.IsTrue(paymentOverviewPage.ItemPrice.Displayed);
            
        }

        [Test]
        public void Test_Verify_Payment_Information_Shipping_Information_Price_Total_Item_Total_Tax_Total_Are_Visible_And_Show_Correct_Sum()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(paymentOverviewPage.CartItem.Any());
            Assert.IsTrue(paymentOverviewPage.PaymentInformation.Displayed);
            Assert.IsTrue(paymentOverviewPage.DeliveryInformation.Displayed);
            Assert.IsTrue(paymentOverviewPage.ItemTotalPrice.Displayed);

            Assert.That(paymentOverviewPage.ItemTotalPrice.Text, Is.EqualTo("Item total: $29.99"));
        }

        [Test]
        public void Test_Verify_Function_Of_Cancel_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.CancelButton.Click();

            Assert.That(driver.Url, Is.EqualTo(addToCardPage.inventoryUrl));
        }

        [Test]
        public void Test_Verify_Function_Of_Finish_Button()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            paymentOverviewPage.FinishButton.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));

        }

        [Test]
        public void Test_Verify_To_Finish_With_All_6_Added_Products_In_Cart()
        {
            var addToCartButton = addToCardPage.allInventoryProduct;
            foreach (var button in addToCartButton)
            {
                button.Click();
            }

            addToCardPage.shopingCartLinl.Click();

            var cartItems = viewInTourCartPage.AllProductsInCart;
            Assert.AreEqual(6, cartItems.Count, "Not all 6 products are added to the cart!");

            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(paymentOverviewPage.CartItem.Any(), "No items found.");
            Assert.IsTrue(paymentOverviewPage.ItemTotalPrice.Displayed, "Total price is not visible.");
        }

        [Test]
        public void Test_Verify_Message_Checkout_Overview()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.CheckoutButton.Click();
            checkOutPage.EnterCheckoutInformation("Yoana", "Ivanova", "6163");
            checkOutPage.continueCheckout.Click();

            Assert.IsTrue(paymentOverviewPage.CheckoutOverview.Displayed);
        }

    }
}

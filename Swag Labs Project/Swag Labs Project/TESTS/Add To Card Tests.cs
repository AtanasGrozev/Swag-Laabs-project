using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.TESTS
{
    public class Add_To_Card_Tests : BaseTest
    {
        [SetUp]
        public void SetUpForAddToCartTests()
        {
            basePage.OpenBasePage();
            loginPage.LoginMethod("standard_user", "secret_sauce"); 
        }
        [Test]
        public void Test_Add_Product_To_Cart()
        {
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.OpenCartUrl();
            var countOfProduct = viewInTourCartPage.AllProductsInCart.Count();
            Assert.That(countOfProduct, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void Test_Remove_Product_From_Cart()
        {
        
            addToCardPage.addToCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            viewInTourCartPage.OpenCartUrl();
            var countOfProduct = viewInTourCartPage.AllProductsInCart.Count();
            Assert.That(countOfProduct, Is.GreaterThanOrEqualTo(1));
            addToCardPage.OpenInvetoryPage();
            addToCardPage.RemoveFromCardButtonFirstItem.Click();
            addToCardPage.shopingCartLinl.Click();
            countOfProduct = viewInTourCartPage.AllProductsInCart.Count();
            Assert.That(countOfProduct, Is.EqualTo(0));

        }

        [Test]
        public void Test_Add_All_Products_To_The_Cart()
        {
            var countInventoryProducts = 0;
            foreach (var item in addToCardPage.allInventoryProduct)
            {
                item.Click();
                countInventoryProducts++;                
            }
            viewInTourCartPage.OpenCartUrl();
            var countOfProductInCart = viewInTourCartPage.AllProductsInCart.Count();

            Assert.That(countInventoryProducts, Is.EqualTo(countOfProductInCart));


        }

        [Test]
        public void Test_Add_Products_To_Cart_Refresh_Page_To_Verify_It_Keeps_Them()
        {
            var countInventoryProducts = 0;
            foreach (var item in addToCardPage.allInventoryProduct)
            {
                item.Click();
                countInventoryProducts++;
            }
            viewInTourCartPage.OpenCartUrl();
            var countOfProductInCart = viewInTourCartPage.AllProductsInCart.Count();
            driver.Navigate().Refresh();    

            Assert.That(countInventoryProducts, Is.EqualTo(countOfProductInCart));

        }

        [Test]
        public void Test_Products_Count_Remains_In_Cart_After_Logout_And_Login_Again()
        {
            var countInventoryProducts = 0;
            foreach (var item in addToCardPage.allInventoryProduct)
            {
                item.Click();
                countInventoryProducts++;
            }
            logoutPage.LogoutMethod();
            loginPage.LoginMethod("standard_user", "secret_sauce");
            viewInTourCartPage.OpenCartUrl();
            var countOfProductInCart = viewInTourCartPage.AllProductsInCart.Count();
          

            Assert.That(countInventoryProducts, Is.EqualTo(countOfProductInCart));

        }

        [Test]
        public void Test_Add_Product_To_Cart_From_The_Page_Of_The_Actual_Item()
        {
            addToCardPage.ActualFirstItem.Click();
            addToCardPage.ActialItemAddButton.Click();  

            viewInTourCartPage.OpenCartUrl();
            var countOfProduct = viewInTourCartPage.AllProductsInCart.Count();
            Assert.That(countOfProduct, Is.EqualTo(1));

        }

        [Test]
        public void Test_Add_More_Quantity_Of_The_Same_Product()
        {
            // Липсва такава функционалност.
            // Може би е добре да се автоматизира тества след добавянето и.

        }

    }
}

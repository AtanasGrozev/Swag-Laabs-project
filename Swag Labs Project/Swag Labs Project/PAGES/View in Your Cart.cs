using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class View_in_Your_Cart: BasePage
    {
        public View_in_Your_Cart(IWebDriver driver):base(driver)
        {
            
        }

        public string cartUrl = "https://www.saucedemo.com/cart.html";

        public void OpenCartUrl()
        {
            driver.Navigate().GoToUrl(cartUrl); 
        }

        public IReadOnlyCollection<IWebElement> AllProductsInCart => driver.FindElements(By.XPath("//div[@class='cart_item_label']"));
        public IWebElement FirstProduct => AllProductsInCart.First();

        public IWebElement RemoveButton => driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-backpack']"));
        public IWebElement ContinueShoppingButton => driver.FindElement(By.XPath("//button[@id='continue-shopping']"));
        public IWebElement CheckoutButton => driver.FindElement(By.XPath("//button[@id='checkout']"));
        public IWebElement HamburgerButton => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));

        public IReadOnlyCollection<IWebElement> DescriptionFields => driver.FindElements(By.XPath("//div[@data-test='inventory-item-desc']"));
        public IWebElement? DescriptionFirstElement => DescriptionFields.First();
  
        public IWebElement QTY => driver.FindElement(By.XPath("//div[@data-test='item-quantity']"));


    }
}

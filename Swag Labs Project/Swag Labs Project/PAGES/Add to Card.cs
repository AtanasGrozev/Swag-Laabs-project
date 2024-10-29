using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class Add_to_Card:BasePage
    {
        public Add_to_Card(IWebDriver driver):base(driver)
        {
            
        }

        public string inventoryUrl = "https://www.saucedemo.com/inventory.html";

        public void OpenInvetoryPage()
        {
            driver.Navigate().GoToUrl(inventoryUrl);
        }

        public IWebElement addToCardButtonFirstItem => driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"));
        public IReadOnlyCollection<IWebElement>  allInventoryProduct => driver.FindElements(By.XPath("//button[@class='btn btn_primary btn_small btn_inventory ']"));    
        public IWebElement sortButton => driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
        public IWebElement shopingCartLinl => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        public IWebElement RemoveFromCardButtonFirstItem => driver.FindElement(By.XPath("//button[@class='btn btn_secondary btn_small btn_inventory ']"));
        public IReadOnlyCollection<IWebElement> DescriptionFields => driver.FindElements(By.XPath("//div[@data-test='inventory-item-desc']"));
        public IWebElement? DescriptionFirstElement => DescriptionFields.First();
        public IWebElement QTY => driver.FindElement(By.XPath("//div[@data-test='item-quantity']"));

        
         //                                            ACTUAL ITEM
        public IWebElement ActualFirstItem => driver.FindElement(By.XPath("//img[@alt='Sauce Labs Backpack']"));
        public IWebElement ActialItemAddButton => driver.FindElement(By.XPath(("//button[@id='add-to-cart']")));


    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class LogoutPage : BasePage
    {

        public LogoutPage(IWebDriver driver): base(driver)
        {
            
        }

        public string inventoryUrl = "https://www.saucedemo.com/inventory.html";

        public void OpenInvetoryPage()
        {
            driver.Navigate().GoToUrl(inventoryUrl);
        }
        public IWebElement HamburgerMenu => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']")); 
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']")); 

        public void LogoutMethod()
        {
            HamburgerMenu.Click();
            LogoutButton.Click();
        }


    }
}

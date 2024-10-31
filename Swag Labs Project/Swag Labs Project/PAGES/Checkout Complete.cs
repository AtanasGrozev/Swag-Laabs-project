using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class Checkout_Complete:BasePage
    {
        public Checkout_Complete(IWebDriver driver):base(driver)
        {
            
        }
        public IWebElement BackHomeButton => driver.FindElement(By.XPath("//button[@data-test='back-to-products']"));
        public IWebElement CheckoutComplete => driver.FindElement(By.XPath("//span[@data-test='title']"));

    }
}

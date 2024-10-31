using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class Payment___Overview:BasePage
    {

        public Payment___Overview(IWebDriver driver):base(driver)
        {
            
        }

        public string PaymentOverviewUrl = "https://www.saucedemo.com/checkout-step-two.html";

        public void GoToPaymentOverviewPage()
        {
            driver.Navigate().GoToUrl(PaymentOverviewUrl);
        }
        public IReadOnlyCollection<IWebElement> CartItem => driver.FindElements(By.XPath("//div[@class='cart_item']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//button[@id='cancel']"));
        public IWebElement FinishButton => driver.FindElement(By.XPath("//button[@id='finish']"));
        public IWebElement Quantity => driver.FindElement(By.XPath("//div[@class='cart_quantity']"));
        public IWebElement Description => driver.FindElement(By.XPath("//div[@class='inventory_item_desc']"));
        public IWebElement ItemName => driver.FindElement(By.XPath("//div[@class='inventory_item_name']"));
        public IWebElement ItemPrice => driver.FindElement(By.XPath("//div[@class='inventory_item_price']"));
        public IWebElement PaymentInformation => driver.FindElement(By.XPath("//div[@data-test='payment-info-value']"));
        public IWebElement DeliveryInformation => driver.FindElement(By.XPath("//div[@data-test='shipping-info-value']"));
        public IWebElement ItemTotalPrice => driver.FindElement(By.XPath("//div[@data-test='subtotal-label']"));
        public IWebElement CheckoutOverview => driver.FindElement(By.XPath("//span[@data-test='title']"));
        public IWebElement ThankYouOrder => driver.FindElement(By.XPath("//h2[@data-test='complete-header']"));





    }
}

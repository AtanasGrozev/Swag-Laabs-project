using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public class Checkout:BasePage
    {
        public Checkout(IWebDriver driver):base(driver)
        {
            
        }

        public IWebElement firstNameCheckout => driver.FindElement(By.XPath("//input[@id='first-name']"));
        public IWebElement lastNameCheckout => driver.FindElement(By.XPath("//input[@id='last-name']"));
        public IWebElement postalCodeCheckout => driver.FindElement(By.XPath("//input[@id='postal-code']"));
        public IWebElement cancelCheckout => driver.FindElement(By.XPath("//button[@id='cancel']"));
        public IWebElement continueCheckout => driver.FindElement(By.XPath("//input[@id='continue']"));
        public IWebElement HamburgerButtonCheckout => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        public IWebElement shoppingCartLink => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        public IWebElement twitterLinkCheckout => driver.FindElement(By.XPath("//a[@data-test='social-twitter']"));
        public IWebElement facebookLinkCheckout => driver.FindElement(By.XPath("//a[@data-test='social-facebook']"));
        public IWebElement LinkedInLinkCheckout => driver.FindElement(By.XPath("//a[@data-test='social-linkedin']"));
        public IWebElement TermsOfServiceLinkCheckout => driver.FindElement(By.XPath("//div[@data-test='footer-copy']"));
        public IWebElement errorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));
        public IWebElement yourInformation => driver.FindElement(By.XPath("//span[@data-test='title']"));



        public void EnterCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            firstNameCheckout.SendKeys(firstName);
            lastNameCheckout.SendKeys(lastName);
            postalCodeCheckout.SendKeys(postalCode);
        }
    }
}

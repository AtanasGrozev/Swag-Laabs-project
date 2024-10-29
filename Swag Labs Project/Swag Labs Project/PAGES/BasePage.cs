using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Project.PAGES
{
    public  class BasePage
    {
        public IWebDriver driver;
        protected WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
        public string BaseUrl => "https://www.saucedemo.com/";

        public void OpenBasePage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public IWebElement twitterLink => driver.FindElement(By.XPath("//a[@data-test='social-twitter']"));
        public IWebElement facebookLink => driver.FindElement(By.XPath("//a[@data-test='social-facebook']"));
        public IWebElement LinkedInLink => driver.FindElement(By.XPath("//a[@data-test='social-linkedin']"));
        public IWebElement TermsOfServiceLink => driver.FindElement(By.XPath("//div[@data-test='footer-copy']"));

      
        
            public bool AreSocialLinksVisible()
            {
                bool twitterIsVisible = twitterLink.Displayed;
                bool facebookIsVisible = facebookLink.Displayed;
                bool linkedinIsVisible = LinkedInLink.Displayed;

                return twitterIsVisible && facebookIsVisible && linkedinIsVisible;
            }


        

    }
}

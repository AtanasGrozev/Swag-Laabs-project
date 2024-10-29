using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Swag_Labs_Project.PAGES
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver): base(driver)
        {
            
        }
     // ПОЛЕТА И МЕТОД ЗА ТЕСТ ДАЛИ SETUP-A РАБОТИ
        public IWebElement userNameField => driver.FindElement(By.XPath("//input[@id='user-name']"));
        public IWebElement passwrodFiled => driver.FindElement(By.XPath("//input[@id='password']"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//input[@id='login-button']"));
    
        public void LoginMethod(string username, string passwd)
        {
            userNameField.Clear();
            userNameField.SendKeys(username);
            passwrodFiled.Clear();
            passwrodFiled.SendKeys(passwd);
            loginButton.Click();
        }

        public IWebElement XiconButtonUsername => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[1]/svg"));
        public IWebElement XiconButtonPassword => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[2]/svg"));
        public IWebElement XiconButtonErrorMessage => driver.FindElement(By.XPath("//button[@data-test='error-button']")); 
 

   
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[@class='error-message-container error']"));



    }
}

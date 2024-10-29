using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Swag_Labs_Project.PAGES;
using SeleniumExtras.WaitHelpers; 


namespace Swag_Labs_Project.TESTS
{
    public class BaseTest
    {

        public IWebDriver driver;
        public IWebDriver wait;

        public BasePage basePage;
        public LoginPage loginPage;
        public LogoutPage logoutPage;
        public Add_to_Card addToCardPage;
        public View_in_Your_Cart viewInTourCartPage;
        public Checkout checkOutPage;
        public Payment___Overview paymentOverviewPage;
        public Checkout_Complete checkOutCompletePage;



        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("" +
                "profile.password_manager_enabled", false);

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


            basePage = new BasePage(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            addToCardPage = new Add_to_Card(driver);
            viewInTourCartPage = new View_in_Your_Cart(driver);
            checkOutPage = new Checkout(driver);
            paymentOverviewPage = new Payment___Overview(driver);
            checkOutCompletePage = new Checkout_Complete(driver);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    


    }
}
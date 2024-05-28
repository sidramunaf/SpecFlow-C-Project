using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Runtime.ConstrainedExecution;
using OpenQA.Selenium.Interactions;
using ONEFILE_ASSESMENTTEST.Pages;
using TechTalk.SpecFlow;
using Bogus;
using NUnit.Framework;
using Docker.DotNet.Models;

namespace ONEFILE_ASSESMENTTEST.StepDefinitions
{
    [Binding]
    public class KeyChainAndLoginStepDefinitionFile
    {
        private IWebDriver driver; 
        private WebDriverWait wait; 
        public static String _Email = ""; 
        public static String _Password = "OneFile123!"; 
        public static String _NewPassword = "Password123!"; 
        SignUpPage _signupPage;
        LoginPage _loginPage; 
        PassResetPage _passResetPage; 



       public KeyChainAndLoginStepDefinitionFile()
        {
            driver = new ChromeDriver(); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _signupPage = new SignUpPage(driver); 
            _loginPage = new LoginPage(driver); 
            _passResetPage = new PassResetPage(driver);

        }

        [Given(@"Navigate to the ONEFile Login Page using URL")]
        public void GivenNavigateToTheONEFileLoginPageUsingURL()
        {

            driver.Manage().Window.Maximize(); 
            driver.Navigate().GoToUrl("https://onefile.co.uk/");

            // Waiting for and finding the Accept Cookies button
            IWebElement acceptCookiesButton = wait.Until(drv => drv.FindElement(By.Id("hs-eu-confirmation-button")));
            acceptCookiesButton.Click();

        }

        [When(@"Click on the Create New Keychain")]
        public void WhenClickOnTheCreateNewKeychain()
        {
            _signupPage.AcceptCookiesAndLoginLink();
            Thread.Sleep(3000);
            _signupPage.CreateNewKeyChain();
        }

        [When(@"Enter the First Name and Last Name")]

        public void WhenEnterTheFirstNameAndLastName()
        {
            Faker faker = new Faker();
            String firstName = faker.Name.FirstName();
            String lastName = faker.Name.LastName();
            _signupPage.FirstAndLastName(firstName, lastName);
        }

        [When(@"Enter the Unique Email")]
        public void WhenEnterTheUniqueEmail()
        {
            Faker faker = new Faker();
            _Email = faker.Internet.Email();

            _signupPage.UniqueEmail(_Email);
        }

        [When(@"Enter the Password")]
        public void WhenEnterThePassword()
        {
            _signupPage.Password(_Password);
        }

        [When(@"Enter the Confirm Password")]
        public void WhenEnterTheConfirmPassword()
        {
            _signupPage.ConfirmPassword(_Password);
        }

        [When(@"Accept the Term and Conditions")]
        public void WhenAcceptTheTermAndConditions()
        {

            _signupPage.TermAndCondition();

        }

        [When(@"Click on the Register Button")]
        public void WhenClickOnTheRegisterButton()
        {
            _signupPage.Registration();
        }

        [When(@"Click on the Back to Login Page Button")]

        public void WhenClickOnTheBackToLoginPageButton()
        {
            Thread.Sleep(3000);
            _signupPage.BackToLogin();
        }

        [When(@"Enter the Login Email and Password on the Login Page")]
        public void WhenEnterTheLoginEmailAndPasswordOnTheLoginPage()
        {
            _loginPage.Login(_Email, _Password);
            Thread.Sleep(5000);
        }

        //Assertion step to verify successful login
        [Then(@"Login Should be Done Successfully")]
        public void ThenLoginShouldBeDoneSuccessfully()
        {
            string expectedText = "Home";

            // Wait for the element containing the expected text to be visible
            IWebElement homeElement = wait.Until(drv => drv.FindElement(By.XPath($"//div[text()='{expectedText}']")));

            // Get the actual text of the element
            string actualText = homeElement.Text;

            // Console.WriteLine($"Expected Text:{expectedText}, Actual Text: {actualText}");
            Console.WriteLine("Expected Text: " + expectedText + ", Actual Text: " + actualText);


            // Assert that the actual text is equal to the expected text
            Assert.AreEqual(expectedText, actualText);

        }

        [When(@"Click on Setting Page and Reset the Password")]
        public void WhenClickOnSettingPageAndResetThePassword()
        {
            _passResetPage.PasswordReset(_Password, _NewPassword, _NewPassword);

        }
        // Assertion step to verify logout after changing the password
        [Then(@"After Chaning the Password the User Should get LogOut")]
        public void ThenAfterChaningThePasswordTheUserShouldGetLogOut()
        {
            {
                // Wait for the login button to be visible, indicating the user is on the login page
                IWebElement loginButton = wait.Until(drv => drv.FindElement(By.XPath("//button[contains(@class,'d-flex justify-content-center')]")));

                // Checking if the login button is displayed
                if (loginButton.Displayed)
                {
                    // If login button is displayed, printing success message in Console
                    Console.WriteLine("Password has been changed successfully and the user is redirected to the login page.");
                }
                else
                {
                    // If login button is not displayed, failing the test
                    Assert.Fail("The user was not logged out after changing the password.");
                }
            }
        }
        // AfterScenario hook to quit the WebDriver
        [AfterScenario]
        public void TearDown()
        {
            
                driver.Quit();

        }
    }
}



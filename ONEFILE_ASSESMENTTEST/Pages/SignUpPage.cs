using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ONEFILE_ASSESMENTTEST.Pages;
using TechTalk.SpecFlow;
using OpenQA.Selenium.DevTools.V123.Network;

namespace ONEFILE_ASSESMENTTEST.Pages
{
    public class SignUpPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //private IWebElement acceptCookiesButton;
        //private Actions action;

        public SignUpPage(IWebDriver driver)
        {
            
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


       // private IWebElement acceptCookiesButton = wait.Until(drv => drv.FindElement(By.Id("hs-eu-confirmation-button")));
        private IWebElement loginLink => wait.Until(drv => drv.FindElement(By.LinkText("Log in")));
        private IWebElement CreateNewKeyCha => wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Create new keychain']")));
        private IWebElement FirstName => wait.Until(drv => drv.FindElement(By.XPath("//input[@id='fistName']")));
        private IWebElement LastName => wait.Until(drv => drv.FindElement(By.XPath("//input[@id='lastName']")));
        private IWebElement EmailField => wait.Until(drv => drv.FindElement(By.XPath("//input[@id='email']")));
        private IWebElement PasswordField => wait.Until(drv => drv.FindElement(By.XPath("//input[@id='newPassword']")));
        private IWebElement ConfirmPasswordField => wait.Until(drv => drv.FindElement(By.XPath("//input[@id='confirmPassword']")));
        private IWebElement TermsCheckbox => wait.Until(drv => drv.FindElement(By.XPath("//div[@role='checkbox']")));
        private IWebElement RegisterButton => wait.Until(drv => drv.FindElement(By.XPath("//button[contains(@class,'mt-3 w-100')]")));
        private IWebElement BackToLoginButton => wait.Until(drv => drv.FindElement(By.XPath("//button[@rapidbutton='full']")));


        public void AcceptCookiesAndLoginLink()
        {
                //acceptCookiesButton.Click();
                loginLink.Click();
        }
        public void CreateNewKeyChain()
        {
            CreateNewKeyCha.Click();
        }
        public void FirstAndLastName(String FName, String LName)
        {
            FirstName.SendKeys(FName);
            LastName.SendKeys(LName);
        }
        public void UniqueEmail(String Email)
        {
            EmailField.SendKeys(Email);
        }

        public void Password(String Pass)
        {
            PasswordField.SendKeys(Pass);
        }

        public void ConfirmPassword(String ConPass)
        {
            ConfirmPasswordField.SendKeys(ConPass);
        }

        public void TermAndCondition()
        {

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TermsCheckbox));

            ScrollToElement(TermsCheckbox);

            TermsCheckbox.Click();

        }

        public void Registration()
        {
            ScrollToElement(RegisterButton);
            RegisterButton.Click();
        }

        private void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

        }
        
        public void BackToLogin()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(BackToLoginButton));

            BackToLoginButton.Click();
        }

        
    }


}
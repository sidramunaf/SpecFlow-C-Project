using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEFILE_ASSESMENTTEST.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(@class,'d-flex justify-content-center')]"));


        public void Login(String KeyEmail, String KeyPass)
        {
            EmailField.SendKeys(KeyEmail);
            PasswordField.SendKeys(KeyPass);
            LoginButton.Click();
        }










    }
}

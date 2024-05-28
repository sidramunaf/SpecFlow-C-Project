using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEFILE_ASSESMENTTEST.Pages
{
    public class PassResetPage
    {
        private readonly IWebDriver driver;

        public PassResetPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SettingButton => driver.FindElement(By.XPath("//span[@class='rapid-icon rapid-icon--settings']"));
        private IWebElement KeyChainSetting => driver.FindElement(By.XPath("//span[text()='Keychain Settings']"));
        private IWebElement CurrentPassword => driver.FindElement(By.XPath("//input[@id='currentPassword']"));
        private IWebElement NewPassword => driver.FindElement(By.XPath("//input[@id='newPassword']"));
        private IWebElement ConfirmNewPass => driver.FindElement(By.XPath("//input[@id='confirmPassword']"));
        private IWebElement ChangePasswordButton => driver.FindElement(By.XPath("//button[text()=' Change Password ']"));


        public void PasswordReset(String _Password, String _NewPassword, String _ConfirmPassword)
        {
            SettingButton.Click();
            KeyChainSetting.Click();
            Thread.Sleep(3000);
            ScrollToElement(CurrentPassword);
            CurrentPassword.SendKeys(_Password);
            NewPassword.SendKeys(_NewPassword);
            ConfirmNewPass.SendKeys(_NewPassword);
            ChangePasswordButton.Click();

        }

        private void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

        }
    }
}

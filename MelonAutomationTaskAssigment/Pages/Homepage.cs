using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonAutomationTaskAssigment.Pages
{
    class Homepage
    {
        IWebDriver _driver;
        WebDriverWait wait;
        public Homepage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void OpenAlleKategorienMenu()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"button[data-qa='cookiesAgreementAcceptBtn']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-qa='headerCategoriesOpenBtnDesktop']"))).Click();
        }

        public void ClickAlleKategorienHeaderMenu()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[data-qa='headerCategoriesTreeTitleLink']"))).Click();
        }


    }
}

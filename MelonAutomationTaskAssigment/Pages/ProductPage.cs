using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MelonAutomationTaskAssigment.Steps
{
    class ProductPage
    {
        IWebDriver _driver;
        WebDriverWait wait;
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        public void ClickAddToCartbutton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-qa='productDetailspageSideBoxBtnsAddToCart']"))).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[@data-qa='productDetailspageSideBoxBtnsAddToCart'][contains(@class,'c-buttonAddToCart--success')]")));
        }
    }
}

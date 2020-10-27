using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace MelonAutomationTaskAssigment.Steps
{
    class CategoriesPage
    {
        IWebDriver _driver;
        WebDriverWait wait;
        public CategoriesPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void ClickRandomCategory()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h3[@data-qa='allCategoriesPageCategoryName']/a")));
            IList<IWebElement> elem = _driver.FindElements(By.XPath("//h3[@data-qa='allCategoriesPageCategoryName']/a"));
            Random r = new Random();
            int randnum = r.Next(elem.Count);
            var element = elem[randnum];
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.XPath("//h3[@data-qa='allCategoriesPageCategoryName']"));
                    if (el.Displayed & el.Enabled)
                    {
                        element.Click();
                        return el;
                    }
                    else
                    {
                        return null;
                    }

                }

                catch (Exception e)
                {
                    if (e is NoSuchElementException || e is StaleElementReferenceException || e is ElementClickInterceptedException)
                        return null;
                    throw new WebDriverException("Timeout while waiting for element");
                }
            });
        }

        public void ClickRandomProduct()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-qa='searchResultPageContent']/div/a")));
            IList<IWebElement> elem = _driver.FindElements(By.XPath("//div[@data-qa='searchResultPageContent']/div/a"));
            Random r = new Random();
            int randnum = r.Next(elem.Count);
            var element = elem[randnum];
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.XPath("//div[@data-qa='searchResultPageContent']/div/a"));
                    if (el.Displayed & el.Enabled)
                    {
                        element.Click();
                        return el;
                    }
                    else
                    {
                        return null;
                    }

                }

                catch (Exception e)
                {
                    if (e is NoSuchElementException || e is StaleElementReferenceException || e is ElementClickInterceptedException)
                        return null;
                    throw new WebDriverException("Timeout while waiting for element");
                }
            });
        }
    }
}

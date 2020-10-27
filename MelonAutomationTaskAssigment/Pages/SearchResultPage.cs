using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace MelonAutomationTaskAssigment
{
    public class SearchResultPage
    {
        #region locators
        By SearchInput = By.Id("hd-search__input");

        #endregion

        IWebDriver _driver;
        WebDriverWait wait;
        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void SearchFor(string keyword)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"button[data-qa='cookiesAgreementAcceptBtn']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            _driver.FindElement(SearchInput).SendKeys(keyword+Keys.Enter);
        }

        public void ClickPaginationNumber(int pagenum)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", _driver.FindElement(By.CssSelector($"footer")));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"a[data-page='{pagenum - 1}']"))).Click();
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.CssSelector($"a[data-page='{pagenum - 1}']"));
                    if( el.Displayed & el.Enabled)
                    {
                        el.Click();
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

        public void CheckPaginationNumberShown(int pagenum)
        {
            NUnit.Framework.Assert.DoesNotThrow(() => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"a[data-page='{pagenum-1}']"))), "Pagination list number is not shown");
        }

        public void CheckForPaginationNumberActive(int pagenum)
        {
            NUnit.Framework.Assert.DoesNotThrow(() => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"a[data-page='{pagenum-1}'][data-qa='paginationLinkActive']"))), "Pagination list number is not active");
        }

        public int currentpagenumber()
        {
            string num = _driver.FindElement(By.CssSelector("a[data-qa='paginationLinkActive']")).GetAttribute("data-page");
            int pagenum = int.Parse(num);
            return pagenum;
        }
        public void ClickNextButtonOnPagination()
        {
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.CssSelector("a[data-qa='paginationLinkNext']"));
                    if (el.Displayed & el.Enabled)
                    {
                        el.Click();
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

        public void ClickPrevButtonOnPagination()
        {
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.CssSelector("a[data-qa='paginationLinkPrev']"));
                    if (el.Displayed & el.Enabled)
                    {
                        el.Click();
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

        public void ClickThreeDotsNext()
        {
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.XPath("//a[@data-qa='paginationLinkNext']/ancestor::li/preceding-sibling::li[2]/a[contains(text(),'...')]")); // a hell of an xpath (showing off)
                    if (el.Displayed & el.Enabled)
                    {
                        el.Click();
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

        public void ClickLastPage()
        {
            wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(By.XPath("//a[@data-qa='paginationLinkNext']/ancestor::li/preceding-sibling::li[1]/a")); // this element is always the last page 
                    if (el.Displayed & el.Enabled)
                    {
                        el.Click();
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

        public void CheckIfNextButtonDissapears()
        {
            try
            {
                _driver.FindElement(By.CssSelector("a[data-qa='paginationLinkNext']"));
            }
            catch(Exception)
            {
                _driver.FindElement(By.XPath("//nav[@data-qa='pagination']/descendant::li"));
            }

        }
    }
}

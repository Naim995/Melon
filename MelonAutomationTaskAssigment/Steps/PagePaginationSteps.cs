using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using BoDi;
using System.ComponentModel;

namespace MelonAutomationTaskAssigment.Features
{
    [Binding]
    public class PagePaginationSteps
    {
        IWebDriver driver;
        SearchResultPage _searchresultpage;
        [BeforeScenario]
        public void ChromeDriverSetup()
        {
            driver = new ChromeDriver();
            _searchresultpage = new SearchResultPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://de.myworld.com/");
        }



        [Given(@"a user searches for (.*) on the search box")]
        public void GivenAUserSearchesForBookOnTheSearchBox(string keyword)
        {
            _searchresultpage.SearchFor(keyword);
        }

        [Given(@"number (.*) is shown on the pagination list")]
        public void GivenNumberIsShownOnThePaginationList(int pagenum)
        {
            _searchresultpage.CheckPaginationNumberShown(pagenum);
        }


        [When(@"a user clicks number (.*) on the pagination list")]
        public void WhenClicksWeiter(int pagenum)
        {
            _searchresultpage.ClickPaginationNumber(pagenum);
        }

        [When(@"page number (.*) is loaded succesfully")]
        [Then(@"page number (.*) is loaded succesfully")]
        public void ThenPageNumberIsLoadedSuccesfully(int pagenum)
        {
            _searchresultpage.CheckForPaginationNumberActive(pagenum);
        }

        [Given(@"user clicks Next")]
        [When(@"user clicks Next")]
        public void WhenUserClicksNext()
        {
            int currentpagenum;
            int pageNumAfterClickingNext;
            //steps 
            currentpagenum = _searchresultpage.currentpagenumber();
            _searchresultpage.ClickNextButtonOnPagination(); 
            pageNumAfterClickingNext = _searchresultpage.currentpagenumber();
            //assert next page is loaded
            NUnit.Framework.Assert.IsTrue(pageNumAfterClickingNext == currentpagenum + 1);
        }

        [Given(@"user clicks Prev")]
        [When(@"user clicks Prev")]
        public void WhenUserClicksPrev()
        {
            int currentpagenum;
            int pageNumAfterClickingNext;
            //steps
            currentpagenum = _searchresultpage.currentpagenumber();
            _searchresultpage.ClickNextButtonOnPagination();
            pageNumAfterClickingNext = _searchresultpage.currentpagenumber();
            //assert previous page is loaded
            NUnit.Framework.Assert.IsTrue(pageNumAfterClickingNext == currentpagenum + 1);
        }

        [When(@"clicks the three dots for next")]
        public void WhenClicksTheThreeDotsForNext()
        {
            int currentpagenum;
            int pageNumAfterClickingNext;

            currentpagenum = _searchresultpage.currentpagenumber();
            _searchresultpage.ClickThreeDotsNext();
            pageNumAfterClickingNext = _searchresultpage.currentpagenumber();

            //assert previous page is loaded
            NUnit.Framework.Assert.IsTrue(pageNumAfterClickingNext == currentpagenum + 1);
        }

        [Given(@"clicks the last page")]
        [When(@"clicks the last page")]
        public void WhenClicksTheLastPage()
        {
            _searchresultpage.ClickLastPage();
            _searchresultpage.CheckIfNextButtonDissapears();
        }


        [AfterScenario]
        public void DisposeDriverAfterScenario()
        {
            driver.Quit();
        }
    }
}

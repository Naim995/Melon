using BoDi;
using MelonAutomationTaskAssigment.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MelonAutomationTaskAssigment.Steps
{
    [Binding]
    public class ShopingCartCechkValuesSteps
    {
        IWebDriver driver1;
        Homepage _homepage;
        CategoriesPage _catpage;
        ProductPage _prodpage;
        IObjectContainer objectContainer;
        ScenarioContext sctx;
        public ShopingCartCechkValuesSteps(IObjectContainer _objcontainer, ScenarioContext _sctx, IWebDriver driver)
        {
            _homepage = new Homepage(driver);
            _catpage = new CategoriesPage(driver);
            _prodpage = new ProductPage(driver);
            driver1 = driver;
            objectContainer = _objcontainer;
            this.sctx = _sctx;
        }
        
        [Given(@"a user clicks Alle Kategorien")]
        public void GivenAUserClicksAlleKategorien()
        {
            _homepage.OpenAlleKategorienMenu();
        }
        
        [Given(@"clicks Alle Kategorien link")]
        public void GivenClicksAlleKategorienLink()
        {
            _homepage.ClickAlleKategorienHeaderMenu();
        }
        
        [Given(@"clicks on random category")]
        public void GivenClicksOnRandomCategory()
        {
            _catpage.ClickRandomCategory();
        }
        
        [Given(@"clicks on random product")]
        public void GivenClicksOnRandomProduct()
        {
            _catpage.ClickRandomProduct();
        }
        
        [Given(@"adds the product to the shopping card")]
        public void GivenAddsTheProductToTheShoppingCard()
        {
            _prodpage.ClickAddToCartbutton();
        }

        [When(@"the user opens the shopping cart")]
        public void WhenTheUserOpensTheShoppingCart()
        {
            _prodpage.ClickCart();
        }

        [Then(@"the price of the product matches the price on the cart")]
        public void ThenThePriceOfTheProductMatchesThePriceOnTheCart()
        {
            _prodpage.CheckProductPriceValue();
        }

    }
}

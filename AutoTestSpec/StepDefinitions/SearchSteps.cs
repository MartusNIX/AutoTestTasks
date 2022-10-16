using AutoTestSpec.Hooks;
using AutoTestTasks.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AutoTestSpec.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly HomePage _homePage;
        private readonly ResultSearchPage _resultSearchPage;
        private readonly CartPage _cartPage;
        private readonly ProductPage _productPage;

        private string productPriceNew;
        private string productName;
        private string title1Product;
        private string title2Product;
        private string color1Product;
        private string color2Product;
        private string price1Product;
        private string price2Product;
        private string qty1Product;
        private string qty2Product;
        private string total1Product;
        private string total2Product;
        private string removeProductID;

        string colorSize;

        public SearchSteps(BrowserDrivers browserDrivers)
        {
            _homePage = new HomePage(browserDrivers.Current);
            _resultSearchPage = new ResultSearchPage(browserDrivers.Current);
            _cartPage = new CartPage(browserDrivers.Current);
            _productPage = new ProductPage(browserDrivers.Current);
        }

        [Given(@"the browser is opened on the home page")]
        public void GivenTheBrowserIsOpenedOnTheMainPage()
        {
            var expectedTitle = "My Store";
            var actualTitle = _homePage.pageTitle;
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Given(@"the word <Summer> is inserted in the search field")]
        public void GivenTheWordEnteredWordIsInsertedInSearchField()
        {
            _homePage.InsertWordInSearchfield("Summer");
        }

        [Given(@"the word <Blouse> is inserted in the search field")]
        public void GivenTheWordBlouseIsInsertedInSearchField()
        {
            _homePage.InsertWordInSearchfield("Blouse");
        }

        [Given(@"the magnifier is clicked")]
        public void GivenTheMagnifierIsClicked()
        {
            _homePage.ClickSearchBtnOnSearchPage();
        }

        [Given(@"the first displayed product is opened")]
        public void GivenTheFirstProductPageIsOpened()
        {
            _resultSearchPage.ClickOnMoreOnResultPage();
        }

        [Given(@"the product properties are set")]
        public void GivenTheProductPropertiesIsChecked()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("3");
            _productPage.SelectLargeSize();
            _productPage.SelectBlackColor();

            title1Product = _productPage.GetProductTitle();
            price1Product = _productPage.GetProductPrice();
        }

        [When(@"the user clicks on the magnifier")]
        public void WhenTheUserClicksOnTheMagnifier()
        {
            _homePage.ClickSearchBtnOnSearchPage();
        }

        [Then(@"the user see the same words in the search field and the search header")]
        public void ThenTheUserSeeTheSameWordsInSearchFieldAndTheSearchHeader()
        {
            var insertedWord = _resultSearchPage.GetInsertedWord();
            var displayedWordInHeader = _resultSearchPage.GetDisplayedWord();
            Assert.AreEqual(insertedWord, displayedWordInHeader);
        }

        [Given(@"the price sorted by downgrade")]
        public void GivenTheUserPressedSortingPriceByDowngrade()
        {
            _resultSearchPage.ClickDropdownProductSortHighFirst();
        }

        [When(@"the user pressed sorting price by downgrade")]
        public void WhenTheUserPressedSortingPriceByDowngrade()
        {
            _resultSearchPage.ClickDropdownProductSortHighFirst();
        }

        [Then(@"the elements are displayed sorted")]
        public void ThenTheElementsAreDisplayedSorted()
        {
            var price1 = GetPrice(_resultSearchPage.elementPriceOld1);
            var price2 = GetPrice(_resultSearchPage.elementPrice2);
            var price3 = GetPrice(_resultSearchPage.elementPriceOld3);
            var price4 = GetPrice(_resultSearchPage.elementPrice4);

            Console.WriteLine("{0} {1} {2} {3}", price1, price2, price3, price4);

            Assert.Multiple(() =>
            {
                Assert.Greater(price1, price2);
                Assert.Greater(price2, price3);
                Assert.Greater(price3, price4);
            });
        }
        private float GetPrice(IWebElement element)
        {
            return float.Parse(element.Text.Trim('$'));
        }

        [When(@"the user added first product in cart")]
        public void WhenTheUserAddedFirstProductInCart()
        {
            _resultSearchPage.ClickOnFirstProduct();
        }

        [Then(@"the user go to product card page")]
        public void ThenTheUserGoToProductCardPage()
        {
            productPriceNew = _resultSearchPage.GetNewProductPrice();
            productName = _resultSearchPage.GetProductName();
            _resultSearchPage.ClickOnLProceedToCheckoutBtn();
        }

        [Then(@"the name of product on result page and chart page are equal")]
        public void ThenTheNameOfProductOnResultPageAndChartPageAreEqual()
        {
            var priceFromFirstProductOnCartPage = _cartPage.Get1PriceProductPriceOnCartPage();
            var titleProductCartPage = _cartPage.Get1ProductTitleOnCartPage();
            Assert.AreEqual(priceFromFirstProductOnCartPage, productPriceNew);
            Assert.AreEqual(titleProductCartPage, productName);
        }

        [Given(@"the Add_to_cart btn is clicked")]
        public void GivenTheAdd_To_CartButtonClicked()
        {
            _productPage.ClickAddToCardBtn();
        }

        [When(@"the Add_to_cart button is clicked")]
        public void WhenTheAdd_To_CartButtonClicked()
        {
            _productPage.ClickAddToCardBtn();
        }

        [Then(@"the user see that products successfully added to the shopping cart in pop-up")]
        public void ThenTheUserSeeThatProductsSuccessfullyAddedToTheShoppingCartInPop_Up()
        {
            bool actualResult = _productPage.ModalWindowIsShown();
            Assert.True(actualResult);
        }

        [Given(@"the Continue_shopping btn is clicked")]
        public void GivenTheContinue_ShoppingBttnIsClicked()
        {
            _productPage.ClickContinueShoppingBtn();
            color1Product = _productPage.GetProductColor();
            qty1Product = _productPage.GetProductQty();
            total1Product = _productPage.GetProductTotal();         
        }

        [Given(@"the Printed_summer_dress is inserted in search")]
        public void GivenThePrinted_Summe_DressIsInsertedInSearch()
        {
            _productPage.ClearPreviousDataFromSearch();
            _productPage.InsertWordInSearchfield("Printed summer dress");
        }

        [Given(@"the magnifier is clicked on the product page")]
        public void GivenTheMagnifierIsClickedOnProductPage()
        {
            _productPage.ClickSearchBtn();
        }

        [Given(@"the properties for second product is checked")]
        public void GivenThePropertiesForSecondProductIsChecked()
        {
            _productPage.ClearPreviousDataFromQuantity();
            _productPage.InsertWordInInputField("5");
            _productPage.SelectMediumSize();
            _productPage.SelectOrangeColor();

            title2Product = _productPage.GetProductTitle();
            price2Product = _productPage.GetProductPrice();

        }

        [When(@"the user clicks the Proceed_to_checkout btn")]
        public void WhenTheUserClicksTheProceed_To_CheckoutBtn()
        {
            //Thread.Sleep(4000);
            Task.Delay(4000).Wait();
            color2Product = _productPage.GetProductColor();
            qty2Product = _productPage.GetProductQty();
            total2Product = _productPage.GetProductTotal();
            colorSize = _productPage.GetColorSize();
            Console.WriteLine(colorSize, color2Product, qty2Product, total2Product);

            _productPage.ClickCheckoutBtn();
        }

        [Then(@"two product displayed correctly")]
        public void ThenTwoProductDisplayedCorrectly()
        {
            var titleProductCart1 = _cartPage.Get1ProductTitleOnCartPage();
            StringAssert.IsMatch(titleProductCart1, title1Product);
            Console.WriteLine("Title_cart1= {0} Title_product1= {1}", titleProductCart1, title1Product);
            var titleProductCart2 = _cartPage.Get2ProductTitleOnCartPage();
            Console.WriteLine("Title_cart2= {0} Title_product2= {1}", titleProductCart2, title2Product);
            StringAssert.IsMatch(titleProductCart2, title2Product);

            var colorProductCart1 = _cartPage.Get1ProductColorCartPage();
            Console.WriteLine("Color_cart1= {0} Color_product1= {1}", colorProductCart1, color1Product);
            var colorProductCart2 = _cartPage.Get2ProductColorCartPage();
            Console.WriteLine("Color_cart2= {0} Color_product2= {1}", colorProductCart2, color2Product/*colorSize*/);

            var priceProductCart1 = _cartPage.Get1PriceProductPriceOnCartPage();
            Console.WriteLine("Price_cart1= {0} Price_product1= {1}", priceProductCart1, price1Product);
            var priceProductCart2 = _cartPage.Get2PriceProductOnCartPage();
            Console.WriteLine("Price_cart2= {0} Price_product2= {1}", priceProductCart2, price2Product);

            var qtyProduct1 = _cartPage.Get1ProductQtyCardPage();
            Console.WriteLine("QTY_cart1= {0} QTY_product1= {1}", qtyProduct1, qty1Product);
            var qtyProduct2 = _cartPage.Get2ProductQtyCardPage();
            Console.WriteLine("QTY_cart2= {0} QTY_product2= {1}", qtyProduct2, qty2Product);

            var totalPrice1 = _cartPage.GetTotal1ProductCartPage();
            Console.WriteLine("Total_cart1= {0} Total_product1= {1}", totalPrice1, total1Product);
            var totalPrice2 = _cartPage.GetTotal2ProductCartPage();
            Console.WriteLine("Total_cart2= {0} Total_product2= {1}", totalPrice2, total2Product);
        }

        [Given(@"the Proceed_to_checkout is clicked")]
        public void GivenTheProceed_To_CheckoutIsClicked()
        {
            _productPage.ClickCheckoutBtn();
        }

        [When(@"the user clicks Delete btn")]
        public void WhenTheUserClicksDeleteBtn()
        {
/*
            removeProductID = _cartPage.Get2ProductID();
            removeProductID.
            Console.WriteLine("removeProductID: {0}", removeProductID);
            foreach (IWebElement element in _cartPage.GetProductsList())
            {
                Console.WriteLine("element before delete: {0}", element);
            }*/
            _cartPage.ClickOnDelete2();

            //Thread.Sleep(6000);


            /*foreach (var element in _cartPage.GetProductsList())
            {
                Console.WriteLine("element after delete: {0}", element);
            }*/
        }

/*        public static bool IsElementDisplayed(this IWebDriver driver, By element)
        {
            if (driver.FindElements(element).Count > 0)
            {
                if (driver.FindElement(element).Displayed)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }*/

        [Then(@"the chosen product is deleted")]
        public void ThenTheChosenProductIsDeleted()
        {
           
           /* Console.WriteLine("Get Product List:");
            foreach (IWebElement element in _cartPage.GetProductsList())
            {
                Console.WriteLine("element: {0}", element);
            }
            Console.WriteLine("_cartPage.Get2ProductID(): {0}", _cartPage.Get2ProductID());*/
            //CollectionAssert.DoesNotContain(_cartPage.GetProductsList(), removeProductID);
            
            //var isDisplayed = _cartPage.IsDisplayedProduct();
            //Console.WriteLine("Product is displayed on page {0}", isDisplayed);
            
            /*CollectionAssert.Contains(_cartPage.GetProductsList(), _cartPage.Get2ProductID());*/
            var isSecondProductDisplayed = _cartPage.IsSecondProductDisplayed();
            Console.WriteLine("isSecondProductDisplayed : {0}", isSecondProductDisplayed);
        }

        /*        [Then(@"the product not displ")]
                public void ThenTheProductNotDispl()
                {
                    *//*Task.Delay(4000).Wait();*//*
                    var list = _cartPage.GetProductsList();
                    Assert.That(list, Has.Member(_cartPage.Get2ProductID()));
                    *//*foreach (IWebElement liElement in list)
                    {
                        Console.WriteLine(liElement.GetAttribute("id"));
                    }*//*
                }*/
    }
}

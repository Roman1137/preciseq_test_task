using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace preciseq_test_task.pages
{
    public class MainSinopticControl : BaseControl
    {
        public MainSinopticControl(IWebDriver driver) : base(driver) { }

        public MainSinopticControl Open()
        {
            driver.Url = "https://sinoptik.ua/";
            WaitUntilIsDisplayed(this.SeachCityFieldLocator);

            return this;
        }

        public void SearchByValue(string valueForSearch)
        {
            EnterText(this.SeachCityFieldElement, valueForSearch);
            this.SearchCitySubmitButtonElement.Click();
            WaitUntilSearchPageIsOpened(valueForSearch);
        }

        private void WaitUntilSearchPageIsOpened(string valueForSearch)
        {
            var valueToSearchRoot = valueForSearch.Remove(valueForSearch.Length / 2);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(dr => GetCityNameRoot(this.CityNameHeaderElement.Text)
                .Contains(valueToSearchRoot));
        }

        private string GetCityNameRoot(string cityHeaderText)
        {
            var cityFullName = cityHeaderText.Split(' ').Last();
            var cityNameRoot = cityFullName.Remove(cityFullName.Length/2);

            return cityNameRoot;
        }

        public string SeachCityFieldLocator => "#search_city";
        public string SearchCitySubmitButtonLocator => ".search_city-submit";
        public string CityNameHeaderLocator => ".cityName h1";

        public IWebElement SeachCityFieldElement => driver.FindElement(By.CssSelector(this.SeachCityFieldLocator));
        public IWebElement SearchCitySubmitButtonElement => driver.FindElement(By.CssSelector(this.SearchCitySubmitButtonLocator));
        public IWebElement CityNameHeaderElement => driver.FindElement(By.CssSelector(this.CityNameHeaderLocator));
    }
}
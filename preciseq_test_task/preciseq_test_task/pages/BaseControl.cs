using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace preciseq_test_task.pages
{
    public class BaseControl
    {
        public IWebDriver driver;
        public BaseControl(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
        }

        protected void WaitUntilIsDisplayed(string locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                Message = $"Locator {locator} should have been displayed at the page"
            };

            wait.Until(x => x.FindElement(By.CssSelector(locator)).Displayed);
        }

        protected void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}

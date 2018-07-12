using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using preciseq_test_task.model;

namespace preciseq_test_task.pages
{
    public class DaysBlockControl : BaseControl
    {
        public DaysBlockControl(IWebDriver driver) : base(driver) { }

        public void OpenTabByDayName(string dayName)
        {
            var dayTabToOpen = DayBlockElements.Single(elm => elm.Text.Contains(dayName));
            dayTabToOpen.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(dr => dayTabToOpen.GetAttribute("className").Contains("loaded"));
        }

        public ContentTabModel GetOpenedTabModel()
        {
            var openedTabElement = GetOpenedTab();

            return new ContentTabModel
            {
                Day = GetDayOfWeekElement(openedTabElement).Text,
                Date = GetDateElement(openedTabElement).Text,
                Month = GetMonthElement(openedTabElement).Text,
                InfoDayLight = GetInfoDayLightElement(openedTabElement).Text,
                InfoHistory = GetInfoHistoryElement(openedTabElement).Text,
                InfoHistoryValues = GetInfoHistoryValElement(openedTabElement).Text,
                DescriptionFirstParagraph = GetDescriptionFirstParagraphElement(openedTabElement).Text,
                DescriptionSecondParagraph = GetDescriptionSecondParagraphElement(openedTabElement).Text,
                PeriodStartTime = new TimeModel(GetPeriodStartTimeElements(openedTabElement)),
                Temperature = new TimeModel(GetTemperatureElements(openedTabElement)),
                TemperatireSens = new TimeModel(GetTemperatireSensElements(openedTabElement)),
                Pressure = new TimeModel(GetPressureElements(openedTabElement)),
                Humidity = new TimeModel(GetHumidityElements(openedTabElement)),
                Wind = new TimeModel(GetWindElements(openedTabElement)),
                PrecipitationPossibility = new TimeModel(GetPrecipitationPossibilityElements(openedTabElement))
            };
        }

        private string GetOpenedTabLocator() => BlockDaysControlElement.GetAttribute("className");

        private IWebElement GetOpenedTab()
        {
            var openedDayLocator = GetOpenedTabLocator();
            var openedTabElement = GetOpenedTabElement(openedDayLocator);

            return openedTabElement;
        }

        private string BlockDaysControlLocator => "#blockDays";
        private IWebElement BlockDaysControlElement => driver.FindElement(By.CssSelector(this.BlockDaysControlLocator));

        #region DaysTabsLocatorsAndElements
        public string DayBlockLocator => ".main";
        public IReadOnlyCollection<IWebElement> DayBlockElements => driver.FindElements(By.CssSelector(this.DayBlockLocator));
        #endregion

        #region TabsContentLocatorsAndElements

        private string TabLocator => ".Tab";

        private string DayOfWeekLocator => ".infoDayweek";
        private string DateLocator => ".infoDate";
        private string MonthLocator => ".infoMonth";
        private string InfoDayLightLocator => ".infoDaylight";
        private string InfoHistoryLocator => ".infoDaylight";
        private string InfoHistoryValLocator => ".infoHistoryval";
        private string DescriptionFirstParagraphLocator => ".wDescription .description";
        private string DescriptionSecondParagraphLocator => ".oDescription .description";
        private string PeriodStartTimeLocator => ".gray.time td";
        private string TemperatureLocator => ".temperature td";
        private string TemperatireSensLocator => ".temperatureSens td";
        private string PressureLocator => ".gray:nth-child(5) td";
        private string HumidityLocator => "tbody tr:nth-of-type(6) td";
        private string WindSpeedLocator => ".gray:nth-child(7) td";
        private string PrecipitationPossibilityLocator => "tbody tr:nth-of-type(8) td";


        private IWebElement GetOpenedTabElement(string tabLocator) => driver.FindElement(By.CssSelector($"{TabLocator}[id*={tabLocator}]"));


        private IWebElement GetDayOfWeekElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.DayOfWeekLocator));
        private IWebElement GetDateElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.DateLocator));
        private IWebElement GetMonthElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.MonthLocator));
        private IWebElement GetInfoDayLightElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.InfoDayLightLocator));
        private IWebElement GetInfoHistoryElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.InfoHistoryLocator));
        private IWebElement GetInfoHistoryValElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.InfoHistoryValLocator));
        private IWebElement GetDescriptionFirstParagraphElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.DescriptionFirstParagraphLocator));
        private IWebElement GetDescriptionSecondParagraphElement(IWebElement openedTabElement) => openedTabElement.FindElement(By.CssSelector(this.DescriptionSecondParagraphLocator));
        private IList<IWebElement> GetPeriodStartTimeElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.PeriodStartTimeLocator));
        private IList<IWebElement> GetTemperatureElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.TemperatureLocator));
        private IList<IWebElement> GetTemperatireSensElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.TemperatireSensLocator));
        private IList<IWebElement> GetPressureElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.PressureLocator));
        private IList<IWebElement> GetHumidityElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.HumidityLocator));
        private IList<IWebElement> GetWindElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.WindSpeedLocator));
        private IList<IWebElement> GetPrecipitationPossibilityElements(IWebElement openedTabElement) => openedTabElement.FindElements(By.CssSelector(this.PrecipitationPossibilityLocator));
        #endregion
    }
}


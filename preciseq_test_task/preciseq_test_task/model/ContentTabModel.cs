using System.Collections.Generic;
using OpenQA.Selenium;

namespace preciseq_test_task.model
{
    public class ContentTabModel
    {
        public string Day { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string InfoDayLight { get; set; }
        public string InfoHistory { get; set; }
        public string InfoHistoryValues { get; set; }
        public string DescriptionFirstParagraph { get; set; }
        public string DescriptionSecondParagraph { get; set; }
        public TimeModel PeriodStartTime { get; set; }
        public TimeModel Temperature { get; set; }
        public TimeModel TemperatireSens { get; set; }
        public TimeModel Pressure { get; set; }
        public TimeModel Humidity { get; set; }
        public TimeModel Wind { get; set; }
        public TimeModel PrecipitationPossibility { get; set; }
    }

    public class TimeModel
    {
        public TimeModel(IList<IWebElement> listOfValues)
        {
            this.Night = listOfValues[0].Text;
            this.Day = listOfValues[1].Text;
            this.Evening = listOfValues[2].Text;
            this.Morning = listOfValues[3].Text;
        }

        public string Night { get; set; }
        public string Morning { get; set; }
        public string Day { get; set; }
        public string Evening { get; set; }
    }
}

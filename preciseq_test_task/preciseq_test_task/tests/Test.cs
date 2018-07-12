using FluentAssert;
using NUnit.Framework;
using preciseq_test_task.model;

namespace preciseq_test_task.tests
{
    [TestFixture]
    public class Test : TestBase
    {
        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetTestDataModels))]
        public void VerifySearchCityPressureValues(TestDataModel testDataModel)
        {
            app.MainSinopticControl
                .Open()
                .SearchByValue(testDataModel.CityModel.Name);

            app.DaysBlockControl.OpenTabByDayName(testDataModel.DayModel.Name);

            var openedTabModel = app.DaysBlockControl.GetOpenedTabModel();

            openedTabModel.Day.ShouldBeEqualTo(testDataModel.DayModel.Name);

            int.Parse(openedTabModel.Pressure.Day).ShouldBeGreaterThanOrEqualTo(testDataModel.PressureModel.MinValue);
            int.Parse(openedTabModel.Pressure.Day).ShouldBeLessThanOrEqualTo(testDataModel.PressureModel.MaxValue);

            int.Parse(openedTabModel.Pressure.Morning).ShouldBeGreaterThanOrEqualTo(testDataModel.PressureModel.MinValue);
            int.Parse(openedTabModel.Pressure.Morning).ShouldBeLessThanOrEqualTo(testDataModel.PressureModel.MaxValue);

            int.Parse(openedTabModel.Pressure.Evening).ShouldBeGreaterThanOrEqualTo(testDataModel.PressureModel.MinValue);
            int.Parse(openedTabModel.Pressure.Evening).ShouldBeLessThanOrEqualTo(testDataModel.PressureModel.MaxValue);

            int.Parse(openedTabModel.Pressure.Night).ShouldBeGreaterThanOrEqualTo(testDataModel.PressureModel.MinValue);
            int.Parse(openedTabModel.Pressure.Night).ShouldBeLessThanOrEqualTo(testDataModel.PressureModel.MaxValue);
        }
    }
}

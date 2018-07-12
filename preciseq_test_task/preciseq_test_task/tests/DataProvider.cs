using System.Collections.Generic;
using preciseq_test_task.model;

namespace preciseq_test_task.tests
{
    class DataProvider
    {
        public static IEnumerable<TestDataModel> GetTestDataModels
        {
            get
            {
                yield return new TestDataModel
                {
                    CityModel = new CityModel { Name = "Драгобрат" },
                    DayModel = new DayModel { Name = "Воскресенье" },
                    PressureModel = new PressureModel { MinValue = 600, MaxValue = 700}
                };
            }
        }
    }
}

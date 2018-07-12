using NUnit.Framework;
using preciseq_test_task.app;

namespace preciseq_test_task.tests
{
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void SetUp()
        {
            this.app = new Application();
        }

        [TearDown]
        public void Quit()
        {
            app.Quit();
        }
    }
}

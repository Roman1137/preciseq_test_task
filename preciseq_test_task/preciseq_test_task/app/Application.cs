using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using preciseq_test_task.pages;

namespace preciseq_test_task.app
{
    public class Application
    {
        private EventFiringWebDriver driver;

        public MainSinopticControl MainSinopticControl;
        public DaysBlockControl DaysBlockControl;

        public Application()
        {
            driver = new EventFiringWebDriver(new ChromeDriver());
            this.MainSinopticControl = new MainSinopticControl(driver);
            this.DaysBlockControl = new DaysBlockControl(driver);

            InitializeEvents();
        }

        public void Quit()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var fileName = TestContext.CurrentContext.TestDirectory + "\\" +
                               DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-FFF") + "-" + GetType().Name + "-" +
                               TestContext.CurrentContext.Test.FullName + "." + ScreenshotImageFormat.Jpeg;
                try
                {
                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                    TestContext.AddTestAttachment(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

        public void InitializeEvents()
        {
            driver.FindingElement += (sender, args) => Console.WriteLine($"Looking for elemet {args.FindMethod}");
            driver.FindElementCompleted += (sender, args) => Console.WriteLine($"Element {args.FindMethod} was found");
            driver.ElementClicking += (sender, args) => Console.WriteLine($"Clicking element {args.Element}");
            driver.ElementClicked += (sender, args) => Console.WriteLine($"Element {args.Element} was clicked");
            driver.Navigating += (sender, args) => Console.WriteLine($"Navigating to {args.Url}");
            driver.Navigated += (sender, args) => Console.WriteLine($"Navigated to {args.Url}");
        }
    }
}

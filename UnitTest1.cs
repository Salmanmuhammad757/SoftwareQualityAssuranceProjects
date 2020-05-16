using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;


namespace unittest1
{
    [TestFixture]
    public class unittest1
    {

        public IWebDriver driver;
        protected ExtentReports _extent;
        protected ExtentTest _test;


        [OneTimeSetUp]
        public void BeforeClass()
        {


            try
            {
                //To create report directory and add HTML report into it
                OperatingSystem os = Environment.OSVersion;
                _extent = new ExtentReports();
               
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
                _extent.AddSystemInfo("Title", "Testing Report");
                _extent.AddSystemInfo("Environment", os.ToString());
                _extent.AddSystemInfo("Document type", "Automation testing");
                _extent.AddSystemInfo("TestCreated by", "Muhammad Salman");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
            try
            {
                IWebDriver d = new ChromeDriver();
            }
            catch (Exception e)
            {
                throw (e);
            }

        }


        [SetUp]
        public void BeforeTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [Test]
        public void Opensite()
        {

            driver.Url = "https://www.google.com";
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[@class='gb_le gb_4 gb_5c']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='identifier']")).SendKeys("ms0094449@gmail.com");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='ZFr60d CeoRYc']")).Click();
            Thread.SpinWait(5000);
            driver.Quit();
            Assert.Pass("test case passed");
        }
        [Test]
        public void login()
        {
            driver.Url = "https://";

        }
        [Test]

        public void skiptest()
        {
            Assert.Inconclusive();
            driver.Url = "https://";
        }
        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Quit();
        }

        private string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = ":C";
            try
            {
                Thread.Sleep(4000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}
using MSTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_2
{
    
    [TestClass]
    public class MSTest
    {
        IWebDriver driver;

        public TestContext TestContext { get; set; }
        static int testcounter = 0;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            testContext.WriteLine("MSTest Class SetUp output");
        }

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            driver.Manage().Window.Maximize();
            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
            TestContext.WriteLine("MSTest Test Setup output");
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.AreEqual("Geeks", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
            TestContext.WriteLine("Input text Geeks");
        }

        [Ignore("MSTest ignore")]
        [TestMethod]
        public void TestMethod2()
        {

            TestContext.WriteLine("MSTest method 2 output");
        }

        [TestMethod]
        public void TestMethod3()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.AreEqual("Geek", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }


        [TestCleanup]
        public void MSTestCleanup()
        {
            driver.Dispose();
            Console.WriteLine("Test number {0} is compleated", testcounter);
            TestContext.WriteLine("MSTest Test Cleanup output");
        }

        [ClassCleanup]
        public static void MSClassCleanup()
        {
            int i=0;
        }
    }
}
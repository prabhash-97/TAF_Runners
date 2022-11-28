using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[assembly: LevelOfParallelism(2)]
namespace NUnitTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        static int testcounter = 0;
        IWebDriver driver;

        [OneTimeSetUp]
        public static void NunitTestClassSetup()
        {
            TestContext.WriteLine("Nunit test Class SetUp output");
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            driver.Manage().Window.Maximize();
            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
            TestContext.WriteLine("Nunit test Test SetUp output");
        }

        [Test]
        public void Test1()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.AreEqual("Geeks", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
            TestContext.WriteLine("Input text Geeks");
        }

        [Test]
        [Ignore("NUnit Test ignore")]
        public void Test2()
        {
            TestContext.WriteLine("Nunit test Method 2 output");
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.AreEqual("Geek", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }
        

        [TearDown]
        public void NunitTestCleanup()
        {
            driver.Close();
            Console.WriteLine("Test number {0} is compleated", testcounter);
            TestContext.WriteLine("Nunit test Test CleanUp output");
        }

        [OneTimeTearDown]
        public static void NunitClassCleanup()
        {
            TestContext.WriteLine("Nunit test Class CleanUp output");
        }

    }
}
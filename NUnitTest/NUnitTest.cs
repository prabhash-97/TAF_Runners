using NUnit.Framework.Internal;
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
        public void NunitTestClassSetup()
        {
            TestContext.WriteLine("Nunit test Class SetUp output");

            driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
        }

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Nunit test Test SetUp output");
            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
        }

        private IWebElement username => driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
        private IWebElement password => driver.FindElement(By.XPath("//*[@id=\"password\"]"));
        private IWebElement submitbtn => driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));

        [Test]
        public void UserLogin()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();
            
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);

            TestContext.WriteLine("User logged sucesfully");
        }

        [Test]
        [Ignore("NUnit Test ignore")]
        public void TestIgnore()
        {
            TestContext.WriteLine("Nunit test Method 2 output");
            Assert.Pass();
        }

        [Test]
        public void UserLoginFail()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventor.html", driver.Url);

            TestContext.WriteLine("Login unsucesful");
        }


        [TearDown]
        public void NunitTestCleanup()
        {
            Console.WriteLine("Test number {0} is compleated", testcounter);
            TestContext.WriteLine("Nunit test Test CleanUp output");
        }

        [OneTimeTearDown]
        public void NunitClassCleanup()
        {
            TestContext.WriteLine("Nunit test Class CleanUp output");
            driver.Close();
            
        }

    }
}
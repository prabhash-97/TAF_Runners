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

            TestContext.WriteLine("MSTest Test Setup output");

            driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";

            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
        }

        private IWebElement username => driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
        private IWebElement password => driver.FindElement(By.XPath("//*[@id=\"password\"]"));
        private IWebElement submitbtn => driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));

        [TestMethod]
        public void UserLogin()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);

            TestContext.WriteLine("User logged sucesfully");
        }

        [Ignore("MSTest ignore")]
        [TestMethod]
        public void TestIgnore()
        {
            TestContext.WriteLine("MSTest method 2 output");
        }

        [TestMethod]
        public void LoginFail()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventor.html", driver.Url);

            TestContext.WriteLine("Login unsucesful");
        }


        [TestCleanup]
        public void MSTestCleanup()
        {
            TestContext.WriteLine("MSTest Test Cleanup output");
            driver.Dispose();
            Console.WriteLine("Test number {0} is compleated", testcounter);
        }

        [ClassCleanup]
        public static void MSClassCleanup()
        {
            int i=0;
        }
    }
}
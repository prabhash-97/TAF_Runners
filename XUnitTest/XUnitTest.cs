using Xunit.Abstractions;
using Xunit.Sdk;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XUnitTest
{
    public class XUnitTest : IClassFixture<XUnitSetUpClass>
    {
        private readonly ITestOutputHelper outputHelper;
        IWebDriver driver;

        public XUnitTest(ITestOutputHelper testOutputHelper)
        {
            outputHelper = testOutputHelper;
            driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
        }

        private IWebElement username => driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
        private IWebElement password => driver.FindElement(By.XPath("//*[@id=\"password\"]"));
        private IWebElement submitbtn => driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));


        [Fact]
        public void UserLogin()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();

            Assert.Equal("https://www.saucedemo.com/inventory.html", driver.Url);

            outputHelper.WriteLine("User logged sucesfully"); ;
        }

        [Fact(Skip = "XUnit Test ignore")]
        public void TestIgnore()
        {
            outputHelper.WriteLine("XUnit test Method 2 output");
        }

        [Fact]
        public void LoginFail()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            submitbtn.Click();

            Assert.Equal("https://www.saucedemo.com/inventor.html", driver.Url);

            outputHelper.WriteLine("User logged sucesfully"); ;
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
            
            int i = 0;
        }
    }

    public class XUnitSetUpClass
    {
        public XUnitSetUpClass()
        {
            int i = 0;
        }
    }
}
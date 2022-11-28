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
        }

        [Fact]
        public void Test1()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.Equal("Geeks", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
            outputHelper.WriteLine("Input text Geeks");
        }

        [Fact(Skip = "XUnit Test ignore")]
        public void Test2()
        {
            outputHelper.WriteLine("XUnit test Method 2 output");
        }

        [Fact]
        public void Test3()
        {
            driver.Url = "http://www.google.com";
            string test = "Geeks";
            Assert.Equal("Geek", test);
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(test);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
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
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTest
{
    public class XUnitTest : IClassFixture<XUnitSetUpClass>
    {
        private readonly ITestOutputHelper outputHelper;

        public XUnitTest(ITestOutputHelper testOutputHelper)
        {
            outputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            outputHelper.WriteLine("XUnit test Method 1 output");
        }

        [Fact(Skip = "XUnit Test ignore")]
        public void Test2()
        {
            outputHelper.WriteLine("XUnit test Method 2 output");
        }

        [Fact]
        public void Test3()
        {
            string expected = "test";
            string actual = "test1";
            Assert.Equal(expected, actual);
            outputHelper.WriteLine("expected and actual values are not equal");
        }

        public void Dispose()
        {
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
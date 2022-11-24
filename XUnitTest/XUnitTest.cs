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
            int arg1 = 10;
            int arg2 = 10;
            double expected = 0;

            double result = Calculator.Sub(arg1, arg2);
            Assert.Equal(expected, result);
            outputHelper.WriteLine("expected and actual values are equal");
        }

        [Fact(Skip = "XUnit Test ignore")]
        public void Test2()
        {
            outputHelper.WriteLine("XUnit test Method 2 output");
        }

        [Fact]
        public void Test3()
        {
            int arg1 = 10;
            int arg2 = 10;
            double expected = 21;

            double result = Calculator.Add(arg1, arg2);
            Assert.Equal(expected, result);
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
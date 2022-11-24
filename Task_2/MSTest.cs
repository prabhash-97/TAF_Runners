using MSTest;

namespace Task_2
{
    
    [TestClass]
    public class MSTest
    {
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
            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
            TestContext.WriteLine("MSTest Test Setup output");
        }

        [TestMethod]
        public void TestMethod1()
        {
            int arg1 = 10;
            int arg2 = 10;
            double expected = 0;

            double result = Calculator.Sub(arg1, arg2);
            Assert.AreEqual(expected, result);

            TestContext.WriteLine("expected and actual values are equal");
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
            int arg1 = 10;
            int arg2 = 10;
            double expected = 21;
            
            double result = Calculator.Add(arg1, arg2);
            Assert.AreEqual(expected, result);

            TestContext.WriteLine("expected and actual values are not equal");
        }


        [TestCleanup]
        public void MSTestCleanup()
        {
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
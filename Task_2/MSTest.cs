namespace Task_2
{
    
    [TestClass]
    public class MSTest
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            testContext.WriteLine("MSTest Class SetUp output");
        }

        [TestInitialize]
        public void TestSetup()
        {
            TestContext.WriteLine("MSTest Test Setup output");
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("MSTest method 1 output");
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
            string expected = "test";
            string actual = "test1";
            Assert.AreEqual(expected,actual);

            TestContext.WriteLine("expected and actual values are not equal");
        }

        [TestCleanup]
        public void MSTestCleanup()
        {
            TestContext.WriteLine("MSTest Test Cleanup output");
        }

        [ClassCleanup]
        public static void MSClassCleanup()
        {
            int i=0;
        }
    }
}
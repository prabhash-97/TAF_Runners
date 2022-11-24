[assembly: LevelOfParallelism(2)]
namespace NUnitTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        static int testcounter = 0;

        [OneTimeSetUp]
        public static void NunitTestClassSetup()
        {
            TestContext.WriteLine("Nunit test Class SetUp output");
        }

        [SetUp]
        public void Setup()
        {
            testcounter++;
            Console.WriteLine("Test started number {0}", testcounter);
            TestContext.WriteLine("Nunit test Test SetUp output");
        }

        [Test]
        public void Test1()
        {
            int arg1 = 10;
            int arg2 = 10;
            double expected = 0;

            double result = Calculator.Sub(arg1, arg2);

            Assert.That(result, Is.EqualTo(expected));

            TestContext.WriteLine("expected and actual values are equal");
            Assert.Pass();
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
            int arg1 = 10;
            int arg2 = 10;
            double expected = 21;

            double result = Calculator.Add(arg1, arg2);

            Assert.That(result, Is.EqualTo(expected));

            TestContext.WriteLine("expected and actual values are not equal");
            Assert.Pass();
        }
        

        [TearDown]
        public void NunitTestCleanup()
        {
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
[assembly: LevelOfParallelism(2)]
namespace NUnitTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        [OneTimeSetUp]
        public static void NunitTestClassSetup()
        {
            TestContext.WriteLine("Nunit test Class SetUp output");
        }

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Nunit test Test SetUp output");
        }

        [Test]
        public void Test1()
        {
            TestContext.WriteLine("Nunit test Method 1 output");
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
            string expected = "test";
            string actual = "test1";
            Assert.That(actual, Is.EqualTo(expected));

            TestContext.WriteLine("expected and actual values are not equal");
            Assert.Pass();
        }

        [TearDown]
        public void NunitTestCleanup()
        {
            TestContext.WriteLine("Nunit test Test CleanUp output");
        }

        [OneTimeTearDown]
        public static void NunitClassCleanup()
        {
            TestContext.WriteLine("Nunit test Class CleanUp output");
        }

    }
}
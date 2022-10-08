using NUnit.Framework;

namespace Arrays.Tests
{
    [TestFixture]
    public class LinearSearchTests
    {
        private List<string> names;
        [SetUp]
        public void Setup()
        {
            names = new List<string>() { "Jasmine", "Alaa", "Don", "John", "Juan", "James" };
        }

        [Test]
        [TestCase("Jasmine", 0)]
        [TestCase("Don", 2)]
        [TestCase("James", 5)]
        public void GetIndex_TypeIsStringAndValueExists_ReturnsIndexOfTheItem(string name, int expectedIndex)
        {
            int index = LinearSearch.GetIndex(names, name);

            Assert.That(index, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase("Cameron")]
        public void GetIndex_TypeIsStringAndItemDoesntExist_ReturnsNegativeOne(string name)
        {
            int index = LinearSearch.GetIndex(names, name);

            Assert.That(index, Is.EqualTo(-1));
        }
    }
}
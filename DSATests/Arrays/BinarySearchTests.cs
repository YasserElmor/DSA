using NUnit.Framework;

namespace Arrays.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        private List<int> nums;
        [SetUp]
        public void Setup()
        {
            nums = new() { 1, 3, 5, 11, 18, 25, 43, 100 };
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(3, 1)]
        [TestCase(5, 2)]
        [TestCase(11, 3)]
        [TestCase(18, 4)]
        [TestCase(25, 5)]
        [TestCase(43, 6)]
        [TestCase(100, 7)]
        public void GetIndex_ItemExists_ReturnItsIndex(int val, int expectedIndex)
        {
            int index = LinearSearch.GetIndex(nums, val);

            Assert.AreEqual(index, expectedIndex);
        }

        [Test]
        [TestCase(-15)]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(150)]
        public void GetIndex_ItemDoesntExist_ReturnNegativeOne(int val)
        {
            int index = LinearSearch.GetIndex(nums, val);

            Assert.That(index, Is.EqualTo(-1));
        }
    }
}
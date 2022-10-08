using NUnit.Framework;

namespace Arrays.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private List<int> nums;
        [SetUp]
        public void Setup()
        {
            nums = new List<int>() { 3, 7, 2, -100, 5, 1, 4, 25, -5, -5, 0 };
        }

        [Test]
        public void Sort_Always_ReturnSortedList()
        {
            List<int> result = BubbleSort.Sort(nums);
            List<int> expectedOutput = new List<int>() { -100, -5, -5, 0, 1, 2, 3, 4, 5, 7, 25 };

            Assert.That(result, Is.EquivalentTo(expectedOutput));

        }
    }
}
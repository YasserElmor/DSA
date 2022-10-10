using NUnit.Framework;

namespace LinkedLists.Tests
{

    [TestFixture]
    public class StackTests
    {
        private MockStack<string>? stack;

        [SetUp]
        public void Setup()
        {
            stack = new MockStack<string>();
        }

        [Test]
        public void Push_LengthIsZero_SetHeadToNodeAndIncrementLength()
        {
            stack.Push("Yasser");

            Assert.AreEqual("Yasser", stack.Head!.value);
            Assert.AreEqual(1, stack.length);
        }

        [Test]
        public void Push_LengthIsNotZero_SetHeadNextAndHeadToNewNodeAndIncrementLength()
        {
            stack.Push("Yasser");
            var oldHead = stack.Head;
            stack.Push("Jack");
            var newHead = stack.Head;

            Assert.That(oldHead, Is.EqualTo(newHead.next));
            Assert.That("Jack", Is.EqualTo(newHead.value));
            Assert.AreEqual(2, stack.length);
        }

        [Test]
        public void Pop_LengthIsZero_ReturnNull()
        {
            Assert.That(null, Is.EqualTo(stack.Pop()));
        }

        [Test]
        public void Pop_LengthIsOne_SetHeadToNullAndLengthToZeroAndReturnPoppedValue()
        {
            stack.Push("Yasser");

            string result = stack.Pop();

            Assert.That(stack.Head, Is.Null);        
            Assert.That(stack.length, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo("Yasser"));
        }

        [Test]
        public void Pop_LengthIsGreaterThanOne_DecrementLengthAndSetTheNewHeadToTheOldHeadNextRef()
        {
            stack.Push("Yasser");
            stack.Push("Jack");
            stack.Push("John");
            stack.Push("Matt");
            stack.Push("Christoph");

            Node<string> oldHeadNextRef = stack.Head.next;
            string result = stack.Pop();

            Assert.That(stack.Head, Is.EqualTo(oldHeadNextRef));
            Assert.That(stack.length, Is.EqualTo(4));
            Assert.That(result, Is.EqualTo("Christoph"));
        }

        [Test]
        public void Peek_IfLengthIsZero_ReturnTypeDefault()
        {
            Assert.That(stack.Peek(), Is.Null);
        }

        [Test]
        public void Peek_IfLengthIsGreaterThanZero_ReturnStackHead()
        {
            stack.Push("Yasser");
            stack.Push("Jack");
            stack.Push("John");

            Assert.That(stack.Peek(), Is.EqualTo("John"));
        }

    }


    // A Mock Stack Class used to expose the Head for testing purposes
    internal class MockStack<T> : Stack<T>
    {

        public Node<T>? Head
        {
            get { return head; }
        }
    }
}
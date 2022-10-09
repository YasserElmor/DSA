using NUnit.Framework;

namespace LinkedLists.Tests
{

    [TestFixture]
    public class QueueTests
    {
        private MockQueue<string>? queue;

        [SetUp]
        public void Setup()
        {
            queue = new MockQueue<string>();
        }

        [Test]
        public void EnqueueTest_LengthIsZero_SetHeadAndTailToNodeAndIncrementLength()
        {
            queue.Enqueue("Yasser");

            Assert.AreEqual("Yasser", queue.Head!.value, queue.Tail!.value);
            Assert.AreEqual(1, queue.length);
        }

        [Test]
        public void EnqueueTest_LengthIsNotZero_SetTailNextAndTailToNewNodeAndIncrementLength()
        {
            queue.Enqueue("Yasser");
            var oldTail = queue.Tail;
            queue.Enqueue("Jack");
            var newTail = queue.Tail;

            Assert.That(newTail, Is.EqualTo(oldTail.next));
            Assert.That("Jack", Is.EqualTo(newTail.value));
            Assert.AreEqual(2, queue.length);
        }

        [Test]
        public void Deque_LengthIsZero_ReturnNull()
        {
            Assert.That(null, Is.EqualTo(queue.Deque()));
        }

        [Test]
        public void Deque_LengthIsOne_SetHeadAndTailToNullAndLengthToZeroAndReturnDequedValue()
        {
            queue.Enqueue("Yasser");

            string result = queue.Deque();

            Assert.That(queue.Head, Is.Null);        
            Assert.That(queue.Tail, Is.Null);
            Assert.That(queue.length, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo("Yasser"));
        }

        [Test]
        public void Deque_LengthIsGreaterThanOne_DecrementLengthAndSetTheNewHeadToTheOldHeadNextRef()
        {
            queue.Enqueue("Yasser");
            queue.Enqueue("Jack");
            queue.Enqueue("John");
            queue.Enqueue("Matt");
            queue.Enqueue("Christoph");

            Node<string> oldHeadNextRef = queue.Head.next;
            string result = queue.Deque();

            Assert.That(queue.Head, Is.EqualTo(oldHeadNextRef));
            Assert.That(queue.length, Is.EqualTo(4));
            Assert.That(result, Is.EqualTo("Yasser"));
        }

        [Test]
        public void Peek_IfLengthIsZero_ReturnTypeDefault()
        {
            Assert.That(queue.Peek(), Is.Null);
        }

        [Test]
        public void Peek_IfLengthIsGreaterThanZero_ReturnQueueHead()
        {
            queue.Enqueue("Yasser");
            queue.Enqueue("Jack");
            queue.Enqueue("John");

            Assert.That(queue.Peek(), Is.EqualTo("Yasser"));
            queue.Deque();
            Assert.That(queue.Peek(), Is.EqualTo("Jack"));
        }

    }


    // A Mock Queue Class used to expose Head and Tail for testing purposes
    internal class MockQueue<T> : Queue<T>
    {

        public Node<T>? Head
        {
            get { return head; }
        }

        public Node<T>? Tail
        {
            get { return tail; }
        }

    }
}
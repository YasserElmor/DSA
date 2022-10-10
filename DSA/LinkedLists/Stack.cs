
namespace LinkedLists
{
    public class Stack<T>
    {
        public int length { get; set; }

        protected Node<T>? head;

        public Stack()
        {
            head = null;
            length = 0;
        }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);

            // empty stack? set the head to the node holding the passed item

            if (length == 0)
            {
                head = node;
            }

            // head is not null? set the new node as the new head and set it to point to the old head
            else
            {
                node!.next = head;
                head = node;
            }

            length++;
        }

        public T? Pop()
        {
            // empty stack? return null
            if (length == 0)
                return default;

            length--;
            var prevHead = head;

            // only one node? set head to null
            if (length == 0)
            {
                head = null;
            }

            // more than one node? set the head to the next node, and free the popped node
            else
            {
                head = head!.next;
                prevHead.next = null;
            }

            return prevHead!.value;
        }

        public T? Peek()
        {
            if (length == 0)
                return default;

            return head!.value;
        }
    }
}


namespace LinkedLists
{

    public class Queue<T>
    {
        public int length;

        private Node<T>? head;
        private Node<T>? tail;

        public Queue()
        {
            head = tail = null;
            length = 0;
        }

        public void Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);

            // empty queue? set both head and tail to the node holding the passed item
            if (length == 0)
            {
                head = tail = node;
                length++;
            }
            // head is not null? set the next reference of the previous tail to the new node, and set the tail of the list to the new node
            else
            {
                tail!.next = node;
                tail = node;
                length++;
            }
        }

        public T? Deque()
        {
            // empty queue? return null
            if (length == 0)
                return default;

            // head and tail both exist separately? set the current head's subsequent node as the new head, and set the previous head's next ref to null
            length--;

            Node<T> prevHead = head!;
            head = head!.next;
            prevHead.next = null;

            return prevHead.value;

        }

        public T? Peek()
        {
            if (length == 0)
                return default;

            return head!.value;
        }
    }

    public class Node<T>
    {
        public T value;
        public Node<T>? next;

        public Node(T val)
        {
            value = val;
        }
    }
}

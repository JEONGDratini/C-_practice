using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue_Example
{
    class Program
    {
        public class Node
        {
            public int data;//각 큐 원소에 저장할 자료형
            public int priority;//우선순위
            public Node next;//다음 순서원소.
        }

        public static Node node = new Node();

        public static Node newNode(int d, int p)
        {
            Node temp = new Node();
            temp.data = d;
            temp.priority = p;
            temp.next = null;
            return temp;
        }

        public static int top(Node head)
        {
            return (head).data;
        }

        public static Node pop(Node head)
        {
            Node temp = head;
            (head) = (head).next;
            return head;
        }

        public static Node push(Node head, int d, int p)
        {
            Node start = (head);
            Node temp = newNode(d, p);
            if ((head).priority > p)
            {
                temp.next = head;
                (head) = temp;
            }
            else
            {
                while (start.next != null && start.next.priority < p)
                {
                    start = start.next;
                }
                temp.next = start.next;
                start.next = temp;
            }
            return head;
        }

        public static int isEmpty(Node head)
        {
            return ((head) == null) ? 1 : 0;
        } 

        static void Main(string[] args)
        {
            Node queue = newNode(1, 1);
            queue = push(queue, 9, 2);
            queue = push(queue, 7, 3);
            queue = push(queue, 3, 0);

            while (isEmpty(queue) == 0)
            {
                Console.Write("{0:D} ", top(queue));
                queue = pop(queue);
            } 
        }
    }
}

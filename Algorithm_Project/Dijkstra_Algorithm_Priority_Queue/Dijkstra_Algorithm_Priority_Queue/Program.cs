﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algorithm_Priority_Queue
{
    class Program
    {
        public class Node
        {
            public int data;//각 큐 원소에 저장할 자료형
            public int priority;//우선순위.
            public Node next;//다음 순서원소.
        }

        public static Node node = new Node();

        public static Node newNode(int d, int p)//새 노드 설정해 반환하는 메소드
        {
            Node temp = new Node();
            temp.data = d;//Data값
            temp.priority = p;//우선순위
            temp.next = null;
            return temp;
        }

        public static int top(Node head)
        {
            return (head).data;//가장 위에 있는 원소 가져오기
        }



        public static Node pop(Node head)
        {
            Node temp = head;//
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

        static int num = 6;
        static int inf = 1000000;


        static void Main(string[] args)
        {


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace L5
{
    /// <summary>
    /// Generic doubly linked list
    /// </summary>
    /// <typeparam name="T">any object</typeparam>
    public sealed class GenericDoublyLinkedList<T>: IEnumerable<T>
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Node needed for the linked list
        /// </summary>
        /// <typeparam name="T">any object</typeparam>
        private sealed class Node<T> where T: IComparable<T>, IEquatable<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T data, Node<T> previous, Node<T> next)
            {
                Data = data;
                Next = next;
                Previous = previous;
            }
        }

        private Node<T> head;   // Head of the list
        private Node<T> tail;   // Tail of the list

        /// <summary>
        /// Returns the count of the elements of the list
        /// </summary>
        public int Count
        {
            get 
            {
                if(head == null)
                    return 0;
                int k = 0;
                for (Node<T> dd = head; dd != null; dd = dd.Next)
                    k++;
                return k;
            }
        }

        /// <summary>
        /// Adding element to the front of the list
        /// </summary>
        /// <param name="element"></param>
        public void AddToFront(T element)
        {
            Node<T> p = new Node<T>(element, null, head);
            if (head != null)
                head.Previous = p;
            else
                tail = p;
            head = p;
        }

        /// <summary>
        /// Adding element to the end of the list
        /// </summary>
        /// <param name="element"></param>
        public void AddToEnd(T element)
        {
            Node<T> p = new Node<T>(element, tail, null);
            if (head != null)
                tail.Next = p;
            else
                head = p;
            tail = p;
        }

        /// <summary>
        /// Checks if the list contains the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(IComparable<T> element)
        {
            bool t = false;
            for(Node<T> p = head; p != null; p = p.Next)
                if (p.Data.Equals(element))
                    t = true;
            return t;
        }

        /// <summary>
        /// Gets the data of elements of the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for(Node<T> p = head; p != null; p = p.Next)
                yield return p.Data;
        }

        /// <summary>
        /// Returning enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        /// <summary>
        /// Reversly getting the data of elements of the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> Reverse()
        {
            for (Node<T> p = tail; p != null; p = p.Previous)
                yield return p.Data;
        }

        /// <summary>
        /// Sorting method
        /// </summary>
        public void Sort()
        {
            for (Node<T> s1 = head; s1 != null; s1 = s1.Next)
            {
                Node<T> maxv = s1;
                for (Node<T> s2 = s1; s2 != null; s2 = s2.Next)
                    if (s2.Data.CompareTo(maxv.Data) < 0)
                        maxv = s2;
                T St = s1.Data;
                s1.Data = maxv.Data;
                maxv.Data = St;
            }
        }
    }
}

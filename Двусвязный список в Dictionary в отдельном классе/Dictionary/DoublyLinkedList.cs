using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
    {
    class DoublyLinkedList<T>: IList<T>, IComparable
        {

        private class ListNode
            {
            public T Element { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PrevNode { get; set; }

            public ListNode ()
                {
                }

            public ListNode (T element)
                {
                Element = element;
                NextNode = PrevNode = null;
                }
            public ListNode (T element , ListNode prevNode)
                {
                Element = element;
                NextNode = null;
                prevNode.NextNode = this;
                PrevNode = prevNode;
                }

            }

        IEnumerator IEnumerable.GetEnumerator ()
            {
            for (int i = 0 ; i < count ; i++)
                {
                yield return this[i];
                }
            }

        ListNode head;
        ListNode tail;
        int count;
        public DoublyLinkedList ()
            {
            head = tail = null;
            count = 0;
            }

        public T this[int index]
            {
            get
                {
                if (index >= count || index < 0)
                    { throw new ArgumentOutOfRangeException("Invalid index: " + index); }

                if (index <= count / 2)
                    {
                    ListNode currentNode = head;
                    for (int i = 0 ; i < index ; i++)
                        currentNode = currentNode.NextNode;
                    return currentNode.Element;
                    }
                else
                    {
                    ListNode currentNode = tail;
                    for (int i = 0 ; i < count - index ; i++)
                        currentNode = currentNode.PrevNode;
                    return currentNode.Element;
                    }


                }

            set
                {
                if (index >= count || index < 0)
                    { throw new ArgumentOutOfRangeException("Invalid index: " + index); }

                if (index <= count / 2)
                    {
                    ListNode currentNode = head;
                    for (int i = 0 ; i < index ; i++)
                        currentNode = currentNode.NextNode;
                    currentNode.Element = value;
                    }
                else
                    {
                    ListNode currentNode = tail;
                    for (int i = 0 ; i <= count - index ; i++)
                        currentNode = currentNode.NextNode;
                    currentNode.Element = value;
                    }
                }
            }

        public int Count
            {
            get
                {
                return count;
                }
            }

        public bool IsReadOnly
            {
            get
                {
                return false;
                }
            }

        public void Add (T item)
            {
            if (count == 0)
                head = tail = new ListNode(item);
            else
                {
                ListNode newNode = new ListNode(item , tail);
                tail = newNode;
                }
            count++;
            }

        public void Clear ()
            {
            head = tail = null;
            count = 0;

            }

        public int CompareTo (object obj)
            {
            if (obj == null)
                return 1;

            DoublyLinkedList<T> otherList = obj as DoublyLinkedList<T>;
            if (otherList != null)
                return this.count.CompareTo(otherList.count);
            else
                throw new ArgumentException("Object is not a DoublyLinkedList");
            }

        public bool Contains (T item)
            {
            ListNode curr = head;

            for (int i = 1 ; i <= count ; i++)
                {
                if (Equals(item , curr.Element))
                    return true;
                curr = curr.NextNode;
                }
            return false;
            }

        public void CopyTo (T[] array , int arrayIndex)
            {
            ListNode curr = head;

            for (int i = 1 ; i < arrayIndex ; i++)
                curr = curr.NextNode;

            for (int i = arrayIndex ; i < count ; i++)
                {
                array[i - arrayIndex] = curr.Element;
                curr = curr.NextNode;
                }
            }

        public IEnumerator<T> GetEnumerator ()
            {
            for (int i = 0 ; i < count ; i++)
                {
                yield return this[i];
                }
            }

        public int IndexOf (T item)
            {
            int index = 0;

            ListNode currentNode = head;
            while (currentNode != null)
                {
                if (Equals(currentNode.Element , item))
                    return index;
                currentNode = currentNode.NextNode;
                index++;
                }
            return -1;
            }

        public void Insert (int index , T item)
            {

            count++;

            ListNode curr = head;

            for (int i = 0 ; i < index ; i++)
                curr = curr.NextNode;

            ListNode newNode = new ListNode();

            newNode.Element = item;
            newNode.NextNode = curr;
            newNode.PrevNode = curr.PrevNode;
            curr.PrevNode.NextNode = newNode;
            curr.PrevNode = newNode;

            }

        public bool Remove (T item)
            {
            int currentIndex = 0;
            ListNode currentNode = head;

            while (currentNode != null)
                {
                if (Equals(currentNode.Element , item))
                    break;

                currentNode = currentNode.NextNode;
                currentIndex++;
                }
            if (currentNode != null)
                {
                RemoveListNode(currentNode , currentNode.PrevNode);
                return true;
                }
            else
                return false;
            }

        public void Sort ()
            {
            List<T> list = new List<T>();

            ListNode curr = head;
            while (curr != null)
                {
                list.Add(curr.Element);
                curr = curr.NextNode;
                }
            list.Sort();
            this.Clear();
            for (int i = 0 ; i < list.Count - 1 ; i++)
                this.Add(list[i]);
            list.Clear();
            }

        public void Frct ()
            {
            List<string> list = new List<string>();
            
            ListNode curr = head;
            while (curr != null)
                {
                list.Add(curr.Element.ToString());
                curr = curr.NextNode;
                }
            list.Sort(new LengthSorter());
            this.Clear();
            for (int i = 0 ; i < list.Count - 1 ; i++)
                this.Add((T)Convert.ChangeType(list[i] , typeof(T)));           // ПРЕОБРАЗОВАНИЕ ИЗ STRING в T

            list.Clear();
            }

        private void RemoveListNode (ListNode node , ListNode prevNode)
            {
            count--;
            if (count == 0)
                head = null;

            else
                {
                if (prevNode == null)
                    head = node.NextNode;
                else
                    prevNode.NextNode = node.NextNode;

                if (ReferenceEquals(tail , node))
                    {
                    tail = prevNode;
                    }
                }
            }

        public void RemoveAt (int index)
            {
            if (index >= count || index < 0)
                {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

            int currentIndex = 0;
            ListNode currentNode = head;

            while (currentIndex < index)
                {
                currentNode = currentNode.NextNode;
                currentIndex++;
                }
            RemoveListNode(currentNode , currentNode.PrevNode);
            }

        class LengthSorter: IComparer<string>
            {
            int IComparer<string>.Compare (string x , string y)
                {
                int res = x.Length.CompareTo(y.Length);
                if (res == 0)
                    res = x.CompareTo(y);
                return res;
                }
            }

        }
    }

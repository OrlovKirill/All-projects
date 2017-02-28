using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
    {
    public class DynamicList<T>
        {
        
        public class ListNode
            {
            public T Element { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode ()
                { 
                }
           
            public ListNode (T element , ListNode prevNode)
                {
                Element = element;
                
                NextNode = null;
                prevNode.NextNode = this;
                }
            }
        private ListNode sentinel;
        private ListNode head;
        int count;

        public DynamicList ()
            {
            head = null;
            count = 0;
            sentinel = new ListNode();
            sentinel.NextNode = head;
            }

        public ListNode GetTail ()
            {
            ListNode curr = new ListNode();
            curr = head;
            while (curr.NextNode != null)
                curr = curr.NextNode;
            return curr;
            }

        private void AmendTail (ListNode replacement)
            {
            ListNode curr = new ListNode();
            curr = head;
            while (curr.NextNode != null)
                curr = curr.NextNode;
            curr = replacement;
            }

        public void Add (T item)
            {
            if (head == null)
                head = new ListNode(item , sentinel);
            else
                {
                ListNode newNode = new ListNode(item , GetTail());
                }
            count++;
            }

        public T RemoveAt(int index)
            {
            if (index >= count || index < 0)
                {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

            int currentIndex = 0;
            ListNode currentNode = head;
            ListNode prevNode = sentinel;
            while (currentIndex < index)
                {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
                }
            RemoveListNode(currentNode , prevNode);
            return currentNode.Element;
            }

        private void RemoveListNode(ListNode node, ListNode prevNode)
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

                if (object.ReferenceEquals(GetTail() , node))
                    {
                    AmendTail(prevNode);
                    }
                }
            }

        public int Remove (T item)
            {
            int currentIndex = 0;
            ListNode currentNode = head;
            ListNode prevNode = null;
            while (currentNode != null)
                {
                if (object.Equals(currentNode.Element , item))
                    break;
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
                }
            if (currentNode != null)
                {
                RemoveListNode(currentNode , prevNode);
                return currentIndex;
                }
            else
                return -1;
            }

        public int IndexOf(T item)
            {
            int index = 0;

            ListNode currentNode = head;
            while (currentNode != null)
                {
                if (object.Equals(currentNode.Element , item))
                    return index;
                currentNode = currentNode.NextNode;
                index++;
                }
            return -1;
            }

        public bool Contains (T item)
            {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
            }

        public T this[int index]
            {
            get
                {

                if (index >= count || index < 0)
                    { throw new ArgumentOutOfRangeException("Invalid index: " + index); }

                ListNode currentNode = head;
                for (int i = 0 ; i<index ; i++)
                     currentNode = currentNode.NextNode;

                return currentNode.Element;
                }
            set
                {
                if (index >= count || index < 0)
                    { throw new ArgumentOutOfRangeException("Invalid index: " + index); }

                ListNode currentNode = head;
                for (int i = 0 ; i<index ; i++)
                    {
                    currentNode = currentNode.NextNode;
                    }
                currentNode.Element = value;
                }
            }

        public int Count
            {
            get
                {
                return count;
                }
            }

        public void RemoveDuplicates4()
        {
            ListNode current = new ListNode();
            current = sentinel;
            ListNode passing = new ListNode();
            
            for (int i = 0; i < count - 1; i++) { 
                current = current.NextNode;
                passing = current;
                for (int j = i + 1; j < count; j++){
                    passing=passing.NextNode;
                    if (object.Equals(current,passing))
                        RemoveAt(j);
                    }
                }
        }

        public T ReturnItemFromTheEnd(int index)
        {
            ListNode curr = new ListNode();
            ListNode needed = new ListNode();
            needed = curr = head;

            for (int i = 0; i <= index; i++)
                curr = curr.NextNode;
            while (curr.NextNode != null)
                {
                curr = curr.NextNode;
                needed = needed.NextNode;
                }
            return needed.Element;
            }               /////////////////////////////////

        public void RemoveItemFromTheCenter (ListNode item)
            {
            item = item.NextNode;
            }    ///////////////////////////

        public void RemoveDuplicates3 ()
            {
            Dictionary<T , ListNode> dict = new Dictionary<T , ListNode>();
            ListNode item = new ListNode();
            item = head;
            while (item != null)
                {
                if (dict.ContainsKey(item.Element))
                    Remove(item.Element);
                else
                    dict.Add(item.Element , item);
                item = item.NextNode;
                }
            }                       ///////////////////////////////

        public bool IsPalindrome ()
            {
            int center = Count / 2;

            ListNode First = head;
            ListNode Middle = First.NextNode;
            head.NextNode = sentinel;
            sentinel.NextNode = null;
            ListNode Last = Middle.NextNode;

            if (Count % 2 == 1)
                {
                center--;
                for (int i = 1 ; i <= center ; i++)
                    {
                    Middle.NextNode = First;
                    First = Middle;
                    Middle = Last;
                    Last = Last.NextNode;
                    }
                ListNode CurrRight = Middle.NextNode;
                ListNode CurrLeft = First;
                for (int i = 1 ; i <= center + 1 ; i++)
                    if (!Equals(CurrLeft.Element , CurrRight.Element))
                        return false;
                    else
                        {
                        CurrRight = CurrRight.NextNode;
                        CurrLeft = CurrLeft.NextNode;
                        }

                }

            else
                {
                for (int i = 1 ; i < center ; i++)
                    {
                    Middle.NextNode = First;
                    First = Middle;
                    Middle = Last;
                    Last = Last.NextNode;
                    }
                ListNode CurrRight = Middle;
                ListNode CurrLeft = First;
                for (int i = 1 ; i < center + 1 ; i++)
                    if (!Equals(CurrLeft.Element , CurrRight.Element))
                        return false;
                    else
                        {
                        CurrRight = CurrRight.NextNode;
                        CurrLeft = CurrLeft.NextNode;
                        }

                }
            return true;
            }


        }

    class program
        {
        public static void Main (string[] args)
            { 
            DynamicList<string> dyn = new DynamicList<string>();
            dyn.Add("Вася");
            dyn.Add("Петя");
            dyn.Add("Маша");
            dyn.Add("Коля");
            dyn.Add("Витя");
            dyn.Add("Коля");
            dyn.Add("Маша");
            dyn.Add("Петя");
            dyn.Add("Вася");
            
            Console.WriteLine(dyn);
            Console.ReadKey();


            }

        public static void RemoveDuplicates3 (ref DynamicList<string> List)                 // З А Д А Н И Е   3    
            {
            object[] arr1 = new object[List.Count];
            object[] arr2 = new object[List.Count];
            int currentIndOfArr2 = 0;

            for (int i = 0 ; i <= List.Count - 1 ; i++)
                {
                int kode = Math.Abs(List[i].GetHashCode());

                if (arr1[kode % arr1.Length] == null)
                    arr1[kode % arr1.Length] = List[i];
                else
                    if (arr1[kode % arr1.Length] == List[i])
                    {
                    List.RemoveAt(i);
                    i--;
                    }
                else
                        if (Array.IndexOf(arr2 , List[i]) > -1)
                    List.RemoveAt(i);
                else
                    {
                    arr2[currentIndOfArr2] = List[i];
                    currentIndOfArr2++;
                    }
                 }


            



            }       // сделать через стандартные хеш-таблицы dictionary

        public static void RemoveDuplicates4 (ref DynamicList<string> List)                 // З А Д А Н И Е   4    
            {

                //List.RemoveDuplicates4(ref List);

            }      

        public static void ReturnItemFromTheEnd (ref DynamicList<string> List, int index)   // З А Д А Н И Е   5    
            {
            
            //for (int i = 0; i<=index; i++) 

            }       // сделать без count (не знаем его), на вход только индекс (без листа, лист открыт)

        public static void RemoveItemFromTheCenter (string item)              // З А Д А Н И Е   6    
            {
            
            }       // на вход только элемент (без листа, лист открыт)

        public static bool IsPalindrome (DynamicList<string> List)                          // З А Д А Н И Е   7    
            {
            for (int i = 0 ; i < List.Count / 2 ; i++)
                if (!Equals(List[i] , List[List.Count-i-1]))
                    return false;
            return true;
            }       
                }

        }
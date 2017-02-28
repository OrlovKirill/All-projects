using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
    {
    class MySortedDictionary<TKey,TValue> :IDictionary<TKey,TValue> where TKey: IComparable<TKey>
        {

        private int CurrentIndex;
        private int count;
        int DefaultSize;
        private double LoadFactor;
        private Eratosfen Erat;
        private BinarySearchTree<TKey,TValue> table;
        private class Eratosfen
            {
            List<int> simple;

            public Eratosfen (int MaxNumber)
                {
                simple = new List<int>();
                for (int i = 1 ; i < MaxNumber ; i++)
                    simple.Add(i);
                DoEratosfen();
                }

            int Step (int Prime , int startFrom)
                {
                int i = startFrom + 1;
                int Removed = 0;
                while (i < simple.Count)
                    if (simple[i] % Prime == 0)
                        {
                        simple.RemoveAt(i);
                        Removed++;
                        }
                    else
                        i++;
                return Removed;
                }

            void DoEratosfen ()
                {
                int i = 1;
                while (i < simple.Count)
                    {
                    Step(simple[i] , i);
                    i++;
                    }
                }

            public int[] Simple
                {
                get
                    {
                    return simple.ToArray();
                    }
                }

            }
        private int[] SimpleNumbers;
        private int NextSimpleNumber
            {

            get
                {
                CurrentIndex++;
                return SimpleNumbers[CurrentIndex];
                }

            }
        private int PrevSimpleNumber
            {
            get
                {
                CurrentIndex--;
                return SimpleNumbers[CurrentIndex];
                }
            }

        public MySortedDictionary ()
            { 
            count = 0;
            table = new BinarySearchTree<TKey , TValue>();
            }

        public int Count
            {
            get
                {
                return count;
                }
            }

        public void Add (TKey key , TValue value)
            {
            KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(key,value);
            Add(newItem);
            }

        public void Add (KeyValuePair<TKey , TValue> item)
            {
            count++;
            table.Insert(item);
            }

        public void Clear ()
            {
            table = null;
            }

        public bool Contains (KeyValuePair<TKey , TValue> item)
            {
            return ContainsKey(item.Key);
            }

        public bool ContainsKey (TKey key)
            {
            if (table.Contains(key))
                return true; 
            return false;
            }

        public bool IsReadOnly
            {
            get
                {
                return false;
                }
            }

        public TValue this[TKey key]
            {
            get
                {
                return table.Find(key).value.Value;
                }

            set
                {
                List<KeyValuePair<TKey , TValue>> List = new List<KeyValuePair<TKey , TValue>>(table.AvlList);
                
                foreach (var item in List)
                    if (Equals(item.Key , key))
                        {
                        KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(key , value);
                        table.Remove(key);
                        table.Insert(newItem);
                        }
                }
            }

        public bool Remove (KeyValuePair<TKey , TValue> item)
            {
            return Remove(item.Key);
            }

        public bool Remove (TKey key)
            {
            if(!table.Contains(key))
                return false;
            count--;
            table.Remove(key);
            return true;
            }

        //private TValue DesiredValue (TKey key)
        //    {
        //    int GetHash = key.GetHashCode();
        //    int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
        //    if (table[HashCode] == null)
        //        return default(TValue);
        //    foreach (var item in table[HashCode])
        //        if (Equals(item.Key , key))
        //            return item.Value;
        //    return default(TValue);
        //    }

        public bool TryGetValue (TKey key , out TValue value)
            {
            TValue val = table.Find(key).value.Value;
            if (!Equals(val , default(TValue)))
                {
                value = val;
                return true;
                }
            else
                {
                value = default(TValue);
                return false;
                }
            }

        public ICollection<TKey> Keys
            {
            get
                {
                List<TKey> ListOfKeys = new List<TKey>();
                foreach (var CurList in table.AvlList)
                    if (!Equals(CurList,null))
                            ListOfKeys.Add(CurList.Key);
                return ListOfKeys;
                }
            }

        public ICollection<TValue> Values
            {
            get
                {
                List<TValue> ListOfValues = new List<TValue>();
                foreach (var CurList in table.AvlList)
                    if (!Equals(CurList , null))
                        ListOfValues.Add(CurList.Value);
                return ListOfValues;
                }
            }

        public void CopyTo (KeyValuePair<TKey , TValue>[] array , int arrayIndex)
            {
            int currIndex = arrayIndex;
            foreach (var CurList in table.AvlList)
                if (!Equals(CurList , null))
                        if (currIndex < array.Length)
                            array[currIndex] = CurList;
                        else
                            throw new ArgumentOutOfRangeException();
            }

        public IEnumerator<KeyValuePair<TKey , TValue>> GetEnumerator ()
            {
            foreach (var CurList in table.AvlList)
                if (!Equals(CurList , null))
                        yield return CurList;
            }

        IEnumerator IEnumerable.GetEnumerator ()
            {
            foreach (var CurList in table.AvlList)
                if (!Equals(CurList , null))
                    yield return CurList;
            }

        
        }
    }

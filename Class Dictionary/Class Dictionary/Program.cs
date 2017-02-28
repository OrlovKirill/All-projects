using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Dictionary
    {
    public class MyDictionary<TKey, TValue>: IDictionary<TKey , TValue>
        {

        private int CurrentIndex;
        private int count;
        int DefaultSize;
        private double LoadFactor;
        private Eratosfen Erat;
        private List<KeyValuePair<TKey , TValue>>[] table;
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

        public MyDictionary ()
            {
            Erat = new Eratosfen(Int16.MaxValue);
            SimpleNumbers = Erat.Simple;
            count = 0;
            LoadFactor = 0.72;
            CurrentIndex = 3;
            DefaultSize = NextSimpleNumber;
            table = new List<KeyValuePair<TKey , TValue>>[DefaultSize];
            }

        public int Count
            {
            get
                {
                return count;
                }
            }

        public void Add (KeyValuePair<TKey , TValue> item)
            {
            Add(item.Key , item.Value);
            }

        public void Add (TKey key , TValue value)
            {
            count++;
            int GetHash = Math.Abs(key.GetHashCode());
            int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
            if (table[HashCode] == null)
                table[HashCode] = new List<KeyValuePair<TKey , TValue>>();
            KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(key , value);
            table[HashCode].Add(newItem);
            double CurrLoadFactor = Convert.ToDouble(count) / table.Length;
            if ( CurrLoadFactor > LoadFactor)
                ReHashUP();
            }

        private void ReHashUP ()
            {
            List<KeyValuePair<TKey , TValue>>[] CopyTable = new List<KeyValuePair<TKey , TValue>>[NextSimpleNumber];
            
            foreach (var CurList in table)
                {
                if (CurList != null)
                    foreach (var CurElement in CurList)
                        {
                        int GetHash = Math.Abs(CurElement.Key.GetHashCode());
                        int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % CopyTable.Length;
                        KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(CurElement.Key , CurElement.Value);
                        if (CopyTable[HashCode] == null)
                            CopyTable[HashCode] = new List<KeyValuePair<TKey , TValue>>();
                        CopyTable[HashCode].Add(newItem);
                        }
                }
            table = CopyTable;
            }

        private void ReHashDOWN ()
            {
            List<KeyValuePair<TKey , TValue>>[] CopyTable = new List<KeyValuePair<TKey , TValue>>[PrevSimpleNumber];
            
            foreach (var CurList in table)
                {
                if (CurList != null)
                    foreach (var CurElement in CurList)
                        {
                        int GetHash = Math.Abs(CurElement.Key.GetHashCode());
                        int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % CopyTable.Length;
                        KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(CurElement.Key , CurElement.Value);
                        if (CopyTable[HashCode] == null)
                            CopyTable[HashCode] = new List<KeyValuePair<TKey , TValue>>();
                        CopyTable[HashCode].Add(newItem);
                        }
                }
            table = CopyTable;
            }

        public void Clear ()
            {
            Array.Resize(ref table , DefaultSize);
            Array.Clear(table , 0 , DefaultSize);
            }

        public bool Contains (KeyValuePair<TKey , TValue> item)
            {
            return ContainsKey(item.Key);
            }

        public bool ContainsKey (TKey key)
            {
            int GetHash = key.GetHashCode();
            int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
            if (table[HashCode] != null)
                foreach (var item in table[HashCode])
                    if (Equals(item.Key , key))
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
                return DesiredValue(key);
                }

            set
                {
                int GetHash = key.GetHashCode();
                int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
                foreach (var item in table[HashCode])
                    if (Equals(item.Key , key))
                        {
                        KeyValuePair<TKey , TValue> newItem = new KeyValuePair<TKey , TValue>(key , value);
                        table[HashCode].RemoveAt(table[HashCode].IndexOf(item));
                        table[HashCode].Insert(0 , newItem);
                        }
                }
            }

        public bool Remove (KeyValuePair<TKey , TValue> item)
            {
            return Remove(item.Key);
            }

        public bool Remove (TKey key)
            {
            int GetHash = Math.Abs(key.GetHashCode());
            int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
            if (table[HashCode] == null)
                return false;

            foreach (var item in table[HashCode])
                if (Equals(item.Key , key))
                    {
                    count--;
                    table[HashCode].RemoveAt(table[HashCode].IndexOf(item));
                    double CurrLoadFactor = Convert.ToDouble(count) / SimpleNumbers[CurrentIndex-1];
                    if (CurrLoadFactor < LoadFactor)
                        ReHashDOWN();
                        return true;
                    }
            return false;
            }

        private TValue DesiredValue (TKey key)
            {
            int GetHash = key.GetHashCode();
            int HashCode = (GetHash + 1 + (((GetHash >> 5) + 1) % (table.Length - 1))) % table.Length;
            if (table[HashCode] == null)
                return default(TValue);
            foreach (var item in table[HashCode])
                if (Equals(item.Key , key))
                    return item.Value;
            return default(TValue);
            }

        public bool TryGetValue (TKey key , out TValue value)
            {
            TValue val = DesiredValue(key);
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
                foreach (var CurList in table)
                    if (CurList != null)
                        foreach (var item in CurList)
                            ListOfKeys.Add(item.Key);
                return ListOfKeys;
                }
            }

        public ICollection<TValue> Values
            {
            get
                {
                List<TValue> ListOfValues = new List<TValue>();
                foreach (var CurList in table)
                    if (CurList != null)
                        foreach (var item in CurList)
                            ListOfValues.Add(item.Value);
                return ListOfValues;
                }
            }

        public void CopyTo (KeyValuePair<TKey , TValue>[] array , int arrayIndex)
            {
            int currIndex = arrayIndex;
            foreach (var CurList in table)
                if (CurList != null)
                    foreach (var item in CurList)
                        if (currIndex < array.Length)
                            array[currIndex] = item;
                        else
                            throw new ArgumentOutOfRangeException();
            }

        public IEnumerator<KeyValuePair<TKey , TValue>> GetEnumerator ()
            {
            foreach (var CurList in table)
                if (CurList != null)
                    foreach (var item in CurList)
                        yield return item;
            }

        IEnumerator IEnumerable.GetEnumerator ()
            {
            foreach (var CurList in table)
                if (CurList != null)
                    foreach (var item in CurList)
                        yield return item;
            }
        }

        class program { 
        static void Main (string[] args)
            {

            MyDictionary<string , string> dict = new MyDictionary<string , string>();
            dict.Add("Вася" , "Василий");
            dict.Add("Петя" , "Пётр");
            dict.Add("Аня" , "Анна");
            dict.Add("Ира" , "Ирина");
            dict.Add("Ира" , "Ираида");
            dict.Add("Серый" , "Сергей");
            dict.Remove("Серый");
            dict.Add("Керил" , "Кирилл");
            dict.Add("Велик" , "Велимир");
            }


        }
    

   
    }
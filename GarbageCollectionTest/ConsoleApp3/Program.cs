using System;
using System.Diagnostics;


namespace GarbageCollectionTest
    {

    class FinalizeObject
        {
        public int id { get; set; }
        public string str { get; set; }
        public decimal dec { get; set; }
        public double doub { get; set; }

        public FinalizeObject (int id,string str,decimal dec,double doub)
            {
            this.id = id;
            this.str = str;
            this.dec = dec;
            this.doub = doub;
            }

        ~FinalizeObject ()
            {
            if (Program.flag)
                StartGarbCollect();
            }

        private void StartGarbCollect ()
            {
            Program.id = id;
            Program.flag = false;
            Program.time.Stop();
            Program.beforeGC = Program.time.ElapsedMilliseconds;
            Program.time.Restart();
            }
        }


    class Program
        {
        public static bool flag = true;
        public static int id = -1;
        public static Stopwatch time;
        public static long beforeGC;
        public static long afterGC;
        public static long items = 1000000;

        static void Main (string[] args)
            {
            FinalizeObject obj;
            time = new Stopwatch();
            time.Start();
            for (int j = 0 ; j < items ; j++)
                obj = new FinalizeObject(j, "New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item New Item ",156169489148949841,-419841984.5419845);
            time.Stop();
            afterGC = time.ElapsedMilliseconds;
            if (id >= 0)
                Console.WriteLine("Сборка мусора начата с {0} элемента\n\n\nСреднее время, затраченное на обработку одного элемента: \nДО начала сборки {1} мс\n" +
                    "ПОСЛЕ начала сборки {2} мс\n\n\nНакладные расходы составили в среднем {3} мс или {4} % на один элемент" , id , (double)beforeGC / (id - 1) , (double)afterGC / (items - id) , (double)afterGC / (items - id)-(double)beforeGC / (id - 1)  , 100 * ((double)afterGC / (items - id)) / ((double)beforeGC / (id - 1)) - 100);
            else
                Console.WriteLine("Сборка мусора не начиналась");
            Console.Read();
            }
        }
    }

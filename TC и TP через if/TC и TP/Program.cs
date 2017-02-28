using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TC_и_TP {
    class Program {
        static void Main (string[] args) {
            Stopwatch time = new Stopwatch();
            int j = 1000;

            time.Start();
            for (int i=1 ; i < j ; i++) TryCatch();
            time.Stop();
            TimeSpan ts1 = time.Elapsed;

            time.Reset();
            time.Start();
            for (int i = 1 ; i < j ; i++) TryParse();
            time.Stop();
            TimeSpan ts2 = time.Elapsed;

            Console.WriteLine("Время TryCatch: {0} мс\nВремя TryParse: {1} мс\n\n\nРазница за {2} прогонов составила: {3} мс" , ts1.TotalMilliseconds , ts2.TotalMilliseconds, j, Math.Abs(ts1.TotalMilliseconds - ts2.TotalMilliseconds));
            Console.ReadKey();

            }
            public static void TryCatch() {
            double nol = 0;
            double i;
            try { i = 5 / nol; } catch (DivideByZeroException) { nol = 3; }
            try { i = 123456789 / nol*0.123456789; } catch (DivideByZeroException) { }
            nol = 0;
            try { i = 0.123456789 / nol*123456789; } catch (DivideByZeroException) { nol = 0.3; }
            try { i = int.MinValue / nol*int.MaxValue; } catch (DivideByZeroException) { }    
            }

            public static void TryParse() {
            double nol = 0;
            double i;
            if (nol != 0)  i = 5 / nol;  else { nol = 3; }
            if (nol != 0)  i = 123456789 / nol;  
            nol = 0;
            if (nol != 0)  i = 0.123456789 / nol * 123456789;  else { nol = 0.3; }
            if (nol != 0)  i = int.MinValue / nol*int.MaxValue;  
            }


            }
        }
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
            for (int i=1 ; i<250 ; i++) TryCatch();
            time.Stop();
            TimeSpan ts1 = time.Elapsed;


            time.Start();
            for (int i = 1 ; i < 1000 ; i++) TryParse();
            time.Stop();
            TimeSpan ts2 = time.Elapsed;

            Console.WriteLine("Время TryCatch: {0} мс\nВремя TryParse: {1} мс\n\n\nРазница за {2} прогонов составила: {3} мс" , ts1.TotalMilliseconds , ts2.TotalMilliseconds, j, Math.Abs(ts1.TotalMilliseconds - ts2.TotalMilliseconds));
            Console.ReadKey();

            }
            public static void TryCatch() {
            int nol = 0;
            double i;
            try { i = 5 / nol; } catch (DivideByZeroException) { }
            try { i = 123456789 / nol*0.123456789; } catch (DivideByZeroException) { }
            try { i = 0.123456789 / nol*123456789; } catch (DivideByZeroException) { }
            try { i = int.MinValue / nol*int.MaxValue; } catch (DivideByZeroException) { }    
            }

            public static void TryParse() {
            int nol = 0;
            double i;
            Double.TryParse((5/nol).ToString(),out i);
            Double.TryParse("d987894654651616516" , out i);
            Double.TryParse("8178971814348741543871345783471413541354KKKKK31541378345437453" , out i);
            Double.TryParse("7777777777777777777777777" , out i);
            }


            }
        }
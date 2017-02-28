using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorka {
    class Program {
        static void Main(string[] args) 

            {
            
            double m; double.TryParse(args[0], out m);
            double n; double.TryParse(args[1], out n);
            int i,j;
            double p;
            double a =  (m - 3) / (n-1);
           
            for (i = 1; i <= n-1; i++) {
                p = ((25 - 3 - Math.Round((a * (i - 1)),0)));
                
                for (j = 1; j <= p; j++)
                    Console.Write(" ");
                for (j=1; j<=25-p; j++)
                    Console.Write("*");
                Console.WriteLine();
                }

            for (i = 1; i <= 25 - m; i++)
                Console.Write(" ");
            for (i = 1; i <= m; i++)
                Console.Write("*");
            Console.ReadKey();

                
            }
        }
    }

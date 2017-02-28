using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
    {
    class Program
        {
        static void Main(string[] args)
            {

            int n = Int32.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];
            int[] c = new int[n];

            for (int j = 0; j <= n-1; j++)
                a[j] = n - j;
            for (int i = n - 1; i >= 0; i--)
                Console.WriteLine(a[i]);
            displacement(a, b, c, n);
            for (int i = n - 1; i >= 0; i--)
                Console.WriteLine(c[i]);
            Console.ReadKey();
                

            }
        public static void WrOut(int[] a, int[] b, int[] c)
            {
            Console.Clear();
            for (int i=a.Length; i<=0; i--)
                {
                Console.WriteLine(String.Format(a[i].ToString()));
                }
            }

        public static void trans(int[] from, int[] to)
            {
            int i,j;
            for (j = from.Length-1; j>=0 ; j--)
                if (from[j] > 0)
                    break;
            if (j == -1) Console.WriteLine("ERROR!");

            for (i = 0; i < to.Length; i++)
                if (to[i] == 0)
                    break;
            if (i==to.Length || (i>0 && to[i-1]<from[j]))
                Console.WriteLine("ERROR!");
            else
                {
                to[i] = from[j];
                from[j] = 0;
                }
            Console.WriteLine(from[j] + " -> " + to[i]);
            }

        public static void displacement(int[]a,int[]b,int[]c,int n)
            {
            if (n == 1)
                trans(a, c);
            else
                {
                displacement(a, c, b, n - 1);
                trans(a, c);
                displacement(b, a, c, n - 1);
                }
            }
        }
    }

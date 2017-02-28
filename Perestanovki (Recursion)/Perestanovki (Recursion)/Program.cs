using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perestanovki__Recursion_
    {
    class Program
        {
        static void Main(string[] args)
            {
            
            int N;
            N = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] mas = new int[N];
            mas[0] = 1;
            if (N != 1)
                res(mas, 2, N);
            else
                Console.WriteLine(1);
            Console.ReadKey();



            }
        public static int[] swap(int[] mas,int a, int b)
            {
            mas[a] += mas[b];
            mas[b] = mas[a] - mas[b];
            mas[a] = mas[a] - mas[b];
            return mas;
            }

        public static void WrOut(int[] mas)
            {
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i]);
            Console.WriteLine();
            }
        
        public static void res(int[] mas, int CurN, int N)
            {
            int i;
            mas[CurN - 1] = CurN;
            int[] clone = new int[N];
            Array.Copy(mas, clone, CurN);
            if (CurN != N)
                res(clone, CurN + 1, N);
            else
                WrOut(mas);

            i = 1;
            while (i<CurN)
                    {
                    swap(mas, CurN - i, CurN - i - 1);
                Array.Copy(mas, clone, CurN);
                if (CurN != N)
                    res(clone, CurN + 1, N);
                i++;
                    if (CurN == N)
                        WrOut(mas); 
                    }
                }

            }
        }

    

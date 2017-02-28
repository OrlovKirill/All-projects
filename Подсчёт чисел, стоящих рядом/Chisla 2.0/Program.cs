using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chisla
    {
    class Program
        {
        static void Main(string[] args)
            {
            Console.Write("Введите порядок матрицы: ");
            string s = Console.ReadLine();
            int n;
            Int32.TryParse(s, out n);
            Console.WriteLine();
            Console.Write("Введите диапазон значений: \nот 1 до ");
            s = Console.ReadLine();
            int p;
            Int32.TryParse(s, out p);
            int[,] a = new int[n, n];
            int[,] aa = new int[n, n];
            Console.WriteLine();
            
            Random rand = new Random();

           
            int i, j, max, rs;

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    a[i, j] = aa[i, j] = rand.Next(1, p + 1);

            writ(a, n);

           
            max = 0;

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    if (a[i, j] != 0)
                        {
                        rs = res(a, n, i, j) + 1;
                        if (rs > max)
                            max = rs;
                        }
            Console.WriteLine();
            Console.WriteLine("Чтобы вычислить результат, нажмите ENTER");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Результат: "+max);
            Console.ReadKey();

            }

        public static void writ(int[,] a, int n)
            {
            Console.Clear();
            for (int i = 0; i < n; i++)
                {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
                }
            }


        public static int res(int[,] a, int n, int i, int j)
            {
            int rs = 0;
            int p = a[i, j];
            a[i, j] = 0;
            
            if (i != n - 1 && a[i + 1, j] == p)
                {
                rs++;
                rs += res(a, n, i + 1, j);
                }
            if (j != n - 1 && a[i, j + 1] == p)
                {
                rs++;
                rs += res(a, n, i, j + 1);
                }
            if (i != 0 && a[i - 1, j] == p)
                {
                rs++;
                rs += res(a, n, i - 1, j);
                }
            if (j != 0 && a[i, j - 1] == p)
                {
                rs++;
                rs += res(a, n, i, j - 1);
                }

            return rs;
            }
        }
    }
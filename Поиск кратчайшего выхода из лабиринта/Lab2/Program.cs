using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
    {
    class Program
        {
        static void Main(string[] args)
            {
            char[,] a = new char[10, 10];

            byte i, j;
            int k1, k2, p1, p2, n, v;

            Random rand = new Random();
            
            
            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                    {
                    a[i, j] = '■';
                    
                    }
            output1(a);
            Console.WriteLine();
            Console.WriteLine("Генерирование лабиринта...");
            Thread.Sleep(2000);

            k1 = rand.Next(2, 8);
            k2 = rand.Next(2, 8);

            p1 = k1;
            p2 = k2;

            output(a);

            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                    if ((n = rand.Next(2)) == 0)
                        {
                        a[i, j] = 'O';
                        output1(a);
                        }

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    if (kv(a, i, j) == 4)
                        {
                        a[i, j] = '■';
                        output1(a);
                        }

            Console.WriteLine();
            Console.WriteLine("Установка местоположеения (*) ...");
            Thread.Sleep(1000);
            a[k1, k2] = '*';
            Thread.Sleep(1000);

            output(a);
            Console.WriteLine();
            Console.WriteLine("Поиск кратчайшего пути...");
            Thread.Sleep(1000);
            v = res(a, k1, k2);

            Console.WriteLine();
            if (v >= 250)
            Console.WriteLine("C’est la vie...");
            else
                Console.WriteLine("Длина кратчайшего пути равна "+v);
            Console.ReadKey();
            }

        static void output(char[,] a)
            {
            Console.Clear();
            for (int i = 0; i < 10; i++)
                {
                for (int j = 0; j < 10; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
                }
            Thread.Sleep(500);
            }

        static void output1(char[,] a)
            {
            Console.Clear();
            for (int i = 0; i < 10; i++)
                {
                for (int j = 0; j < 10; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
                }
            Thread.Sleep(5);
            }

        public static byte kv(char[,] a, int i, int j)
            {
            byte res = 0;
            if (a[i, j] == 'O')
                res++;
            if (a[i + 1, j] == 'O')
                res++;
            if (a[i, j + 1] == 'O')
                res++;
            if (a[i + 1, j + 1] == 'O')
                res++;
            return res;
            }

        public static byte war(char[,] a, int k1, int k2)
            {
            byte wr = 0;
            if (k1 % 9 == 0 | k2 % 9 == 0)
                return 1;
            else
                {
                if (a[k1 + 1, k2] == 'O')
                    wr++;
                if (a[k1, k2 + 1] == 'O')
                    wr++;
                if (a[k1 - 1, k2] == 'O')
                    wr++;
                if (a[k1, k2 - 1] == 'O')
                    wr++;
                return wr;
                }
            }


        public static int res(char[,] a, int k1, int k2)
            {
            if ((k1 % 9 == 0) | (k2 % 9 == 0))
                {
                a[k1, k2] = '!';
                output(a);
                return 1;
                }
            else
                {
                int t, b, r, l, rs;
                t = b = r = l = rs = 0;

                if (war(a, k1, k2) > 1 & (k1 % 9 > 0) & (k2 % 9 > 0))
                    {
                    if(a[k1,k2]!='*') a[k1, k2] = 'x';
                    if (a[k1 - 1, k2] == 'O')
                        {
                        output(a);
                        t = res(a, k1 - 1, k2) + 1;
                        }
                    else
                        t = byte.MaxValue;


                    if (a[k1 + 1, k2] == 'O')
                        {
                        output(a);
                        b = res(a, k1 + 1, k2) + 1;
                        }
                    else
                        b = byte.MaxValue;


                    if (a[k1, k2 + 1] == 'O')
                        {
                        output(a);
                        r = res(a, k1, k2 + 1) + 1;
                        }
                    else
                        r = byte.MaxValue;


                    if (a[k1, k2 - 1] == 'O')
                        {
                        output(a);
                        l = res(a, k1, k2 - 1) + 1;
                        }
                    else
                        l = byte.MaxValue;

                    return rs = Math.Min(Math.Min(t, b), Math.Min(r, l));
                    }


                while (war(a, k1, k2) == 1 & (k1 % 9 > 0) & (k2 % 9 > 0))
                    {
                    
                       
                    if (a[k1 - 1, k2] == 'O')
                        {
                        rs++;
                        if (a[k1 , k2] != '*')
                            a[k1, k2] = 'x';
                        k1--;
                        output(a);
                        continue;
                        }

                    if (a[k1 + 1, k2] == 'O')
                        {
                        rs++;
                        if (a[k1 , k2] != '*')
                            a[k1, k2] = 'x';
                        k1++;
                        output(a);
                        continue;
                        }

                    if (a[k1, k2 + 1] == 'O')
                        {
                        rs++;
                        if (a[k1 , k2] != '*')
                            a[k1, k2] = 'x';
                        k2++;
                        output(a);
                        continue;
                        }

                    if (a[k1, k2 - 1] == 'O')
                        {
                        rs++;
                        if (a[k1 , k2] != '*')
                            a[k1, k2] = 'x';
                        k2--;
                        output(a);
                        continue;
                        }
                    }
                if (war(a, k1, k2) == 0 & (k1 % 9 > 0) & (k2 % 9 > 0))
                    {
                    a[k1, k2] = '#';
                    output(a);
                    return byte.MaxValue;
                    }
                else

                    return rs + res(a, k1, k2);
                }

            }
        }
    }
    

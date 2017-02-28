using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
    {

    struct Tower
        {
        public int n,from,to,help,stg;
        }
    class Program
        {
        static void Main (string[] agrs)
            {
            int n, from, to, help, stg;
           stg = 0;
            from = 1;
            help = 2;
            to = 3;
            n = Int32.Parse(Console.ReadLine());
            General(n, from, to, help, stg);
            Console.ReadKey();
            }
        public static void General(int n, int from, int to, int help, int stg)
            {
            
            Stack<Tower> stack = new Stack<Tower>();
            Tower tow;
            
            
            tow.n = n;
            tow.from = from;
            tow.to = to;
            tow.help = help;
            tow.stg = stg;
            stack.Push(tow);

            while (stack.Count > 0)
                {
                
                tow = stack.Peek();
                switch (tow.stg)
                    {
                    case 0:
                        Tower NewTow;
                        if (tow.n == 0)
                            stack.Pop();
                        else
                            {
                            tow.stg++;
                                stack.Pop();
                                stack.Push(tow);
                            NewTow.n = tow.n - 1;
                            NewTow.from = tow.from;
                            NewTow.to = tow.help;
                            NewTow.help = tow.to;
                            NewTow.stg = 0;
                            stack.Push(NewTow);
                            }
                        break;
                    case 1:
                        Console.WriteLine("[{0}]  =>  [{1}]", tow.from, tow.to);
                        tow.stg++;
                            stack.Pop();
                            stack.Push(tow);
                            NewTow.n = tow.n - 1;
                        NewTow.from = tow.help;
                        NewTow.to = tow.to;
                        NewTow.help = tow.from;
                        NewTow.stg = 0;
                        stack.Push(NewTow);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    }
                
                
                }
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Iteration_Labyrinth {

    struct lab {
        public int k1, k2, CurrentSteps, MinSteps;
        public char[,] Array;
        }

    class Program {
        public static void Main ( string[] args ) {
            char[,] Array = new char[ 10 , 10 ];

            byte i, j;
            int k1, k2, pos1, pos2, n, Res;

            Random rand = new Random ();


            for (i = 0 ; i < 10 ; i++)
                for (j = 0 ; j < 10 ; j++) {
                    Array[ i , j ] = '■';

                    }
            Print1 (Array);
            Console.WriteLine ();
            Console.WriteLine ("Генерирование лабиринта...");
            Thread.Sleep (2000);

            k1 = rand.Next (2 , 8);
            k2 = rand.Next (2 , 8);

            pos1 = k1;
            pos2 = k2;

            Print (Array);

            for (i = 0 ; i < 10 ; i++)
                for (j = 0 ; j < 10 ; j++)
                    if ((n = rand.Next (10)) < 5) {
                        Array[ i , j ] = 'O';
                        Print1 (Array);
                        }

            for (i = 0 ; i < 9 ; i++)
                for (j = 0 ; j < 9 ; j++)
                    if (Insularity (Array , i , j) == 4) {
                        Array[ i , j ] = '■';
                        Print1 (Array);
                        }
            if (Array[ k1 - 1 , k2 ] == 'O' & Array[ k1 - 1 , k2 - 1 ] == 'O' & Array[ k1 , k2 - 1 ] == 'O')
                Array[ k1 - 1 , k2 - 1 ] = '■';
            if (Array[ k1 - 1 , k2 ] == 'O' & Array[ k1 - 1 , k2 + 1 ] == 'O' & Array[ k1 , k2 + 1 ] == 'O')
                Array[ k1 - 1 , k2 + 1 ] = '■';
            if (Array[ k1 + 1 , k2 ] == 'O' & Array[ k1 + 1 , k2 + 1 ] == 'O' & Array[ k1 , k2 + 1 ] == 'O')
                Array[ k1 + 1 , k2 + 1 ] = '■';
            if (Array[ k1 + 1 , k2 ] == 'O' & Array[ k1 + 1 , k2 + 1 ] == 'O' & Array[ k1 , k2 - 1 ] == 'O')
                Array[ k1 + 1 , k2 + 1 ] = '■';
            if (Array[ k1 - 1 , k2 - 1 ] == 'O' & Array[ k1 - 1 , k2 + 1 ] == 'O' & Array[ k1 - 1 , k2 ] == 'O')
                Array[ k1 - 1 , k2 - 1 ] = '■';
            if (Array[ k1 - 1 , k2 - 1 ] == 'O' & Array[ k1 , k2 - 1 ] == 'O' & Array[ k1 + 1 , k2 - 1 ] == 'O')
                Array[ k1 + 1 , k2 - 1 ] = '■';
            if (Array[ k1 + 1 , k2 ] == 'O' & Array[ k1 + 1 , k2 - 1 ] == 'O' & Array[ k1 + 1 , k2 + 1 ] == 'O')
                Array[ k1 + 1 , k2 + 1 ] = '■';
            if (Array[ k1 - 1 , k2 + 1 ] == 'O' & Array[ k1 - +1 , k2 + 1 ] == 'O' & Array[ k1 , k2 + 1 ] == 'O')
                Array[ k1 - 1 , k2 + 1 ] = '■';
            Print1 (Array);


            Console.WriteLine ();
            Console.WriteLine ("Установка местоположеения (*) ...");
            Thread.Sleep (1000);
            Array[ k1 , k2 ] = '*';
            Thread.Sleep (1000);

            Print (Array);
            Console.WriteLine ();
            Console.WriteLine ("Поиск кратчайшего пути...");
            Thread.Sleep (1000);

            Stack<lab> stack = new Stack<lab> ();
            lab lab;

            lab.Array = Array;
            lab.k1 = k1;
            lab.k2 = k2;
            lab.CurrentSteps = 0;
            lab.MinSteps = byte.MaxValue;
            stack.Push (lab);
            bool CheckExit = false;

            while (stack.Count > 0) {

                lab = stack.Peek ();

                if (FreeCell (lab.Array , lab.k1 , lab.k2) > 1 & lab.k1 % 9 > 0 & lab.k2 % 9 > 0) {

                    lab NewLab;
                    if (lab.Array[ lab.k1 , lab.k2 ] != '*')
                        lab.Array[ lab.k1 , lab.k2 ] = 'x';
                    Print (lab.Array);


                    if (lab.Array[ lab.k1 - 1 , lab.k2 ] == 'O') {
                        NewLab.k1 = lab.k1 - 1;
                        NewLab.k2 = lab.k2;
                        NewLab.Array = lab.Array;
                        NewLab.CurrentSteps = 1;
                        NewLab.MinSteps = byte.MaxValue;
                        stack.Push (NewLab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 + 1 , lab.k2 ] == 'O') {
                        NewLab.k1 = lab.k1 + 1;
                        NewLab.k2 = lab.k2;
                        NewLab.Array = lab.Array;
                        NewLab.CurrentSteps = 1;
                        NewLab.MinSteps = byte.MaxValue;
                        stack.Push (NewLab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 , lab.k2 - 1 ] == 'O') {
                        NewLab.k1 = lab.k1;
                        NewLab.k2 = lab.k2 - 1;
                        NewLab.Array = lab.Array;
                        NewLab.CurrentSteps = 1;
                        NewLab.MinSteps = byte.MaxValue;
                        stack.Push (NewLab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 , lab.k2 + 1 ] == 'O') {
                        NewLab.k1 = lab.k1;
                        NewLab.k2 = lab.k2 + 1;
                        NewLab.Array = lab.Array;
                        NewLab.CurrentSteps = 1;
                        NewLab.MinSteps = byte.MaxValue;
                        stack.Push (NewLab);
                        continue;
                        }
                    }

                while (FreeCell (lab.Array , lab.k1 , lab.k2) == 1 & (lab.k1 % 9 > 0) & (lab.k2 % 9 > 0)) {

                    if (lab.Array[ lab.k1 , lab.k2 ] != '*')
                        lab.Array[ lab.k1 , lab.k2 ] = 'x';
                    Print (lab.Array);

                    if (lab.Array[ lab.k1 - 1 , lab.k2 ] == 'O') {
                        lab.CurrentSteps++;
                        lab.k1--;
                        stack.Pop ();
                        stack.Push (lab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 + 1 , lab.k2 ] == 'O') {
                        lab.CurrentSteps++;
                        lab.k1++;
                        stack.Pop ();
                        stack.Push (lab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 , lab.k2 - 1 ] == 'O') {
                        lab.CurrentSteps++;
                        lab.k2--;
                        stack.Pop ();
                        stack.Push (lab);
                        continue;
                        }
                    if (lab.Array[ lab.k1 , lab.k2 + 1 ] == 'O') {
                        lab.CurrentSteps++;
                        lab.k2++;
                        stack.Pop ();
                        stack.Push (lab);
                        continue;
                        }
                    }

                if (FreeCell (lab.Array , lab.k1 , lab.k2) == 0 & (lab.k1 % 9 > 0) & (lab.k2 % 9 > 0)) {
                    if (lab.Array[ lab.k1 , lab.k2 ] != '*')
                        lab.Array[ lab.k1 , lab.k2 ] = '#';
                    Print (lab.Array);
                    while (FreeCell (lab.Array , lab.k1 , lab.k2) == 0 && stack.Count > 1) {
                        lab.CurrentSteps += lab.MinSteps;
                        int CurrentSteps = lab.CurrentSteps;
                        stack.Pop ();
                        if (stack.Count > 0)
                            lab = stack.Peek ();
                        else
                            break;
                        if (CurrentSteps < lab.MinSteps) {
                            lab.MinSteps = CurrentSteps;
                            stack.Pop ();
                            stack.Push (lab);
                            }
                        }
                    if (FreeCell (lab.Array , lab.k1 , lab.k2) > 0) {
                        lab.MinSteps = byte.MaxValue;
                        lab.CurrentSteps = 0;
                        stack.Push (lab);
                        continue;
                        }
                    if (stack.Count == 1) {
                        lab.CurrentSteps += lab.MinSteps;
                        break;
                        }
                    }

                if (lab.k1 % 9 == 0 || lab.k2 % 9 == 0) {
                    CheckExit = true;
                    int CurrentSteps = lab.CurrentSteps;
                    lab.Array[ lab.k1 , lab.k2 ] = '!';
                    Print (lab.Array);
                    stack.Pop ();
                    if (stack.Count > 0)
                        lab = stack.Peek ();
                    else
                        break;
                    if (CurrentSteps < lab.MinSteps) {
                        lab.MinSteps = CurrentSteps;
                        stack.Pop ();
                        stack.Push (lab);
                        }
                    if (FreeCell (lab.Array , lab.k1 , lab.k2) > 0) {
                        lab.MinSteps = byte.MaxValue;
                        lab.CurrentSteps = 0;
                        stack.Push (lab);
                        continue;
                        }
                    else {
                        while (FreeCell (lab.Array , lab.k1 , lab.k2) == 0 && stack.Count > 1) {
                            lab.CurrentSteps += lab.MinSteps;
                            CurrentSteps = lab.CurrentSteps;
                            stack.Pop ();
                            lab = stack.Peek ();
                            if (CurrentSteps < lab.MinSteps) {
                                lab.MinSteps = CurrentSteps;
                                stack.Pop ();
                                stack.Push (lab);
                                }
                            }
                        }
                    }
                }

            Console.WriteLine ();
            if (CheckExit)
                Console.WriteLine ("Длина кратчайшего пути равна " + ++lab.CurrentSteps);
            else
                Console.WriteLine ("C’est la vie...");

            Console.ReadKey ();
            }

        static void Print ( char[,] Array ) {
            Console.Clear ();
            for (int i = 0 ; i < 10 ; i++) {
                for (int j = 0 ; j < 10 ; j++)
                    Console.Write (Array[ i , j ] + " ");
                Console.WriteLine ();
                }
            Thread.Sleep (500);
            }

        static void Print1 ( char[,] Array ) {
            Console.Clear ();
            for (int i = 0 ; i < 10 ; i++) {
                for (int j = 0 ; j < 10 ; j++)
                    Console.Write (Array[ i , j ] + " ");
                Console.WriteLine ();
                }
            Thread.Sleep (5);
            }

        public static byte Insularity ( char[,] Array , int i , int j ) {
            byte CurrentSteps = 0;
            if (Array[ i , j ] == 'O')
                CurrentSteps++;
            if (Array[ i + 1 , j ] == 'O')
                CurrentSteps++;
            if (Array[ i , j + 1 ] == 'O')
                CurrentSteps++;
            if (Array[ i + 1 , j + 1 ] == 'O')
                CurrentSteps++;
            return CurrentSteps;
            }

        public static byte FreeCell ( char[,] Array , int k1 , int k2 ) {
            byte wr = 0;
            if (k1 % 9 == 0 | k2 % 9 == 0)
                return 1;
            else {
                if (Array[ k1 + 1 , k2 ] == 'O')
                    wr++;
                if (Array[ k1 , k2 + 1 ] == 'O')
                    wr++;
                if (Array[ k1 - 1 , k2 ] == 'O')
                    wr++;
                if (Array[ k1 , k2 - 1 ] == 'O')
                    wr++;
                return wr;
                }
            }

        }
    }



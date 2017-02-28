using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
    {
    class Program
        {
        static void Main(string[] args)
            {

            int i, j, k,IndOfNum, min, MinInd;
            long fact = 1;
            int n = int.Parse(Console.ReadLine());
            int[] CurrentPerm = new int[n];

            for (i = 2; i <= n; i++)
                fact *= i;

            for (i = 0; i < CurrentPerm.Length; i++)
                CurrentPerm[i] = i+1;

            for (j = 0; j < CurrentPerm.Length; j++)
                Console.Write(CurrentPerm[j] + " ");
            Console.WriteLine();

            for (i = 1; i <= fact-1; i++)
                {
                for (j = CurrentPerm.Length - 1; j > 0; j--)
                    if (CurrentPerm[j] > CurrentPerm[j - 1])

                        {
                        IndOfNum = j-1;
                        min = CurrentPerm[IndOfNum+1];
                        MinInd = IndOfNum+1;

                        for (k = IndOfNum; k <= CurrentPerm.Length - 1; k++)
                            if (CurrentPerm[k] > CurrentPerm[IndOfNum] && CurrentPerm[k] < min)

                                {
                                min = CurrentPerm[k];
                                MinInd = k;
                                }
                        
                        CurrentPerm[IndOfNum] += CurrentPerm[MinInd];
                        CurrentPerm[MinInd] = CurrentPerm[IndOfNum] - CurrentPerm[MinInd];
                        CurrentPerm[IndOfNum] -= CurrentPerm[MinInd];

                        Array.Sort(CurrentPerm, IndOfNum + 1, CurrentPerm.Length - IndOfNum - 1);
                        break;
                        }

                for (j = 0; j < CurrentPerm.Length; j++)
                    Console.Write(CurrentPerm[j] + " ");
                Console.WriteLine();
                }

            Console.ReadKey();
            }
        }
    }

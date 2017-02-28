using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint {
    class Program {
        static void  Main(string[] args) {
            int a;
            int.TryParse(args[0], out a);
            char[,] lab = new char[a, a];
            int i, j;
            Random rand = new Random();
            int r;
            for (i = 0; i < a; i++)
                for (j = 0; j < a; j++) {
                    r = rand.Next(0, 2);
                    if (r == 1)
                        lab[i, j] = 'o';
                    else
                        lab[i, j] = ' ';
                    }
                       
            i = j = 0;
            while (!((i == a - 1) & (j == a - 1))) {
                if (i == a - 1)
                    r = 2;
                else
                        if (j == a - 1)
                    r = 0;
                else
                    r = rand.Next(0, 3);

                switch (r) {
                    case 0:
                        i++;
                        lab[i, j] = 'o';
                        continue;

                    case 1:
                        i++;
                        j++;
                        lab[i, j] = 'o';
                        continue;

                    case 2:
                        j++;
                        lab[i, j] = 'o';
                        continue;

                    }
                }
            lab[0, 0] = lab[a - 1, a - 1] = 'X';
            for (i = 0; i < a; i++) {
                    for (j = 0; j < a; j++)
                        Console.Write(lab[i, j]+" ");
                    Console.WriteLine();
                    }

               
                
            Console.ReadKey();
                }
                }
        
        }
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1112 {
    class Program {

        static void Main(string[] args) {

            int i = 1;
            int j;
            int k = args.Length - 1;
            bool f = false;
            float a, b, c;
            while (i < k) {
                if (args[i] == "*") {
                    float.TryParse(args[i - 1], out a);
                    float.TryParse(args[i + 1], out b);
                    c = a * b;
                    args[i - 1] = c.ToString();
                    for (j = i; j <= k - 2; j++)
                        args[j] = args[j + 2];
                    k -= 2;
                    }
                if (args[i] == "/") {
                    float.TryParse(args[i - 1], out a);
                    float.TryParse(args[i + 1], out b);
                    if (b == 0) {
                        Console.WriteLine("На 0 делить нельзя!");
                        f = true;
                        break;
                        }
                    c = a / b;
                    args[i - 1] = c.ToString();
                    for (j = i; j <= k - 2; j++)
                        args[j] = args[j + 2];
                    k -= 2;
                    }
                if ((args[i] != "*") & (args[i] != "/"))
                    i += 2;
                }
            i = 1;
            if (f == false)
                while (k != 0) {
                    if (args[i] == "+") {
                        float.TryParse(args[i - 1], out a);
                        float.TryParse(args[i + 1], out b);
                        c = a + b;
                        args[i - 1] = c.ToString();
                        for (j = i; j <= k - 2; j++)
                            args[j] = args[j + 2];
                        k -= 2;
                        }
                    if (k > 0)
                        if (args[i] == "-") {
                            float.TryParse(args[i - 1], out a);
                            float.TryParse(args[i + 1], out b);
                            c = a - b;
                            args[i - 1] = c.ToString();
                            for (j = i; j <= k - 2; j++)
                                args[j] = args[j + 2];
                            k -= 2;
                            }
                    }
            if (f == false)
                Console.WriteLine(args[0]);

            Console.ReadKey();
            }
        }
    }

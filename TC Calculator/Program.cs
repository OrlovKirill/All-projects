using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1112 {
    class Program {

        static void Main(string [] args) {

            string s = "15-9";
            string[] arr = new string[0];
            int i = 1;
            int j;
            
            bool f = false;
            decimal a, b, c;
            
            StringToArray(s , ref arr);
            int k = arr.Length - 1;

            while (i < k) {
                if (arr[i] == "*") {
                    try {
                        a = Convert.ToDecimal(arr[i - 1]);
                        b = Convert.ToDecimal(arr[i + 1]);
                        c = a * b;
                        arr[i - 1] = c.ToString();
                        }
                    catch (FormatException) {
                        Console.WriteLine("Invalid format of the entered data. Please enter the correct values.");
                        f = true;
                        }
                    catch (OverflowException) {
                        Console.WriteLine("Too much or too little input value. Please enter the correct values.");
                        f = true;
                        }


                    for (j = i; j <= k - 2; j++)
                        arr[j] = arr[j + 2];
                    k -= 2;
                    }
                if (arr[i] == "/") {
                    try {
                        a = Convert.ToDecimal(arr[i - 1]);
                        b = Convert.ToDecimal(arr[i + 1]);

                        /*if (b == 0) {
                            Console.WriteLine("На 0 делить нельзя!");
                            f = true;
                            break;
                            }*/
                        c = a / b;
                        arr[i - 1] = c.ToString();
                        }
                    catch (DivideByZeroException) {
                        Console.WriteLine("An attempt to divide by zero. Please enter the correct values.");
                        f = true;
                        }
                    catch (FormatException) {
                        Console.WriteLine("Invalid format of the entered data. Please enter the correct values.");
                        f = true;
                        }
                    catch (OverflowException) {
                        Console.WriteLine("Too much or too little input value. Please enter the correct values.");
                        f = true;
                        }


                    for (j = i; j <= k - 2; j++)
                        arr[j] = arr[j + 2];
                    k -= 2;
                    }
                if ((arr[i] != "*") & (arr[i] != "/"))
                    i += 2;
                }
            i = 1;
            if (f == false)
                while (k != 0) {
                    if (arr[i] == "+") {
                        try {
                            a = Convert.ToDecimal(arr[i - 1]);
                            b = Convert.ToDecimal(arr[i + 1]);
                            c = a + b;
                            arr[i - 1] = c.ToString();
                            }
                        catch (FormatException) {
                            Console.WriteLine("Invalid format of the entered data. Please enter the correct values.");
                            f = true;
                            }
                        catch (OverflowException) {
                            Console.WriteLine("Too much or too little input value. Please enter the correct values.");
                            f = true;
                            }

                        for (j = i; j <= k - 2; j++)
                            arr[j] = arr[j + 2];
                        k -= 2;
                        }
                    if (k > 0)
                        if (arr[i] == "-") {
                            try {
                                a = Convert.ToDecimal(arr[i - 1]);
                                b = Convert.ToDecimal(arr[i + 1]);
                                c = a - b;
                                arr[i - 1] = c.ToString();
                                }
                            catch (FormatException) {
                                Console.WriteLine("Invalid format of the entered data. Please enter the correct values.");
                                f = true;
                                }
                            catch (OverflowException) {
                                Console.WriteLine("Too much or too little input value. Please enter the correct values.");
                                f = true;
                                }

                            for (j = i; j <= k - 2; j++)
                                arr[j] = arr[j + 2];
                            k -= 2;
                            }
                    }
            if (f == false)
                Console.WriteLine(arr[0]);

            Console.ReadKey();
            }
        public static void StringToArray (string arr , ref string[] num) {
            while (arr.Length > 0) {                                                      // перенос строки в массив

                Array.Resize<string>(ref num , num.Length + 1);

                if (Char.IsDigit(arr[0]) || arr[0] == ',') {
                    while (arr.Length > 0 && (Char.IsDigit(arr[0]) || arr[0] == ',')) {    // перенос числа в массив
                        num[num.Length - 1] += arr[0];
                        arr = arr.Remove(0 , 1);
                        }
                    continue;
                    }

                num[num.Length - 1] += arr[0];    // перенос символов в массив
                arr = arr.Remove(0 , 1);
                }
            }

        }
    }


/* Любое число пробелов в любом месте, любые символы на ввод (выводить ошибку), 
 * несколько знаков подряд, обработать точку и запятую в десятичных числах, проверить по длинне выражения, 
 * в непонятной ситуации сообщение об ошибке +если очень длинное число. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN {
    class Program {
        public static void Main (string[] args) {
            int i = 0;

            m: string[] num = new string[0];
            Console.WriteLine("Rules for writing: \n\n√(x)       =   s(x)\nln(x)      =   l(x)\nPow(x,y)   =   x^y\n\n\n\nEnter an expression:");
            string s = ReadDigitsFromConsole();
            if (!Check(s)) { 
            Console.WriteLine("\n\n\nInvalid entry! \nPress any key to restart.");
            Console.ReadKey();
            Console.Clear();
                goto m;
            }


            Console.WriteLine("\n");
            Stack<String> res = new Stack<String>();
            Stack<String> temp = new Stack<String>();

            DoCorrectOrder(ref s);
            for (i = 0 ; i < s.Length ; i++)
                ReName(ref s , i);
            StringToArray(s , ref num);

            RPN(ref res , ref temp , num);
            while (res.Count > 0)
                temp.Push(res.Pop());

            Console.WriteLine("The result of the conversion in RPN:");
            foreach (string k in temp)
                Console.Write(k+" ");

            Console.WriteLine("\n\n");
            Console.WriteLine("RESULT: ");
            
            while (temp.Count > 0)
                if (IsNumber(temp.Peek()))
                    res.Push(temp.Pop());
            else switch (temp.Pop()) {
                        case "+": res.Push(plus(res.Pop() , res.Pop())); break;
                        case "-": s=res.Pop(); res.Push(minus(res.Pop() , s)); break;
                        case "*": res.Push(umn(res.Pop() , res.Pop())); break;
                        case "/": s=res.Pop(); res.Push(delit(res.Pop() , s)); break;
                        case "^": s=res.Pop(); res.Push((Math.Pow(Convert.ToDouble(res.Pop()) , Convert.ToDouble(s)).ToString())); break;
                        case "s": res.Push((Math.Sqrt(Convert.ToDouble(res.Pop())).ToString())); break;
                        case "l": res.Push((Math.Log(Convert.ToDouble(res.Pop())).ToString())); break;
                        }
            Console.Write(res.Peek());
            Console.WriteLine("\n\n\n\n---------------------------------------------------------------\nNew calculation - press \"SPACE\"\nShut down - press another key ");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar) { Console.Clear(); goto m; } 
            }


        public static void StringToArray (string s , ref string[] num) {
            while (s.Length > 0) {                                                      // перенос строки в массив

                Array.Resize<string>(ref num , num.Length + 1);

                if (Char.IsDigit(s[0]) || s[0] == ',') {
                    while (s.Length > 0 && (Char.IsDigit(s[0]) || s[0] == ',')) {    // перенос числа в массив
                        num[num.Length - 1] += s[0];
                        s = s.Remove(0 , 1);
                        }
                    continue;
                    }

                num[num.Length - 1] += s[0];    // перенос символов в массив
                s = s.Remove(0 , 1);
                }
            }

        public static void DoCorrectOrder (ref string s) {
            int i = 0;
            while (i < s.Length) {
                switch (s[i]) {
                    case 's':
                        ReName(ref s , i);
                        Swap(ref s , i , IndexOfClosedBracked(s , i));
                        break;
                    case 'l':
                        ReName(ref s , i);
                        Swap(ref s , i , IndexOfClosedBracked(s , i));
                        break;
                    }
                i++;
                }
            }

        public static int IndexOfClosedBracked (string s , int ind) {
            int open = 1;
            int close = 0;
            int i;
            for (i = ind + 2 ; (open != close) & (i < s.Length) ; i++)
                switch (s[i]) {
                    case '(':
                        open++;
                        break;
                    case ')':
                        close++;
                        break;
                    }
            return i;
            }

        public static void Swap (ref string s , int from , int to) {
            char c = s[from];
            s = s.Remove(from , 1);
            s = s.Insert(to - 1 , c.ToString());
            }

        public static void ReName (ref string s , int index) {
            switch (s[index]) {
                case 's':
                    s = s.Remove(index , 1);
                    s = s.Insert(index , "q");
                    break;
                case 'l':
                    s = s.Remove(index , 1);
                    s = s.Insert(index , "n");
                    break;
                case 'q':
                    s = s.Remove(index , 1);
                    s = s.Insert(index , "s");
                    break;
                case 'n':
                    s = s.Remove(index , 1);
                    s = s.Insert(index , "l");
                    break;
                }
            }

        public static bool Check (string s) {
            int i;
            int open = 0;
            int close = 0;
            for (i = 0 ; i < s.Length ; i++)
                switch (s[i]) {
                    case '(':
                        open++;
                        break;
                    case ')':
                        close++;
                        break;
                    }
            if (open == close)
                return true;
            else {
                return false;
                }
            }

        public static void RPN (ref Stack<String> res , ref Stack<String> temp , string[] a) {
            int i;
            for (i = 0 ; i < a.Length ; i++) {

                if (IsNumber(a[i]))  // Число
                    res.Push(a[i]);
                else {
                    if (a[i] == "(") // Откр скобка
                        temp.Push(a[i]);
                    else
                    if (a[i] != ")" && (temp.Count == 0 || Prior(a[i]) > Prior(temp.Peek()))) // Знак с бОльшим приоритетом
                        temp.Push(a[i]);
                    else
                        if (a[i] != ")") // Знак с мЕньшим или равным приоритетом
                        {
                        while (temp.Count>0 && Prior(a[i]) <= Prior(temp.Peek())) 
                            res.Push(temp.Pop());
                            temp.Push(a[i]);
                            }
                    else {
                        while (temp.Peek() != "(") // Закр скобка
                            res.Push(temp.Pop());
                        temp.Pop();
                        }
                    }

                }
            while (temp.Count > 0)
                res.Push(temp.Pop());
            }

        public static bool IsNumber (string s) {
            if (Char.IsDigit(s[0]))
                return true;
            else
                return false;
            }

        public static byte Prior (string s) {
            switch (s) {
                case "^":
                    return 3;
                case "s":
                    return 3;
                case "l":
                    return 3;
                case "*":
                    return 2;
                case "/":
                    return 2;
                case "+":
                    return 1;
                case "-":
                    return 1;
                case "(":
                    return 0;
                }
            return 5;
            }


        private static string plus (string a , string b) {
            int i, c, zap, aa, bb;
            bool f = false;
            string res = "";
            aa = a.Length;
            bb = b.Length;
            if (a.IndexOf(',') > 0 || b.IndexOf(',') > 0) {
                if (a.IndexOf(',') > 0 && b.IndexOf(',') > 0)
                    if (a.Length - a.IndexOf(',') > b.Length - b.IndexOf(',')) {
                        c = a.Length - a.IndexOf(',') - b.Length + b.IndexOf(',');
                        for (i = b.Length ; i < c + bb ; i++)
                            b += "0";
                        }
                    else {
                        c = b.Length - b.IndexOf(',') - a.Length + a.IndexOf(',');
                        for (i = a.Length ; i < c + aa ; i++)
                            a += "0";
                        }
                if (a.IndexOf(',') > 0 && b.IndexOf(',') < 0) {
                    b += ",";
                    for (i = 1 ; i <= a.Length - a.IndexOf(',') - 1 ; i++)
                        b += "0";
                    }
                if (a.IndexOf(',') < 0 && b.IndexOf(',') > 0) {
                    a += ",";
                    for (i = 1 ; i <= b.Length - b.IndexOf(',') - 1 ; i++)
                        a += "0";
                    }
                }
            c = Math.Abs(a.Length - b.Length);
            if (a.Length > b.Length)
                for (i = 1 ; i <= c ; i++)
                    b = b.Insert(0 , "0");
            else
                for (i = 1 ; i <= c ; i++)
                    a = a.Insert(0 , "0");
            zap = a.Length - a.IndexOf(',') - 1;
            for (i = a.Length - 1 ; i > 0 ; i--)

                if (i != a.IndexOf(',')) {
                    c = (int)a[i] + (int)b[i] - 96;
                    if (f)
                        if (c < 9) {
                            res = res.Insert(0 , (c + 1).ToString());
                            f = false;
                            }
                        else {
                            f = true;
                            res = res.Insert(0 , (c - 9).ToString());
                            }
                    else if (c < 10)
                        res = res.Insert(0 , c.ToString());
                    else {
                        f = true;
                        res = res.Insert(0 , (c - 10).ToString());
                        }
                    }
            if (i == 0)
                if (f)
                    res = res.Insert(0 , ((int)a[i] + (int)b[i] - 95).ToString());
                else
                    res = res.Insert(0 , ((int)a[i] + (int)b[i] - 96).ToString());

            if (a.IndexOf(',') > 0)
                res = res.Insert(res.Length - zap , ",");
            return (res);
            }

        private static string minus (string a , string b) {
            int i, c, zap, aa, bb;
            bool f = false;
            string res = "";
            aa = a.Length;
            bb = b.Length;
            if (a.IndexOf(',') > 0 || b.IndexOf(',') > 0) {
                if (a.IndexOf(',') > 0 && b.IndexOf(',') > 0)
                    if (a.Length - a.IndexOf(',') > b.Length - b.IndexOf(',')) {
                        c = a.Length - a.IndexOf(',') - b.Length + b.IndexOf(',');
                        for (i = b.Length ; i < c + bb ; i++)
                            b += "0";
                        }
                    else {
                        c = b.Length - b.IndexOf(',') - a.Length + a.IndexOf(',');
                        for (i = a.Length ; i < c + aa ; i++)
                            a += "0";
                        }
                if (a.IndexOf(',') > 0 && b.IndexOf(',') < 0) {
                    b += ",";
                    for (i = 1 ; i <= a.Length - a.IndexOf(',') - 1 ; i++)
                        b += "0";
                    }
                if (a.IndexOf(',') < 0 && b.IndexOf(',') > 0) {
                    a += ",";
                    for (i = 1 ; i <= b.Length - b.IndexOf(',') - 1 ; i++)
                        a += "0";
                    }
                }
            c = Math.Abs(a.Length - b.Length);
            if (a.Length > b.Length)
                for (i = 0 ; i < c ; i++)
                    b = b.Insert(0 , "0");
            else
                for (i = 1 ; i <= c ; i++)
                    a = a.Insert(0 , "0");


            zap = a.Length - a.IndexOf(',') - 1;
            for (i = a.Length - 1 ; i >= 0 ; i--)

                if (i != a.IndexOf(',')) {
                    c = (int)a[i] - (int)b[i];
                    if (f)
                        if (c - 1 >= 0) {
                            res = res.Insert(0 , (c - 1).ToString());
                            f = false;
                            }
                        else {
                            f = true;
                            res = res.Insert(0 , (10 - Math.Abs(c) - 1).ToString());
                            }
                    else

                        if (c >= 0)
                        res = res.Insert(0 , c.ToString());
                    else {
                        f = true;
                        res = res.Insert(0 , (10 + c).ToString());
                        }
                    }

            if (a.IndexOf(',') > 0)
                res = res.Insert(res.Length - zap , ",");
            DeleteZero(ref res);
            return (res);


            }

        private static string umn (string a , string b) {
            int i, k, j, c, zap, aa, bb;
            string a1, b1;

            string res = "0";
            string res1;
            aa = a.Length;
            bb = b.Length;
            a1 = a;
            b1 = b;
            if (a.IndexOf(',') > 0 || b.IndexOf(',') > 0) {
                if (a.IndexOf(',') > 0 && b.IndexOf(',') > 0)
                    if (a.Length - a.IndexOf(',') > b.Length - b.IndexOf(',')) {
                        c = a.Length - a.IndexOf(',') - b.Length + b.IndexOf(',');
                        for (i = b.Length ; i < c + bb ; i++)
                            b += "0";
                        }
                    else {
                        c = b.Length - b.IndexOf(',') - a.Length + a.IndexOf(',');
                        for (i = a.Length ; i < c + aa ; i++)
                            a += "0";
                        }
                if (a.IndexOf(',') > 0 && b.IndexOf(',') < 0) {
                    b += ",";
                    for (i = 1 ; i <= a.Length - a.IndexOf(',') - 1 ; i++)
                        b += "0";
                    }
                if (a.IndexOf(',') < 0 && b.IndexOf(',') > 0) {
                    a += ",";
                    for (i = 1 ; i <= b.Length - b.IndexOf(',') - 1 ; i++)
                        a += "0";
                    }
                }
            c = Math.Abs(a.Length - b.Length);
            if (a.Length > b.Length)
                for (i = 0 ; i < c ; i++)
                    b = b.Insert(0 , "0");
            else
                for (i = 1 ; i <= c ; i++)
                    a = a.Insert(0 , "0");


            zap = a.Length - a.IndexOf(",") - 1;
            if (a.IndexOf(",") > 0 && b.IndexOf(",") > 0) {
                a = a.Remove(a.IndexOf(",") , 1);
                b = b.Remove(b.IndexOf(",") , 1);
                }
            else {
                if (a.IndexOf(",") > 0)
                    a = a.Remove(a.IndexOf(",") , 1);
                if (b.IndexOf(",") > 0)
                    b = b.Remove(b.IndexOf(",") , 1);
                }

            for (k = (b.Length - 1) ; k >= 0 ; k--) {
                res1 = "0";
                for (j = 1 ; j <= ((int)b[k] - 48) ; j++)
                    res1 = plus(res1 , a);

                for (j = 1 ; j <= b.Length - 1 - k ; j++)
                    res1 += "0";
                res = plus(res , res1);
                }
            if (a1.IndexOf(",") > 0 && b1.IndexOf(",") > 0)
                res = res.Insert(res.Length - 2 * zap , ",");
            else if (a1.IndexOf(",") > 0)
                res = res.Insert(res.Length - 2 * zap , ",");
            else if (b1.IndexOf(",") > 0)
                res = res.Insert(res.Length - 2 * zap , ",");
            if (res[0] == ',')
                res = res.Insert(0 , "0");
            while (res[0] == '0')
                if (res != "0")
                    res = res.Remove(0 , 1);
                else
                    break;
            if (res.IndexOf(",") > 0)
                while (res[res.Length - 1] == '0')
                    res = res.Remove(res.Length - 1);
            return (res);
            }

        private static string delit (string a , string b) {


            domn(ref a , ref b);

            string res = "";
            string t, temp;
            int i;
            string aa = a;

            while (res.Length < 300) {
                if (umn(res , b) == aa)
                    break;
                i = 0;
                if (a == "0")
                    return res + "0";
                if (srav(a , b) == 2 && res.IndexOf(',') < 0) {
                    res += ",";
                    a += "0";
                    i++;
                    }
                while (srav(a , b) == 2) {
                    if (res.IndexOf(',') >= 0 && i > 0)
                        res += "0";
                    a += "0";
                    i++;
                    }

                if (srav(b , a.Substring(0 , b.Length)) > 1)
                    t = a.Substring(0 , b.Length);
                else
                    t = a.Substring(0 , b.Length + 1);

                a = a.Remove(0 , t.Length);
                temp = b;

                for (i = 1 ; srav(temp , t) == 2 ; i++)
                    temp = plus(temp , b);

                if (srav(temp , t) >= 2)
                    res += i.ToString();
                else {
                    res += (i - 1).ToString();
                    temp = minus(temp , b);
                    }
                t = minus(t , temp);

                a = a.Insert(0 , t);
                DeleteZero(ref a);
                if (res[0] == ',')
                    res = res.Insert(0 , "0");
                }

            return res;
            }

        private static int srav ( string a ,  string b) {
            int i;

            if (a[0] == '-')
                a = a.Remove(0 , 1);
            if (b[0] == '-')
                b = b.Remove(0 , 1);

            if (a.Length > b.Length)
                return 1;
            else

                if (b.Length > a.Length)
                return 2;
            else
                for (i = 0 ; i < a.Length ; i++)
                    if (a[i] != b[i])
                        if (a[i] > b[i])
                            return 1;
                        else
                            return 2;

            return 3;
            }

        private static void domn (ref string a , ref string b) {
            int i, c, aa, bb;
            aa = a.Length;
            bb = b.Length;

            if (a.IndexOf(',') > 0 || b.IndexOf(',') > 0) {
                if (a.IndexOf(',') > 0 && b.IndexOf(',') > 0) {
                    if (a.Length - a.IndexOf(',') > b.Length - b.IndexOf(',')) {
                        c = a.Length - a.IndexOf(',') - b.Length + b.IndexOf(',');
                        for (i = b.Length ; i < c + bb ; i++)
                            b += "0";
                        }
                    else {
                        c = b.Length - b.IndexOf(',') - a.Length + a.IndexOf(',');
                        for (i = a.Length ; i < c + aa ; i++)
                            a += "0";
                        }
                    a = a.Remove(a.IndexOf(',') , 1);
                    b = b.Remove(b.IndexOf(',') , 1);
                    }
                if (a.IndexOf(',') > 0 && b.IndexOf(',') < 0) {
                    for (i = 1 ; i <= a.Length - a.IndexOf(',') - 1 ; i++)
                        b += "0";
                    a = a.Remove(a.IndexOf(",") , 1);
                    }
                if (a.IndexOf(',') < 0 && b.IndexOf(',') > 0) {
                    for (i = 1 ; i <= b.Length - b.IndexOf(',') - 1 ; i++)
                        a += "0";
                    b = b.Remove(b.IndexOf(",") , 1);
                    }
                }

            if (a[0] == '0')
                while (a[0] == '0')
                    a = a.Remove(0 , 1);

            if (b[0] == '0')
                while (b[0] == '0')
                    b = b.Remove(0 , 1);
            }
        private static void DeleteZero (ref string a) {
            while (a.Length > 1 && a[0] == '0' && a[1] != ',')
                a = a.Remove(0 , 1);
            if (a.IndexOf(',') >= 0)
                while (a[a.Length - 1] == '0' && a.Length > 1)
                    a.Remove(a.Length - 1);
            }

        public static string ReadDigitsFromConsole () {
            string result = "";
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key) {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0) {
                            result = result.Remove(result.Length - 1 , 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                            }
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return result;
                    default:
                        if (char.IsDigit(key.KeyChar) || key.KeyChar==43 || key.KeyChar == 42 || key.KeyChar == 28 || 
                            key.KeyChar == 29 || key.KeyChar == 44 || key.KeyChar == 45 || key.KeyChar == 47 || 
                            key.KeyChar == 40 || key.KeyChar == 41 || key.KeyChar == 115 || key.KeyChar == 108 || key.KeyChar == 94) {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                            }
                        break;
                    }
                }
            }

        }
    }
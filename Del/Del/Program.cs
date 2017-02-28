using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Del
    {
    class Program
        {
        static void Main(string[] args)
            {
            string a, b;

            a = Console.ReadLine();
            //b = Console.ReadLine();
            Console.WriteLine(sqrt(a));
            Console.ReadKey();
            }

        
        private static string delit(string a, string b)
            {
           

            domn(ref a ,ref b);

            string res = "";
            string t, mn;
            int i;

            while (res.Length < 1000) {
               
                    i = 0;
                if (a == "0")
                    return  res+"0";
                if (srav(a , b) == 2 && res.IndexOf(',') < 0) {
                    res += ",";
                    a += "0";
                    i++;
                    }
                while (srav(a , b) == 2) {
                    if (res.IndexOf(',')>=0 && i>0)
                    res += "0";
                    a += "0";
                    i++;
                    }

                        if (srav(b , a.Substring(0 , b.Length)) > 1)
                    t = a.Substring(0 , b.Length);
                else
                    t = a.Substring(0 , b.Length + 1);

                a = a.Remove(0 , t.Length);
                mn = b;

                for (i = 1 ; srav(mn , t) == 2 ; i++)
                    mn = plus(mn, b);

                if (srav(mn , t) >= 2)
                    res += i.ToString();
                else {
                    res += (i - 1).ToString();
                    mn = minus(mn , b);
                    }
                t = minus(t , mn);

                a = a.Insert(0 , t);
                DeleteZero(ref a);
                if (res[0] == ',')
                    res = res.Insert(0 , "0");
                }

            return res;
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
            if (a == b)
                return "0";
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
            DeleteZero(ref res);
            if (res.IndexOf(",") > 0)
                while (res[res.Length - 1] == '0')
                    res = res.Remove(res.Length - 1);
            return (res);
            }
        private static int srav(string a, string b)
            {
            int i;
            if (a.Length > b.Length)
                return 1;
            else
                
                if (b.Length > a.Length)
                    return 2;
                else
                    for (i = 0; i < a.Length; i++)
                        if (a[i] != b[i])
                            if (a[i] > b[i])
                                return 1;
                            else
                                return 2;
                
            return 3;
            }
        private static void domn(ref string a, ref string b) {
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
        private static void DeleteZero(ref string a) {
            while (a.Length > 1 && a[0] == '0' && a[1] != ',')
                a = a.Remove(0 , 1);
            if (a.IndexOf(',')>=0)
            while (a[a.Length - 1] == '0' && a.Length > 1)
                a.Remove(a.Length - 1);
            if (a[a.Length - 1] == ',')
                a = a.Remove(a.Length - 1);
            }


        private static string sqrt(string a) {
            string b, c, res,o,aa;
            int i;
            DeleteZero(ref a);
            aa = a;

            int zap;
            if (a.IndexOf(',') > 0)
                zap = a.IndexOf(',');
            else
                zap = a.Length;
            if (zap % 2 > 0)
                b = a.Substring(0 , 1);
            else
                b = a.Substring(0 , 2);
            a = a.Remove(0 , b.Length);
            if (a.Length == 1)
                a += "0";


            res = Math.Truncate(Math.Sqrt(Int32.Parse(b))).ToString(); //первая цифра результата
            
            if (umn(res , res) == aa)
                return res;

            if (a.IndexOf(',')>=0)
            a = a.Remove(a.IndexOf(',') , 1);

            if (a.Length < 2) {
                int l = a.Length;
                for (i = 1 ; i <= 2 - l ; i++)
                    a += "0";
                }
            c = minus(b , umn(res , res)) + a.Substring(0 , 2);
            DeleteZero(ref c);
            a = a.Remove(0 , 2);
            
            i = 0;
            o = "0";
            while (srav(o , c) == 2) {
                i++;
                o = umn(umn(res , "2") + i.ToString() , i.ToString());
                }

            if (srav(o , c) == 1) {
                i--;
                o = umn(umn(res , "2") + i.ToString() , i.ToString());
                }

            res += i.ToString();

            if (aa.IndexOf(',') >= 0) {
                if (umn(res , res) == aa.Remove(aa.IndexOf(',') , 1)) {
                    if (aa.IndexOf(',') > 0)
                        res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.IndexOf(',') + 1) / 2))) , ",");
                    else
                        res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2) + 1))) , ",");
                    DeleteZero(ref res);
                    return res;
                    }
                }
            else
            if (umn(res , res) == aa) {
                if (aa.IndexOf(',') > 0)
                    res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.IndexOf(',') + 1) / 2))) , ",");
                else
                    res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2) + 1))) , ",");
                DeleteZero(ref res);
                return res;
                }

            if (a.Length>0 && a[0] == ',') {
                res += ",";
                a = a.Remove(0 , 1);
                }

            if (a.Length < 2) {
                int l = a.Length;
                for (i = 1 ; i <= 2 - l ; i++)
                    a += "0";
                }

            // ////////////////////////////////

            while (res.Length < 60) {

                b = minus(c , o);
                c = b + a.Substring(0 , 2);
                a = a.Remove(0 , 2);

                i = 0;
                o = "0";
                while (srav(o , c) == 2) {
                    i++;
                    o = umn(umn(res , "2") + i.ToString() , i.ToString());
                    }

                if (srav(o , c) == 1) {
                    i--;
                    o = umn(umn(res , "2") + i.ToString() , i.ToString());
                    }

                res += i.ToString();


                if (aa.IndexOf(',') >= 0) {
                    if (umn(res , res) == aa.Remove(aa.IndexOf(',') , 1)) {
                        if (aa.IndexOf(',') > 0)
                            res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.IndexOf(',') + 1) / 2))) , ",");
                        else
                            res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2)+1))) , ",");
                        DeleteZero(ref res);
                        return res;
                        }
                    }
                else
         if (umn(res , res) == aa) {
                    if (aa.IndexOf(',') > 0)
                        res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.IndexOf(',') + 1) / 2))) , ",");
                    else
                        res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2)+1))) , ",");
                    DeleteZero(ref res);
                    return res;
                    }

                if (a.Length>0 && a[0] == ',') {
                    res += ",";
                    a = a.Remove(0 , 1);
                    }

                if (a.Length < 2) {
                    int l = a.Length;
                    for (i = 1 ; i <= 2 - l ; i++)
                        a += "0";
                    }

                }


            if (aa.IndexOf(',') >= 0) 
                res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.IndexOf(',') + 1) / 2))) , ","); 
            else
                res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2)+1))) , ",");
                    DeleteZero(ref res);
            return res;
            }
        }
    }

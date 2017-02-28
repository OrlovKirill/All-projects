using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calc_2._0 {
    public partial class Form1: Form {
        string[] ss = new string[1];
        ulong i = 0;
        int j;


        string s;
        public Form1 () {
            InitializeComponent();
            }

        private void Form1_Load (object sender , EventArgs e) {
            this.KeyPreview = true;
            button17.Select();

            }



        // VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV  [Описание нажатия кнопок с цифрами и точкой]  VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV 

        private void button1_Click (object sender , EventArgs e) {
            textBox1.Text += "1";
            s += "1";
            ss[i] += "1";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button2_Click (object sender , EventArgs e) {
            textBox1.Text += "2";
            s += "2";
            ss[i] += "2";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button3_Click (object sender , EventArgs e) {
            textBox1.Text += "3";
            s += "3";
            ss[i] += "3";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button4_Click (object sender , EventArgs e) {
            textBox1.Text += "4";
            s += "4";
            ss[i] += "4";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button5_Click (object sender , EventArgs e) {
            textBox1.Text += "5";
            s += "5";
            ss[i] += "5";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button6_Click (object sender , EventArgs e) {
            textBox1.Text += "6";
            s += "6";
            ss[i] += "6";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button7_Click (object sender , EventArgs e) {
            textBox1.Text += "7";
            s += "7";
            ss[i] += "7";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button8_Click (object sender , EventArgs e) {
            textBox1.Text += "8";
            s += "8";
            ss[i] += "8";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button9_Click (object sender , EventArgs e) {
            textBox1.Text += "9";
            s += "9";
            ss[i] += "9";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button10_Click (object sender , EventArgs e) {
            textBox1.Text += "0";
            s += "0";
            ss[i] += "0";
            if (s.Length >= 2)
                if (s[s.Length - 2] == '+' || s[s.Length - 2] == '-' || s[s.Length - 2] == '*' || s[s.Length - 2] == '/')
                    button16.Enabled = true;
            button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = true;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button16_Click (object sender , EventArgs e) {
            textBox1.Text += ",";
            s += ",";
            ss[i] += ",";
            button16.Enabled = button11.Enabled = button12.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = false;
            }
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\    [Описание нажатия кнопок с цифрами и точкой]    /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\




        // VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV    [ОПИСАНИЕ ДРУГИХ КНОПОК]    VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVv

        private void button15_Click (object sender , EventArgs e) {
            textBox1.Clear();
            s = "";

            i = 0;
            Array.Clear(ss , 0 , ss.Length);
            Array.Resize<string>(ref ss , 1);
            this.KeyPreview = true;
            button17.Select();
            button16.Enabled = true;
            }
        private void button11_Click (object sender , EventArgs e) {
            button16.Enabled = button11.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = false;
            textBox1.Text += "+";
            s += "+";
            Array.Resize<string>(ref ss , ss.Length + 2);
            i++;
            ss[i] = "+";
            i++;
            button16.Enabled = false;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button12_Click (object sender , EventArgs e) {
            button16.Enabled = button11.Enabled = button13.Enabled = button14.Enabled = button17.Enabled = false;
            textBox1.Text += "-";
            if (s[s.Length - 1] == '+' || s[s.Length - 1] == '-' || s[s.Length - 1] == '*' || s[s.Length - 1] == '/') {

                ss[i] = "-";
                s += "-";
                button12.Enabled = false;
                this.KeyPreview = true;
                button17.Select();
                }
            else {
                Array.Resize<string>(ref ss , ss.Length + 2);
                i++;
                s += "-";
                ss[i] = "-";
                i++;
                }

            button16.Enabled = false;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button18_Click (object sender , EventArgs e) { ///////////////////////
            textBox1.Text += "√";
            s += "s";
            }
        private void button19_Click (object sender , EventArgs e) {
            textBox1.Text += "ln";
            s += "l";
            }
        private void button20_Click (object sender , EventArgs e) {
            textBox1.Text += "^";
            s += "^";
            }
        private void button21_Click (object sender , EventArgs e) {
            textBox1.Text += "(";
            s += "(";
            button12.Enabled = false;
            }
        private void button22_Click (object sender , EventArgs e) {
            textBox1.Text += ")";
            s += ")";
            }
        private void button13_Click (object sender , EventArgs e) {
            textBox1.Text += "*";
            s += "*";
            Array.Resize<string>(ref ss , ss.Length + 2);
            i++;
            ss[i] = "*";
            i++;
            button16.Enabled = false;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button14_Click (object sender , EventArgs e) {
            textBox1.Text += "/";
            s += "/";
            Array.Resize<string>(ref ss , ss.Length + 2);
            i++;
            ss[i] = "/";
            i++;
            button16.Enabled = false;
            this.KeyPreview = true;
            button17.Select();
            }
        private void button17_Click (object sender , EventArgs e) {
            textBox1.Clear();
            MessageBox.Show(Polish(s) , "RESULT");
            proverka(ss);
            button15.PerformClick();
            this.KeyPreview = true;
            button17.Select();

            }
        private void proverka (string[] mas) {
            textBox1.Clear();
            for (int j = 0 ; j < mas.Length ; j++)
                textBox1.Text += mas[j] + " ";
            }



        // V V V V V V V V V V V V V V V V V     [П Л Ю С]      V V V V V V V V V V V V V V V V
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

            if (srav(a , b) == 2)
                return "-" + minus(b , a);

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
        private static string sqrt (string a) {
            string b, c, res, o, aa;
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

            if (a.IndexOf(',') >= 0)
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

            if (a.Length > 0 && a[0] == ',') {
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

                if (a.Length > 0 && a[0] == ',') {
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
                res = res.Insert(Convert.ToInt32(Math.Round(Convert.ToDouble((aa.Length / 2) + 1))) , ",");
            DeleteZero(ref res);
            return res;
            }
        private static int srav (string a , string b) {
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
                while (a.Length>1 && a[0] == '0')
                    a = a.Remove(0 , 1);

            if (b[0] == '0')
                while (b.Length>1 && b[0] == '0')
                    b = b.Remove(0 , 1);
            }
        private static void DeleteZero (ref string a) {
            while (a.Length > 1 && a[0] == '0' && a[1] != ',')
                a = a.Remove(0 , 1);
            if (a.IndexOf(',') >= 0)
                while (a[a.Length - 1] == '0' && a.Length > 1)
                    a.Remove(a.Length - 1);
            }




        // VVVVVVVVVVVVVVVVVVVVVVVVVVVVVV       [В Ы Ч И С Л Е Н И Я]      VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
        private static string res (string[] args) {
            int i = 1;
            int j;
            int k = args.Length - 1;
            bool f = false;
            string a, b, c;


            while (i < k) {
                if (args[i] == "*") {
                    args[i - 1] = umn(args[i - 1] , args[i + 1]);

                    for (j = i ; j <= k - 2 ; j++)
                        args[j] = args[j + 2];
                    k -= 2;
                    }
                if (args[i] == "/") {

                    if (args[i + 1] == "0") {
                        return "На 0 делить нельзя!";
                        f = true;
                        break;
                        }
                    args[i - 1] = delit(args[i - 1] , args[i + 1]);
                    for (j = i ; j <= k - 2 ; j++)
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
                        if ((args[i - 1])[0] != '-' & (args[i + 1])[0] != '-') {
                            args[i - 1] = plus(args[i - 1] , args[i + 1]);
                            for (j = i ; j <= k - 2 ; j++)
                                args[j] = args[j + 2];
                            k -= 2;
                            }
                        else {
                            args[i - 1] = plus(args[i - 1] , args[i + 1]);
                            for (j = i ; j <= k - 2 ; j++)
                                args[j] = args[j + 2];
                            k -= 2;
                            }
                        }
                    if (k > 0)
                        if (args[i] == "-") {
                            if (args[i - 1].Length < 30 && args[i + 1].Length < 30) {
                                args[i - 1] = minus(args[i - 1] , args[i + 1]);

                                }
                            else
                                if (args[i - 1].Length - args[i - 1].IndexOf(",") > args[i + 1].Length - args[i + 1].IndexOf(","))
                                args[i - 1] = minus(args[i - 1] , args[i + 1]);
                            else
                                args[i - 1] = "-" + minus(args[i + 1] , args[i - 1]);


                            for (j = i ; j <= k - 2 ; j++)
                                args[j] = args[j + 2];
                            k -= 2;
                            }
                    }
            if (f == false)
                return args[0];
            else
                return "";
            }
        private void textBox1_KeyPress (object sender , KeyPressEventArgs e) {
            char c = e.KeyChar;
            e.Handled = !((c >= '0' && c <= '9') || (c == '+') || (c == '-') || (c == '*') || (c == '/'));
            }
        private void Form1_KeyDown (object sender , KeyEventArgs e) {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                button10.PerformClick();
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                button1.PerformClick();
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                button2.PerformClick();
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                button3.PerformClick();
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                button4.PerformClick();
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                button5.PerformClick();
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                button6.PerformClick();
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                button7.PerformClick();
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                button8.PerformClick();
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                button9.PerformClick();


            if (e.KeyCode == Keys.Add)
                button11.PerformClick();

            if (e.KeyCode == Keys.Subtract)
                button12.PerformClick();
            if (e.KeyCode == Keys.Multiply)
                button13.PerformClick();
            if (e.KeyCode == Keys.Divide)
                button14.PerformClick();
            if (e.KeyCode == Keys.Enter)
                button17.PerformClick();
            if (e.KeyCode == Keys.Decimal)
                button16.PerformClick();
            if (e.KeyCode == Keys.Back)
                button15.PerformClick();

            }
        private void textBox1_TextChanged (object sender , EventArgs e) {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            }


        // Процедуры для обратной польской нотации
        public static string Polish (string s) {
            int i = 0;

            string[] num = new string[0];
            if (!Check(s)) 
                return "Invalid entry!";

            Stack<String> res = new Stack<String>();
            Stack<String> temp = new Stack<String>();

            DoCorrectOrder(ref s);
            for (i = 0 ; i < s.Length ; i++)
                ReName(ref s , i);
            StringToArray(s , ref num);

            RPN(ref res , ref temp , num);
            while (res.Count > 0)
                temp.Push(res.Pop());

            while (temp.Count > 0)
                if (IsNumber(temp.Peek()))
                    res.Push(temp.Pop());
                else
                    switch (temp.Pop()) {
                        case "+":
                            res.Push(plus(res.Pop() , res.Pop()));
                            break;
                        case "-":
                            s = res.Pop();
                            res.Push(minus(res.Pop() , s));
                            break;
                        case "*":
                            res.Push(umn(res.Pop() , res.Pop()));
                            break;
                        case "/":
                                s = res.Pop();
                            if (s == "0")
                                return "An attempt to divide by zero. Please enter the correct values.";
                                res.Push(delit(res.Pop() , s));
                            break;
                        case "^":
                            s = res.Pop();
                            try { res.Push((Math.Pow(Convert.ToDouble(res.Pop()) , Convert.ToDouble(s)).ToString())); }
                            catch (FormatException) {
                                return "Invalid format of the entered data. Please enter the correct values.";
                                }

                            catch (OverflowException) {
                                return "Too much or too little input value. Please enter the correct values.";
                                }
                            break;
                        case "s":
                            if (res.Peek()[0] == '-')
                                return "Attempting to extract the square root of a negative number. Please enter the correct values.";
                            try { res.Push((Math.Sqrt(Convert.ToDouble(res.Pop())).ToString())); }
                            catch (FormatException) {
                                return "Invalid format of the entered data. Please enter the correct values.";
                                }

                            catch (OverflowException) {
                                return "Too much or too little input value. Please enter the correct values.";
                                }
                            break;
                        case "l":
                            if (res.Peek()[0] == '-' || res.Peek()=="0")
                                return "Attempting to remove the natural logarithm of the number smaller than 1. Please enter the correct values.";
                            try { res.Push((Math.Log(Convert.ToDouble(res.Pop())).ToString())); }
                            catch (FormatException) {
                                return "Invalid format of the entered data. Please enter the correct values.";
                                }

                            catch (OverflowException) {
                                return "Too much or too little input value. Please enter the correct values.";
                                }
                            break;
                        }
            return res.Peek();
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
                        while (temp.Count > 0 && Prior(a[i]) <= Prior(temp.Peek()))
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
                        if (char.IsDigit(key.KeyChar) || key.KeyChar == 43 || key.KeyChar == 42 || key.KeyChar == 28 ||
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
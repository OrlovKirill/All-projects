using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary {



    public partial class Form1: Form {

        FileDictList FDL = new FileDictList();

        public Form1 () {

            InitializeComponent();

            listBox2.Visible = false;
            }

        private void Form1_Load (object sender , EventArgs e) {

            }

        private void button7_Click (object sender , EventArgs e) {
            listBox2.Visible = true;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            foreach (string item in FDL.GetPalindromes())
                listBox2.Items.Add(item);
            button12.Enabled = button13.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = false;
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FDL.Load();
            listBox1.Items.AddRange(FDL.ToArray());
        }
        private void button2_Click (object sender , EventArgs e) {
            
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);
            FDL.Save(FDL.fPath);
            }

        public void button3_Click (object sender , EventArgs e) {
            if (save.ShowDialog() == DialogResult.OK) {
                FDL.fPath = save.FileName;
                TextWriter writer = new StreamWriter(save.FileName);
                foreach (var item in listBox1.Items)
                    writer.WriteLine(item.ToString());
                writer.Close();
                }
            }

        private void listBox1_MouseDoubleClick (object sender , MouseEventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                button10.Enabled = button11.Enabled = false;
                textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
                }
            }

        private void textBox1_KeyPress (object sender , KeyPressEventArgs e) {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                listBox1.Items[listBox1.SelectedIndex] = textBox1.Text.ToUpper();
                button10.Enabled = button11.Enabled = true;
                textBox1.Clear();
                listBox1.ClearSelected();
                }

            }

        private void button8_Click (object sender , EventArgs e) {
            listBox2.Visible = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            foreach (string item in FDL.GetMoms())
                listBox2.Items.Add(item);
            button12.Enabled = button13.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = false;
            
            }

        private void button9_Click (object sender , EventArgs e) {
            listBox2.Visible = false;
            textBox2.Enabled = true;
            listBox2.Items.Clear();
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = button12.Enabled = button13.Enabled = true;
            textBox1.Enabled = true;
            }

        private void button10_Click (object sender , EventArgs e) {
            if (textBox1.Text.Length > 0) {
                listBox1.Items.Add(textBox1.Text.ToUpper());
                textBox1.Clear();
                }
            }

        private void button11_Click (object sender , EventArgs e) {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

        private void button4_Click (object sender , EventArgs e) {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            }

        private void button6_Click (object sender , EventArgs e) {
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            FDL.Sort();

            listBox1.Items.Clear();
            foreach (string item in FDL)
                listBox1.Items.Add(item);

            }

        private void button5_Click (object sender , EventArgs e) {

            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            FDL.Fract();

            listBox1.Items.Clear();
            foreach (string item in FDL)
                listBox1.Items.Add(item);

            }

        private void button12_Click (object sender , EventArgs e) {
            listBox2.Items.Clear();
            listBox2.Visible = true;
            textBox1.Enabled = false;
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            foreach (string item in FDL.GetFrame(textBox2.Text))
                listBox2.Items.Add(item);
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = button12.Enabled = button13.Enabled=false;
            }

        private void button13_Click (object sender , EventArgs e) {
            listBox2.Items.Clear();
            listBox2.Visible = true;
            textBox1.Enabled = false;
            FDL.Clear();
            foreach (string s in listBox1.Items)
                FDL.Add(s);

            foreach (string item in FDL.GetGlas(textBox2.Text))
                listBox2.Items.Add(item);
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = button12.Enabled = button13.Enabled = false;
            }

        private void button14_Click (object sender , EventArgs e)
            {
            SortedDictionary<string , string> SD = new SortedDictionary<string , string>();
            //List<string> Anagrams = new List<string>();
            foreach (string item in listBox1.Items)
                {
                char[] words = item.ToArray();
                Array.Sort(words);
                string key = new string(words);
                if (!SD.ContainsKey(key))
                    SD.Add(key , item);
                else
                    SD[key] += "    " + item;
                }
            listBox1.Items.Clear();
            foreach (string item in SD.Values)
                if(item.IndexOf(' ')>0) listBox1.Items.Add(item);
            }
        }


    class FileDictList: List<string> {

        public string fPath;

        public bool IsConsonants (char a) {
            if ("ЦКНГШЩЗХФВПРЛДЖЧСМТБ".IndexOf(a) >= 0)
                return true;
            else
                return false;
            }
        public bool IsVolwels (char a) {
            if ("ЁУЕЫАОЭЯИЮЬЪ".IndexOf(a) >= 0)
                return true;
            else
                return false;
            }

        public void Load (string filePath , int wordLen = 0) {

            StreamReader textreader = new StreamReader(filePath);

            fPath = filePath;
            if (wordLen != 0)
                while (textreader.Peek() >= 0) { if (textreader.Peek().ToString().Length == wordLen) this.Add(textreader.ReadLine() + "\n"); }
            else
                while (textreader.Peek() >= 0)
                    this.Add(textreader.ReadLine().ToUpper() + "\n");


            textreader.Close();

            }

        public void Load () {

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK) {
                fPath = open.FileName;
                StreamReader textreader = new StreamReader(open.FileName);
                this.Clear();
                while (textreader.Peek() >= 0)
                    this.Add(textreader.ReadLine().ToUpper());

                textreader.Close();
                }
            }

        public void Save (string filePath) {

            FileStream f = new FileStream(filePath , FileMode.Create , FileAccess.Write);
            TextWriter writer = new StreamWriter(f);
            foreach (string item in this)
                writer.WriteLine(item);
            writer.Close();
            }

        public void Save () {

            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK) {
                TextWriter writer = new StreamWriter(save.FileName);
                writer.Write(this);
                writer.Close();
                }
            }

        public void Fract () {
            this.Sort(new LengthSorter());
            }

        public List<string> GetPalindromes() {
            List<string> pal = new List<string>();
            foreach (string k in this)
                if (k == reverse(k))
                    pal.Add(k);
            return pal;
            }

        public List<string> GetMoms () {
            List<string> moms = new List<string>();
            foreach (string k in this)
                if (k.Length % 2 == 0)
                    if (k.Substring(0 , k.Length / 2) == k.Substring(k.Length / 2))
                        moms.Add(k);
            return moms;
            }

        public List<string> GetFrame (string fr) {
            List<string> frame = new List<string>();
            byte i = 0;
            byte j = Convert.ToByte(fr.Length);
            string copyfr;
            foreach (string k in this) {
                i = 0;
                copyfr = fr;
                foreach (char c in k)
                    if (IsConsonants(c)) {
                        i++;
                        if (copyfr.IndexOf(c) >= 0) 
                        copyfr = copyfr.Remove(copyfr.IndexOf(c) , 1);
                        }
                if (i == j && copyfr.Length==0)
                    frame.Add(k);
                }
            return frame;
                }

        public List<string> GetGlas (string gl) {
            List<string> glas = new List<string>();
            bool IsInGl = true;
            gl=gl.ToUpper();
            foreach (string k in this) {
                IsInGl = true;
                foreach (char c in k)
                {
                    if (IsVolwels(c))
                        if (gl.IndexOf(c) < 0)
                            IsInGl = false;
                    if (IsInGl) continue; else break;
                }
                if (IsInGl) glas.Add(k);
               }
            return glas;
            }


        public string reverse (string input) {
            string output = null;
            int i;
            for (i = input.Length - 1 ; i >= 0 ; i--)
                output += input[i];
            return output;
            }



        }
    class LengthSorter : IComparer<string> {
        int IComparer<string>.Compare(string x, string y) {
            int res = x.Length.CompareTo(y.Length);
            if (res == 0)
                res = x.CompareTo(y);
            return res;
            }
        

        }
    }


        
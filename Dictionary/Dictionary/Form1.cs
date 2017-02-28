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

        public string filepath;

        public Form1 () {

            InitializeComponent();

            listBox2.Visible = false; 
            }

        private void Form1_Load (object sender , EventArgs e) {

            }

        private void button7_Click (object sender , EventArgs e) {
            listBox2.Visible = true;
            textBox1.Enabled = false;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = false;
            foreach (string k in listBox1.Items)
                if (k == Reverse(k))
                    listBox2.Items.Add(k);
            }

        private void button1_Click (object sender , EventArgs e) {

            listBox2.Visible = false;
            listBox2.Items.Clear();
            if (open.ShowDialog() == DialogResult.OK) {

                filepath = open.FileName;
                
                listBox1.Items.Clear();
              StreamReader textreader = new StreamReader(open.FileName);
                  while (textreader.Peek() >= 0) 
                    listBox1.Items.Add(textreader.ReadLine());
                textreader.Close();
                }
            }

        private void button2_Click (object sender , EventArgs e) {
            FileStream f = new FileStream(filepath , FileMode.Create , FileAccess.Write);
            TextWriter writer = new StreamWriter(f);
            foreach (var item in listBox1.Items)
                writer.WriteLine(item.ToString());
            writer.Close();
            }

        public void button3_Click (object sender , EventArgs e) {
            if (save.ShowDialog() == DialogResult.OK) {
                filepath = save.FileName;
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
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = false;
            foreach (string k in listBox1.Items)
                if (k.Length % 2 == 0)
                if (k.Substring(0 ,k.Length / 2) == k.Substring(k.Length / 2))
                    listBox2.Items.Add(k);
            }

        private void button9_Click (object sender , EventArgs e) {
            listBox2.Visible = false;
            listBox2.Items.Clear();
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button10.Enabled = button11.Enabled = true;
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
           
            listBox1.Sorted = true;
            listBox1.Sorted = false;
            }

        private void button5_Click (object sender , EventArgs e) {
           
            listBox1.Sorted = true;
            listBox1.Sorted = false;

            string[,] fract = new string [1,byte.MaxValue];
            int[] IndOfLastEl = new int [byte.MaxValue];
            int i, j;
            byte count;

            for (i = 0 ; i < listBox1.Items.Count ; i++) {
                listBox1.SelectedIndex = i;
                count = Convert.ToByte((listBox1.Items[i].ToString()).Length);

                if (IndOfLastEl[count] + 1 > fract.GetLength(0))
                    ResizeArray<string>(ref fract , fract.GetLength(0) + 1);

                    fract[IndOfLastEl[count],count] = listBox1.Items[i].ToString();
                    IndOfLastEl[count]++;
                listBox1.Items.RemoveAt(i);
                }

            listBox1.Items.Clear();
            for (i = 1 ; i <= byte.MaxValue - 1 ; i++)
                for (j = 0 ; j < IndOfLastEl[i] ; j++)
                    listBox1.Items.Add(fract[j, i]);

                }

        public static void ResizeArray<T> (ref T[,] original , int cols) {
            T[,] newArray = new T[cols,byte.MaxValue];
            Array.Copy(original , newArray , original.Length);
            original = newArray;
            }
        private string Reverse (string input) {
            string output = null;
            int i;
            for (i = input.Length - 1 ; i >= 0 ; i--)
                output += input[i];
            return output; 
            }
        }
        }
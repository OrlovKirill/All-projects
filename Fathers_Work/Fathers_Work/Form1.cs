using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fathers_Work
    {


    public partial class Form1: Form
        {
        /*
         0  - утро
         1  - утро
         2  - утро
         3  - утро
         4  - выходной
         5  - обед
         6  - обед
         7  - обед
         8  - обед
         9  - выходной
         10 - ночь
         11 - ночь
         12 - ночь
         13 - ночь
         14 - из ночи
         15 - выходной
        */
        private DateTime FirstMorning = new DateTime(2016 , 12 , 23);
        private string[] Months = new string[12] { "ЯНВ" , "ФЕВ" , "МАР" , "АПР" , "МАЯ" , "ИЮН" , "ИЮЛ" , "АВГ" , "СЕН" , "ОКТ" , "НОЯ" , "ДЕК" };


        public Form1 ()
            {
            InitializeComponent();
            }

        private void Form1_Load (object sender , EventArgs e)
            {

            ToolTip t = new ToolTip();
            t.InitialDelay = 100;
            t.AutoPopDelay = 100000;
            t.AutomaticDelay = 0;
            t.SetToolTip(WEEKEND , "Отображение ближайших выходных к выбранной дате");
            t.SetToolTip(SHIFT_DATE , "Рассчёт смены на нужную дату");
            t.SetToolTip(PLAN_THIS_MONTH , "Отображение графика на месяц для выбранной даты");


            }

        private void WEEKEND_Click (object sender , EventArgs e)
            {
            label2.Visible = false;
            listBox1.Items.Clear();
            DateTime today = new DateTime();
            today = dateTimePicker1.Value.Date;
            if (today == DateTime.Now.Date)
                {
                for (int i = 1 ; i < 15 ; i++)
                    {
                    today = today.AddDays(1);
                    string res = GetShift(today);
                    if (res == "ВЫХОДНОЙ" || res == "ИЗ НОЧИ")
                        AddDay(today , res);
                    }
                }
            else
                {
                today = today.AddDays(-14);
                string res;
                for (int i = -14 ; i < 0 ; i++)
                    {
                    today = today.AddDays(1);
                    res = GetShift(today);
                    if (res == "ВЫХОДНОЙ" || res == "ИЗ НОЧИ")
                        AddDay(today , res);
                    }
                res = GetShift(today);
                AddDay(today , res);
                listBox1.SelectedIndex =listBox1.Items.Count-1;
                for (int i = 1 ; i < 15 ; i++)
                    {
                    today = today.AddDays(1);
                    res = GetShift(today);
                    if (res == "ВЫХОДНОЙ" || res == "ИЗ НОЧИ")
                        AddDay(today , res);
                    }
                
                }
            }
        
        private void AddDay (DateTime day, string res)
            {
            if (day.Day.ToString().Length == 2)
                listBox1.Items.Add(day.Day.ToString() + "  " + Months[day.Month - 1] + "   " + RusDayOfWeek(day) + "    -    " + "["+res+ "]");
            else
                listBox1.Items.Add(day.Day.ToString() + "    " + Months[day.Month - 1] + "   " + RusDayOfWeek(day) + "    -    " + "[" + res + "]");
            }

        private string RusDayOfWeek (DateTime today)
            {
            switch (today.DayOfWeek.ToString())
                {
                case "Sunday":
                    return "(вс)";
                case "Monday":
                    return "(пн)";
                case "Tuesday":
                    return "(вт)";
                case "Wednesday":
                    return "(ср)";
                case "Thursday":
                    return "(чт)";
                case "Friday":
                    return "(пт)";
                case "Saturday":
                    return "(сб)";
                }
            return "";
            }

        private string GetShift (DateTime date)
            {
            date = date.Date;
            int sub;
            if (date.Date >= FirstMorning.Date)
                {
                sub = (date.Subtract(FirstMorning).Days ) % 16;
                }
            else
                {
                sub =16- Math.Abs((date.Subtract(FirstMorning).Days) % 16);
                }
             
            if (sub == 4 || sub == 9 || sub == 15)
                return "ВЫХОДНОЙ";
            else
                if (sub < 4)
                return "     УТРО    ";
            else
                if (sub < 9)
                return "     ОБЕД    ";
            else
                if (sub == 14)
                return "  ИЗ НОЧИ  ";
            else
                return "     НОЧЬ    ";
            }



        private void SHIFT_DATE_Click (object sender , EventArgs e)
            {
            label2.Visible = false;
            listBox1.Items.Clear();
            AddDay(dateTimePicker1.Value , GetShift(dateTimePicker1.Value));
            listBox1.SelectedIndex = 0;
            }

        private void PLAN_THIS_MONTH_Click (object sender , EventArgs e)
            {
            label2.Visible = false;
            listBox1.Items.Clear();
            DateTime CurrDay = new DateTime();
            if (dateTimePicker1.Value.Date != DateTime.Now.Date)
                {
                CurrDay = dateTimePicker1.Value.AddDays(-14);
                for (int i = 1 ; i < 31 ; i++)
                    {
                    AddDay(CurrDay , GetShift(CurrDay));
                    CurrDay = CurrDay.AddDays(1);
                    }
                listBox1.SelectedIndex = 14;
                }
            else
                {
                CurrDay = dateTimePicker1.Value;
                for (int i = 1 ; i < 31 ; i++)
                    {
                    AddDay(CurrDay , GetShift(CurrDay));
                    CurrDay = CurrDay.AddDays(1);
                    }
                listBox1.SelectedIndex = 0;
                }
            }

        private void button1_Click (object sender , EventArgs e)
            {
            label2.Visible = true;
            MessageBox.Show("Данный софт разработан специально для трудящихся ОАО \"БМК\"\nГенеральный спонсор - Дед Мороз\n\nИдейные вдохновители: победители в номинации \n\"Лучшие родители года 2016\" Дмитрий и Татьяна Орловы\n\nОтзывы, пожелания и предложения принимаются по адресу \n                                         orlovkirill31@mail.ru", "О программе");
            }
        }
    }

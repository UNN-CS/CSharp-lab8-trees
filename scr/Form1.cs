using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Дуб
{
    public partial class Form1 : Form
    {
        string u;
        public Form1()
        {
            InitializeComponent();
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 1 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if(radioButton2.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 2 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if (radioButton3.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 3 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if (radioButton4.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 4 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            Tree t = new Tree();

            u = u.Replace(".", " ");
            u = u.Replace(" ", " ");
            u = u.Replace(",", " ");
            u = u.Replace("<сноска", " ");
            u = u.Replace(" –", " ");
            u = u.Replace("-", " ");
            u = u.Replace("–", " ");
            u = u.Replace("\"", " ");
            u = u.Replace("!", " ");
            u = u.Replace("?", " ");
            u = u.Replace("[", " ");
            u = u.Replace("]", " ");
            u = u.Replace("\n", " ");
            u = u.Replace("\r", " ");
            u = u.Replace("\t", " ");
            string[] words = u.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // разбили текст на массивы слов, убрав пробелы

            foreach (string s in words)
            {
                t.vstavka(s.ToLower());
            }
            
            try
            {
                var commons = t.GetCommons(Convert.ToInt32(textBox1.Text));
                foreach (var cell in commons)
                {
                    textBox2.Text = cell.Print();
                }
            }
            catch
            {
                MessageBox.Show("Либо пусто, либо значение слишком большое");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 1 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if (radioButton2.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 2 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if (radioButton3.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 3 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            else if (radioButton4.Checked)
            {
                u = File.ReadAllText(@"D:\бэкап\С#\Дуб\Толстой Лев Николаевич. Война и мир. Том 4 - ModernLib.Ru.txt", System.Text.Encoding.GetEncoding(1251));
            }
            Tree t = new Tree();

            u = u.Replace(".", " ");
            u = u.Replace(" ", " ");
            u = u.Replace(",", " ");
            u = u.Replace("<сноска", " ");
            u = u.Replace(" –", " ");
            u = u.Replace("-", " ");
            u = u.Replace("–", " ");
            u = u.Replace("\"", " ");
            u = u.Replace("!", " ");
            u = u.Replace("?", " ");
            u = u.Replace("[", " ");
            u = u.Replace("]", " ");
            u = u.Replace("\n", " ");
            u = u.Replace("\r", " ");
            u = u.Replace("\t", " ");
            string[] words = u.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // разбили текст на массивы слов, убрав пробелы

            foreach (string s in words)
            {
                t.vstavka(s.ToLower());
            }

            try
            {
                string inputLine = textBox3.Text;
                var needed = t.Search(inputLine.ToLower());
                textBox4.Text = needed.Print();
            }
            catch
            {
                MessageBox.Show("Либо пусто, либо значение слишком большое");
            }
        }
    }
}

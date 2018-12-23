using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace ConsoleApplication1
{
    partial class Tree
    {
        private string stroka; // хранимая строка
        private int schetchik_povtoreniy;    // счётчик повторений
        private Tree left;    // ссылка на левое поддерево
        private Tree right;   // ссылка на правое поддерево
    }

    //    Вставку элементов в дерево можно производить после создания экземпляра класса Tree.
    //    При вызове метода мы передаём вставляемую в дерево строку.Если текущий элемент(узел) дерева пустой, то в него копируется переданная строка.
    //    Если нет, то переданная строка сравнивается со строкой в узле и далее создаётся либо левое, либо правое поддерево, 
    //    а потом для него снова вызывается vstavka.
    partial class Tree
    {
        public void vstavka(string stroka)
        {
            if (this.stroka == null)
            {
                this.stroka = stroka;
                this.schetchik_povtoreniy = 1;
            }
            else
            {
                if (this.stroka.CompareTo(stroka) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.vstavka(stroka);
                }
                else if (this.stroka.CompareTo(stroka) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.vstavka(stroka);
                }
                else
                    this.schetchik_povtoreniy++;
            }
        }
    }

    // поиск
    partial class Tree
    {
        public Tree Search(string stroka)
        {
            if (this.stroka == stroka)
                return this;
            else if (this.stroka.CompareTo(stroka) == 1)
            {
                if (left != null)
                    return this.left.Search(stroka);
                else
                    throw new Exception("Искомого узла в дереве нет"); //генерирование исключения (throw), если искомый узел не будет найден.
            }
            else
            {
                if (right != null)
                    return this.right.Search(stroka);
                else
                    throw new Exception("Искомого узла в дереве нет"); //генерирование исключения (throw), если искомый узел не будет найден.
            }
        }
    }

    partial class Tree
    {
        // отображение в строку
        public string Display(Tree t)
        {
            string result = "";
            if (t.left != null)
                result += Display(t.left);
            result += t.stroka + " ";
            if (t.right != null)
                result += Display(t.right);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();
            
            string u = File.ReadAllText(@"D:\бэкап\С#\ConsoleApplication1\тест.txt", System.Text.Encoding.GetEncoding(1251));
            u = u.Replace(".", " ");
            u = u.Replace(",", " ");
            u = u.Replace("-", " ");
            u = u.Replace("\"", " ");
            u = u.Replace("!", " ");
            u = u.Replace("?", " ");
            u = u.Replace("[", " ");
            u = u.Replace("]", " ");
            u = u.Replace("\n", " ");
            u = u.Replace("\r", " ");
            string[] words = u.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // разбили текст на массивы слов, убрав пробелы


            foreach (string s in words)
            {
                t.vstavka(s.ToLower());
            }

            foreach (string s in words)
            {
                Console.WriteLine(s.ToLower());
            }
            
            //t.vstavka("персик");
            //t.vstavka("черника");
            //t.vstavka("мандарин");
            //t.vstavka("груша");
            //t.vstavka("яблоко");
            //t.vstavka("клубника");

            //Console.WriteLine(t.Display(t));
            Tree ds = t.Search("небо");
            Console.WriteLine(ds.Display(ds));
            Console.Read();
        }
    }
}
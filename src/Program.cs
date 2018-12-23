using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bin_Tree
{
    partial class Tree
    {
        public int repeat_count;    // счётчик повторений
        public string stroka; // хранимая строка
        public Tree left;    // ссылка на левое поддерево
        public Tree right;   // ссылка на правое поддерево
    }

    partial class Tree
    {
        public void input(string stroka)
        {
            if (this.stroka == null)
            {
                this.stroka = stroka;
                this.repeat_count = 1;
            }
            else
            {
                if (this.stroka.CompareTo(stroka) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.input(stroka);
                }
                else if (this.stroka.CompareTo(stroka) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.input(stroka);
                }
                else this.repeat_count++;
            }
        }
    }

    // Поиск по дереву
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
        // Отображение в строку
        public string PrintString(Tree t)
        {
            string result = "";
            if (t.left != null)
                result += PrintString(t.left);
            result += t.stroka + " ";
            if (t.right != null)
                result += PrintString(t.right);
            return result;
        }
    }
    // Самые встречающиеся слова
    partial class Tree
    {
        public void MostCommons(int max_repeats, List<Tree> result, Tree root)
        {
            if (root != null)
            {
                result.Add(root);
                MostCommons(result.Last().repeat_count, result, root.left);
                MostCommons(result.Last().repeat_count, result, root.right);
            }
        }
    }

    partial class Tree
    {
        public void Print()
        {
            Console.WriteLine($"Слово \"{stroka}\" — {repeat_count}");
        }
    }
    // Выбор самых встречающихся
    partial class Tree
    {
        public List<Tree> GetCommons(int count)
        {
            var result = new List<Tree>();
            MostCommons(0, result, this);
            var selected = result.OrderByDescending(cell => cell.repeat_count).Take(count);
            return selected.ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();

            string text = File.ReadAllText("D:/GitProjects/CSharp-lab8-trees/src/Text.txt", System.Text.Encoding.GetEncoding(1251));
            text = text.Replace(".", " ");
            text = text.Replace(",", " ");
            text = text.Replace("-", " ");
            text = text.Replace(";", " ");
            text = text.Replace(":", " ");
            text = text.Replace("!", " ");
            text = text.Replace("?", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\"", " ");
            text = text.Replace("[", " ");
            text = text.Replace("]", " ");
            text = text.Replace("\r", " ");
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // разбиваем текст на отдельные слова ориентируясь на пробелы

            foreach (string s in words)
            {
                t.input(s.ToLower()); // записали слова
            }
            Console.WriteLine("Текст без знаков:");
            foreach (string s in words)
            {
                Console.Write(s.ToLower()+" "); // вывели слова по очереди через пробел
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine(t.PrintString(t));

            Console.WriteLine();
            Console.WriteLine("Самые частые слова: ");
            var commons = t.GetCommons(10);
            foreach (var c in commons)
            {
                c.Print();
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
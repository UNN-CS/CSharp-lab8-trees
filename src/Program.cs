using System;
using System.Diagnostics;

namespace BinarySearchTree
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bin_Tree
{
    class Node
    partial class Tree
    {
        public int value;
        public Node left;
        public Node right;
        public int repeat_count;    // счётчик повторений
        public string stroka; // хранимая строка
        public Tree left;    // ссылка на левое поддерево
        public Tree right;   // ссылка на правое поддерево
    }

    class Tree
    partial class Tree
    {
        public Node insert(Node root, int v)
        public void input(string stroka)
        {
            if (root == null)
            if (this.stroka == null)
            {
                root = new Node();
                root.value = v;
                this.stroka = stroka;
                this.repeat_count = 1;
            }
            else if (v < root.value)
            else
            {
                root.left = insert(root.left, v);
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
                root.right = insert(root.right, v);
                if (right != null)
                    return this.right.Search(stroka);
                else
                    throw new Exception("Искомого узла в дереве нет"); //генерирование исключения (throw), если искомый узел не будет найден.
            }

            return root;
        }
    }

        public void traverse(Node root)
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
            if (root == null)
            if (root != null)
            {
                return;
                result.Add(root);
                MostCommons(result.Last().repeat_count, result, root.left);
                MostCommons(result.Last().repeat_count, result, root.right);
            }
        }
    }

            traverse(root.left);
            traverse(root.right);
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

    class BinarySearchTree
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree bst = new Tree();
            int SIZE = 2000000;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

            Random random = new Random();

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
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
                a[i] = random.Next(10000);
                t.input(s.ToLower()); // записали слова
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            Console.WriteLine("Текст без знаков:");
            foreach (string s in words)
            {
                root = bst.insert(root, a[i]);
                Console.Write(s.ToLower()+" "); // вывели слова по очереди через пробел
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.traverse(root);
            Console.WriteLine();

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine(t.PrintString(t));

            Console.ReadKey();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8._1
{
    partial class Tree
    {
        private string st; 
        private int count;    
        private Tree left;    
        private Tree right;   
    }

    partial class Tree
    {
        public void Insert(string st)
        {
            if (this.st == null)
            {
                this.st = st;
                this.count = 1;
            }
            else
            {
                if (this.st.CompareTo(st) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.Insert(st);
                }
                else if (this.st.CompareTo(st) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.Insert(st);
                }
                else
                    this.count++;
            }
        }
    }

    partial class Tree
    {
        public Tree Search(string st)
        {
            if (this.st == st)
                return this;
            else if (this.st.CompareTo(st) == 1)
            {
                if (left != null)
                    return this.left.Search(st);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }
            else
            {
                if (right != null)
                    return this.right.Search(st);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }
        }
    }

    partial class Tree
    {
        public string Display(Tree t)
        {
            string result = "";
            if (t.left != null)
                result += Display(t.left);
            result += t.st + " ";
            if (t.right != null)
                result += Display(t.right);
            return result;
        }
    }

    partial class Tree
    {
        public void MostCommons(int max_repeats, List<Tree> result, Tree root)
        {
            if (root != null)
            {
                result.Add(root);
                MostCommons(result.Last().count, result, root.left);
                MostCommons(result.Last().count, result, root.right);
            }
        }
    }

    partial class Tree
    {
        public void Print()
        {
            Console.WriteLine($"Слово \"{st}\" — {count}");
        }
    }

    partial class Tree
    {
        public List<Tree> GetCommons(int count)
        {
            var result = new List<Tree>();
            MostCommons(0, result, this);
            var selected = result.OrderByDescending(cell => cell.count).Take(count);
            return selected.ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();

            string u = File.ReadAllText("C:\\Users\\Яна\\Downloads\\voyna-i-mir-tom-1.txt", System.Text.Encoding.GetEncoding(1251));
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
           


            foreach (string s in words)
            {
                t.Insert(s.ToLower());
            }

            foreach (string s in words)
            {
                Console.WriteLine(s.ToLower()+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(t.Display(t));
            Console.WriteLine();
            Console.WriteLine("Самые повторяемые слова: ");
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

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//
namespace Lab8
{
    partial class Tree
    {
        public string stroka; 
        public int schetchik_povtoreniy;    
        public Tree left;    
        public Tree right;   
    }
    /// <summary>
    /// //////////////
    /// </summary>
    
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

   /// <summary>
   /// /////////////////////
   /// </summary>
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
    /// <summary>
    /// ////////////////////////
    /// </summary>
    partial class Tree
    {
        public void MostCommons(int max_repeats, List<Tree> result, Tree root)
        {
            if (root != null)
            {
               

                result.Add(root);

                MostCommons(result.Last().schetchik_povtoreniy, result, root.left);
                MostCommons(result.Last().schetchik_povtoreniy, result, root.right);
            }
        }
    }

    partial class Tree
    {
        public void Print()
        {
            Console.WriteLine($" {stroka} встретилось {schetchik_povtoreniy}");
        }
    }

    partial class Tree
    {
        public List<Tree> GetCommons(int desired_quantity)
        {
            var result = new List<Tree>();
            MostCommons(0, result, this);
            var selected = result.OrderByDescending(cell => cell.schetchik_povtoreniy).Take(desired_quantity);
            return selected.ToList();
        }
    }
    /// <summary>
    /// ///////////////////
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();

            string u = File.ReadAllText("C:/Users/настюша/source/repos/Lab8/Lab8/TextFile1.txt", System.Text.Encoding.GetEncoding(1251));
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
            // разбили убрав пробелы

            /////////
            foreach (string s in words)
            {
                t.vstavka(s.ToLower());
            }

            foreach (string s in words)
            {
                Console.WriteLine(s.ToLower());
            }

            
            var commons = t.GetCommons(5);

            Console.WriteLine();
            Console.WriteLine(t.Display(t));

            Console.WriteLine();
            Console.WriteLine("Cамые частые слова : ");
            foreach (var cell in commons)
            {
                cell.Print();
            }

            Console.WriteLine();
            Console.Read();
        }
    }
}
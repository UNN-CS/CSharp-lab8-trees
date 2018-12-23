using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace lab_8
{
    class Node
    {
        public string value;
        public int counter = 0;
        public Node left;
        public Node right;
    }
    class Tree_String
    {
        public int step = 0;

        public Node insert(Node root, string v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            if (v.CompareTo(root.value) == 0) root.counter++;
            else if (v.CompareTo(root.value) < 0)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }


        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine("Word {0} met {1} times", root.value, root.counter);
            traverse(root.left);
            traverse(root.right);
        }
    }
    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree_String bst = new Tree_String();
            string[] words;
            string line;

            Stopwatch watch = Stopwatch.StartNew();
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Тетя\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\bin\Debug\text.txt");
            while ((line = file.ReadLine()) != null)
            {
                words = line.Split(' ');
                foreach (string word in words)
                {
                    root = bst.insert(root, word.Trim(new Char[] { '/', ',', '.', '"', '-'}));
                }
            }

            file.Close();


            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            bst.traverse(root);

        }
    }
}
